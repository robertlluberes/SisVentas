using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dingreso
    {
        #region Constructores
        public Dingreso()
        {

        }

        public Dingreso(int idIngreso, int idTrabajador, int idProveedor, DateTime fecha, string tipoComprobante, string serie, string correlativo, decimal itbis, string estado)
        {
            IdIngreso = idIngreso;
            IdTrabajador = idTrabajador;
            IdProveedor = idProveedor;
            Fecha = fecha;
            TipoComprobante = tipoComprobante;
            Serie = serie;
            Correlativo = correlativo;
            Itbis = itbis;
            Estado = estado;
        }
        #endregion


        #region Propiedades
        public int IdIngreso { get; set; }
        public int IdTrabajador { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal Itbis { get; set; }
        public string Estado { get; set; }


        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dingreso Ingreso, List<DdetalleIngreso> Detalle)
        {

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer la transaccion
                SqlTransaction transaccionSql = conexionSql.BeginTransaction();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_ingreso]", conexionSql, transaccionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdIngreso = new SqlParameter("@idingreso", SqlDbType.Int);
                parIdIngreso.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdIngreso);

                var parIdTrabajador = new SqlParameter("@idtrabajador", SqlDbType.Int);
                parIdTrabajador.Value = Ingreso.IdTrabajador;
                comandoSql.Parameters.Add(parIdTrabajador);

                var parIdProveedor = new SqlParameter("@idproveedor", SqlDbType.Int);
                parIdProveedor.Value = Ingreso.IdProveedor;
                comandoSql.Parameters.Add(parIdProveedor);

                var parFecha = new SqlParameter("@fecha", SqlDbType.Date);
                parFecha.Value = Ingreso.Fecha;
                comandoSql.Parameters.Add(parFecha);

                var parTipoComprobante = new SqlParameter("@tipo_comprobante", SqlDbType.VarChar, 20);
                parTipoComprobante.Value = Ingreso.TipoComprobante;
                comandoSql.Parameters.Add(parTipoComprobante);

                var parSerie = new SqlParameter("@serie", SqlDbType.VarChar, 4);
                parSerie.Value = Ingreso.Serie;
                comandoSql.Parameters.Add(parSerie);

                var parCorrelativo = new SqlParameter("@correlativo", SqlDbType.VarChar, 7);
                parCorrelativo.Value = Ingreso.Correlativo;
                comandoSql.Parameters.Add(parCorrelativo);

                var parItbis = new SqlParameter("@itbis", SqlDbType.Decimal);
                parItbis.Scale = 2;
                parItbis.Precision = 4;
                parItbis.Value = Ingreso.Itbis;
                comandoSql.Parameters.Add(parItbis);

                var parEstado = new SqlParameter("@estado", SqlDbType.VarChar, 7);
                parEstado.Value = Ingreso.Estado;
                comandoSql.Parameters.Add(parEstado);

                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";

                if (respuesta.Equals("Ok"))
                {
                    //Obtener el codigo (Id) del ingreso generado
                    IdIngreso = Convert.ToInt32(comandoSql.Parameters["@idingreso"].Value);
                    foreach (DdetalleIngreso item in Detalle)
                    {
                        item.IdIngreso = IdIngreso;
                        //Llamar al mentodo Insertar de la Clase DdetalleIngreso
                        respuesta = item.Insertar(item, ref conexionSql, ref transaccionSql);
                        if (!respuesta.Equals("Ok"))
                        {
                            break;
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


        #region MetodoAnular
        //Metodo Anular
        public string Anular(Dingreso Ingreso)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spanular_ingreso]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdIngreso = new SqlParameter("@idingreso", SqlDbType.Int);
                parIdIngreso.Value = Ingreso.IdIngreso;
                comandoSql.Parameters.Add(parIdIngreso);


                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo anular el registro";


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
            DataTable resultadoTabla = new DataTable("ingreso");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spmostrar_ingreso]", conexionSql);
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
            var resultadoTabla = new DataTable("ingreso");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_ingreso_fecha]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parFechaInicio = new SqlParameter("@fechaInicio", SqlDbType.VarChar, 20);
                parFechaInicio.Value = fechaInicio;
                comandoSql.Parameters.Add(parFechaInicio);

                var parFechaFin = new SqlParameter("@fechaFin", SqlDbType.VarChar, 20);
                parFechaFin.Value = FechaFin;
                comandoSql.Parameters.Add(parFechaFin);


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


        #region MetodoMostrarDetalles
        //Metodo BuscarNombre
        public DataTable MostrarDetalles(string textoBuscar)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("detalle_ingreso");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                SqlCommand comandoSql = new SqlCommand("[spmostrar_detalle_ingreso]", conexionSql);
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

    }
}
