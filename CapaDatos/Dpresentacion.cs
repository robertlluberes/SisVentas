using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dpresentacion
    {
        #region Propiedades
        public int IdPresentacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TextoBuscar { get; set; }
        #endregion


        #region Constructores
        public Dpresentacion()
        {
        }

        public Dpresentacion(int idpresentacion, string nombre, string descricpcion, string textobuscar)
        {
            IdPresentacion = idpresentacion;
            Nombre = nombre;
            Descripcion = descricpcion;
            TextoBuscar = textobuscar;
        }
        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dpresentacion Presentacion)
        {

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_presentacion]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdPresentacion = new SqlParameter("@idpresentacion", SqlDbType.Int);
                parIdPresentacion.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdPresentacion);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Presentacion.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parDescripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 256);
                parDescripcion.Value = Presentacion.Descripcion;
                comandoSql.Parameters.Add(parDescripcion);

                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";


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


        #region MetodoEditar
        //Metodo Editar
        public string Editar(Dpresentacion Presentacion)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speditar_presentacion]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdPresentacion = new SqlParameter("@idpresentacion", SqlDbType.Int);
                parIdPresentacion.Value = Presentacion.IdPresentacion;
                comandoSql.Parameters.Add(parIdPresentacion);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Presentacion.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parDescripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 256);
                parDescripcion.Value = Presentacion.Descripcion;
                comandoSql.Parameters.Add(parDescripcion);

                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo editar el registro";


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
        //Metodo Eliminar
        public string Eliminar(Dpresentacion Presentacion)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_presentacion]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdPresentacion = new SqlParameter("@idpresentacion", SqlDbType.Int);
                parIdPresentacion.Value = Presentacion.IdPresentacion;
                comandoSql.Parameters.Add(parIdPresentacion);


                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo eliminar el registro";


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
            var resultadoTabla = new DataTable("presentacion");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spmostrar_presentacion]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

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


        #region MetodoBuscarNombre
        //Metodo BuscarNombre
        public DataTable BuscarNombre(Dpresentacion Presentacion)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("presentacion");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_presentacion_nombre]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Presentacion.TextoBuscar;
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
