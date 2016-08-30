using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dcategoria
    {

        #region Contructores
        //Constructor vacio
        public Dcategoria()
        {
        }

        //Constructor con parametros
        public Dcategoria(int idCategoria, string nombre, string descripcion, string textoBuscar)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
            Descripcion = descripcion;
            TextoBuscar = textoBuscar;
        }
        #endregion


        #region Propiedades
        //Propiedades.
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TextoBuscar { get; set; }



        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dcategoria Categoria)
        {

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                // abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_categoria]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdCategoria = new SqlParameter("@idcategoria", SqlDbType.Int);
                parIdCategoria.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdCategoria);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Categoria.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parDescripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 256);
                parDescripcion.Value = Categoria.Descripcion;
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
        public string Editar(Dcategoria Categoria)
        {
            string repuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Asignar y abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speditar_categoria]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdCategoria = new SqlParameter("@idcategoria", SqlDbType.Int);
                parIdCategoria.Value = Categoria.IdCategoria;
                comandoSql.Parameters.Add(parIdCategoria);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Categoria.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parDescripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 256);
                parDescripcion.Value = Categoria.Descripcion;
                comandoSql.Parameters.Add(parDescripcion);

                //Ejecucion del comando
                repuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo editar el registro";


            }
            catch (Exception ex)
            {
                repuesta = ex.Message;
            }
            finally
            {
                if (conexionSql.State == ConnectionState.Open)
                    conexionSql.Close();
            }

            return repuesta;

        }
        #endregion


        #region MetodoEliminar
        //Metodo Eliminar
        public string Eliminar(Dcategoria Categoria)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_categoria]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var ParIdCategoria = new SqlParameter("@idcategoria", SqlDbType.Int);
                ParIdCategoria.Value = Categoria.IdCategoria;
                comandoSql.Parameters.Add(ParIdCategoria);


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
            var resultadoTabla = new DataTable("categoria");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {

                var comandoSql = new SqlCommand("[spmostrar_categoria]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                var sqlDat = new SqlDataAdapter(comandoSql);
                sqlDat.Fill(resultadoTabla);

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
        public DataTable BuscarNombre(Dcategoria Cateria)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("categoria");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_categoria]", conexionSql); ;
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Cateria.TextoBuscar;
                comandoSql.Parameters.Add(parTextoBuscar);


                var sqlDat = new SqlDataAdapter(comandoSql);
                sqlDat.Fill(resultadoTabla);

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
