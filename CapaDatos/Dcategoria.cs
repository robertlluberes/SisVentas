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
                SqlCmd.CommandText = "[spinsertar_categoria]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";


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


        #region MetodoEditar
        //Metodo Editar
        public string Editar(Dcategoria Categoria)
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
                SqlCmd.CommandText = "[speditar_categoria]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo editar el registro";


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
        //Metodo Eliminar
        public string Eliminar(Dcategoria Categoria)
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
                SqlCmd.CommandText = "[speliminar_categoria]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);


                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo eliminar el registro";


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
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_categoria]";
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


        #region MetodoBuscarNombre
        //Metodo BuscarNombre
        public DataTable BuscarNombre(Dcategoria Cateria)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_categoria]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cateria.TextoBuscar;
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
