using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dventa
    {
        #region Contructores
        public Dventa()
        {

        }

        public Dventa(int idVenta, int idCliente, int idTrabajador, DateTime fecha, string tipoComprobante
            , string serie, string correlativo, decimal itbis)
        {
            IdVenta = idVenta;
            IdCliente = idCliente;
            IdTrabajador = idTrabajador;
            Fecha = fecha;
            TipoComprobante = tipoComprobante;
            Serie = serie;
            Correlativo = correlativo;
            Itbis = itbis;
        }
        #endregion


        #region Propiedades
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdTrabajador { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal Itbis { get; set; }


        #endregion


        #region MetodoDisminuirStock
        //Metodo MetodoDisminuirStock
        public string DisminuirStock(int idDetalleIngreso, int cantidad)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection               
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spdisminuir_stock]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdDetalleIngrezo = new SqlParameter("@iddetalle_ingreso", SqlDbType.Int);
                parIdDetalleIngrezo.Value = idDetalleIngreso;
                comandoSql.Parameters.Add(parIdDetalleIngrezo);

                var parCantidad = new SqlParameter("@cantidad", SqlDbType.Int);
                parCantidad.Value = cantidad;
                comandoSql.Parameters.Add(parCantidad);


                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo actualizar el stock";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexionSql.State == ConnectionState.Open)
                    conexionSql.Close();
            }

            return respuesta;
        }

        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dventa Venta, List<DdetalleVenta> Detalle)
        {

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer la transaccion
                var transaccionSql = conexionSql.BeginTransaction();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_venta]", conexionSql, transaccionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdVenta = new SqlParameter("@idventa", SqlDbType.Int);
                parIdVenta.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdVenta);

                var parIdCliente = new SqlParameter("@idcliente", SqlDbType.Int);
                parIdCliente.Value = Venta.IdCliente;
                comandoSql.Parameters.Add(parIdCliente);

                var parIdTrabajador = new SqlParameter("@idtrabajador", SqlDbType.Int);
                parIdTrabajador.Value = Venta.IdTrabajador;
                comandoSql.Parameters.Add(parIdTrabajador);

                var parFecha = new SqlParameter("@fecha", SqlDbType.Date);
                parFecha.Value = Venta.Fecha;
                comandoSql.Parameters.Add(parFecha);

                var parTipoComprobante = new SqlParameter("@tipo_comprobante", SqlDbType.VarBinary, 20);
                parTipoComprobante.Value = Venta.TipoComprobante;
                comandoSql.Parameters.Add(parTipoComprobante);

                var parSerie = new SqlParameter("@serie", SqlDbType.VarChar, 4);
                parSerie.Value = Venta.Serie;
                comandoSql.Parameters.Add(parSerie);

                var parCorrelativo = new SqlParameter("@correlativo", SqlDbType.VarChar, 7);
                parCorrelativo.Value = Venta.Correlativo;
                comandoSql.Parameters.Add(parCorrelativo);

                var parItbis = new SqlParameter("@itbis", SqlDbType.Decimal);
                parItbis.Scale = 2;
                parItbis.Precision = 4;
                parItbis.Value = Venta.Itbis;
                comandoSql.Parameters.Add(parItbis);


                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";

                if (respuesta.Equals("Ok"))
                {
                    //Obtener el codigo (Id) del ingreso generado
                    IdVenta = Convert.ToInt32(comandoSql.Parameters["@idventa"].Value);
                    foreach (DdetalleVenta item in Detalle)
                    {
                        item.IdVenta = IdVenta;
                        //Llamar al mentodo Insertar de la Clase DdetalleIngreso
                        respuesta = item.Insertar(item, ref conexionSql, ref transaccionSql);
                        if (!respuesta.Equals("Ok"))
                        {
                            break;
                        }
                        else //Si se insertan los detalles de ventas actualizamos el stock
                        {
                            respuesta = DisminuirStock(item.IdDetalleIngreso, item.Cantidad);
                            if (respuesta.Equals("Ok"))
                            {
                                break;
                            }
                        }
                    }


                }
                if (respuesta.Equals("Ok"))
                {
                    transaccionSql.Commit();
                }
                else
                {
                    transaccionSql.Rollback();
                }


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexionSql.State == ConnectionState.Open)
                    conexionSql.Close();
            }

            return respuesta;
        }
        #endregion


        #region MetodoEliminar
        //Metodo Anular
        public string Eliminar(Dventa Venta)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_venta]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdIVenta = new SqlParameter("@idventa", SqlDbType.Int);
                parIdIVenta.Value = Venta.IdVenta;
                comandoSql.Parameters.Add(parIdIVenta);


                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "Ok";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexionSql.State == ConnectionState.Open)
                    conexionSql.Close();
            }

            return respuesta;
        }

        #endregion


        #region MetodoMostrar
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("venta");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                SqlCommand comandoSql = new SqlCommand("[spmostrar_venta]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;


        }
        #endregion


        #region MetodoFechas
        //Metodo BuscarNombre
        public DataTable BuscarFechas(string fechaInicio, string FechaFin)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("venta");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_venta_fecha]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.VarChar;
                ParFechaInicio.Size = 20;
                ParFechaInicio.Value = fechaInicio;
                comandoSql.Parameters.Add(ParFechaInicio);

                var ParFechaFin = new SqlParameter("@fechaFin", SqlDbType.VarChar, 20);
                ParFechaFin.Value = FechaFin;
                comandoSql.Parameters.Add(ParFechaFin);


                var SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;
        }
        #endregion


        #region MetodoMostrarDetalles
        //Metodo BuscarNombre
        public DataTable MostrarDetalles(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("detalle_venta");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spmostrar_detalle_venta]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.Int);
                parTextoBuscar.Value = textoBuscar;
                comandoSql.Parameters.Add(parTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;
        }
        #endregion


        #region BuscarAritculoVentaNombre
        //Metodo BuscarNombre
        public DataTable BuscarAritculoVentaNombre(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("articulos");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscararticulo_venta_nombre]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar);
                parTextoBuscar.Value = textoBuscar;
                comandoSql.Parameters.Add(parTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;
        }
        #endregion


        #region BuscarAritculoVentaCodigo
        //Metodo BuscarNombre
        public DataTable BuscarAritculoVentaCodigo(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            var resutladoTabla = new DataTable("articulos");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscararticulo_venta_codigo]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.Int);
                parTextoBuscar.Value = textoBuscar;
                comandoSql.Parameters.Add(parTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resutladoTabla);

            }
            catch (Exception)
            {
                resutladoTabla = null;
            }

            return resutladoTabla;
        }
        #endregion

    }
}
