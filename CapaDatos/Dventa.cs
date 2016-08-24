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
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Asignar y abrir StringConnection
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCon.Open();

                //Establecer el comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spdisminuir_stock]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdDetalleIngrezo = new SqlParameter();
                ParIdDetalleIngrezo.ParameterName = "@iddetalle_ingreso";
                ParIdDetalleIngrezo.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngrezo.Value = idDetalleIngreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngrezo);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo actualizar el stock";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dventa Venta, List<DdetalleVenta> Detalle)
        {

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Asignar y abrir StringConnection
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCon.Open();

                //Establecer la transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();

                //Establecer el comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "[spinsertar_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipo_comprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Venta.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Venta.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Venta.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParItbis = new SqlParameter();
                ParItbis.ParameterName = "@itbis";
                ParItbis.SqlDbType = SqlDbType.Decimal;
                ParItbis.Scale = 2;
                ParItbis.Precision = 4;
                ParItbis.Value = Venta.Itbis;
                SqlCmd.Parameters.Add(ParItbis);


                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";

                if (rpta.Equals("Ok"))
                {
                    //Obtener el codigo (Id) del ingreso generado
                    IdVenta = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);
                    foreach (DdetalleVenta item in Detalle)
                    {
                        item.IdVenta = IdVenta;
                        //Llamar al mentodo Insertar de la Clase DdetalleIngreso
                        rpta = item.Insertar(item, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("Ok"))
                        {
                            break;
                        }
                        else //Si se insertan los detalles de ventas actualizamos el stock
                        {
                            rpta = DisminuirStock(item.IdDetalleIngreso, item.Cantidad);
                            if (rpta.Equals("Ok"))
                            {
                                break;
                            }
                        }
                    }


                }
                if (rpta.Equals("Ok"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }
        #endregion


        #region MetodoEliminar
        //Metodo Anular
        public string Eliminar(Dventa Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Asignar y abrir StringConnection
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCon.Open();

                //Establecer el comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdIVenta = new SqlParameter();
                ParIdIVenta.ParameterName = "@idventa";
                ParIdIVenta.SqlDbType = SqlDbType.Int;
                ParIdIVenta.Value = Venta.IdVenta;
                SqlCmd.Parameters.Add(ParIdIVenta);


                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "Ok";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        #endregion


        #region MetodoMostrar
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;


        }
        #endregion


        #region MetodoFechas
        //Metodo BuscarNombre
        public DataTable BuscarFechas(string fechaInicio, string FechaFin)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_venta_fecha]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.VarChar;
                ParFechaInicio.Size = 20;
                ParFechaInicio.Value = fechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechaFin";
                ParFechaFin.SqlDbType = SqlDbType.VarChar;
                ParFechaFin.Size = 20;
                ParFechaFin.Value = FechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion


        #region MetodoMostrarDetalles
        //Metodo BuscarNombre
        public DataTable MostrarDetalles(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_detalle_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Value = textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion


        #region BuscarAritculoVentaNombre
        //Metodo BuscarNombre
        public DataTable BuscarAritculoVentaNombre(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("articulos");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscararticulo_venta_nombre]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Value = textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion


        #region BuscarAritculoVentaCodigo
        //Metodo BuscarNombre
        public DataTable BuscarAritculoVentaCodigo(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("articulos");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscararticulo_venta_codigo]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Value = textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

    }
}
