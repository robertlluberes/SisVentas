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
                SqlCmd.CommandText = "[spinsertar_ingreso]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Ingreso.IdTrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipo_comprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ingreso.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParItbis = new SqlParameter();
                ParItbis.ParameterName = "@itbis";
                ParItbis.SqlDbType = SqlDbType.Decimal;
                ParItbis.Scale = 2;
                ParItbis.Precision = 4;
                ParItbis.Value = Ingreso.Itbis;
                SqlCmd.Parameters.Add(ParItbis);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";

                if (rpta.Equals("Ok"))
                {
                    //Obtener el codigo (Id) del ingreso generado
                    IdIngreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach (DdetalleIngreso item in Detalle)
                    {
                        item.IdIngreso = IdIngreso;
                        //Llamar al mentodo Insertar de la Clase DdetalleIngreso
                        rpta = item.Insertar(item, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("Ok"))
                        {
                            break;
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


        #region MetodoAnular
        //Metodo Anular
        public string Anular(Dingreso Ingreso)
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
                SqlCmd.CommandText = "[spanular_ingreso]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.IdIngreso;
                SqlCmd.Parameters.Add(ParIdIngreso);


                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo anular el registro";


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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_ingreso]";
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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_ingreso_fecha]";
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
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_detalle_ingreso]";
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
