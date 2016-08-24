using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Darticulo
    {
        #region Constructores
        public Darticulo() { }

        public Darticulo(int idarticulo, string codigo, string nombre, string descipcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            IdArticulo = idarticulo;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descipcion;
            Imagen = imagen;
            IdCategoria = idcategoria;
            IdPresentacion = idpresentacion;
            TextoBuscar = textobuscar;
        }
        #endregion


        #region Propiedades

        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public int IdCategoria { get; set; }
        public int IdPresentacion { get; set; }
        public string TextoBuscar { get; set; }

        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Darticulo Articulo)
        {

            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Utilidades.conexion);

            try
            {
                // abrir StringConnection
                SqlCon.Open();

                //Establecer el comando SQL
                SqlCommand SqlCmd = new SqlCommand("[spinsertar_articulo]", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 24;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.Value = Articulo.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Ejecion del comando
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return respuesta;
        }
        #endregion


        #region MetodoEditar
        //Metodo Editar
        public string Editar(Darticulo Articulo)
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
                SqlCmd.CommandText = "[speditar_articulo]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.Value = Articulo.IdArticulo;
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 24;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.Value = Articulo.IdPresentacion;
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdPresentacion);

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
        public string Eliminar(Darticulo Articulo)
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
                SqlCmd.CommandText = "[speliminar_articulo]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulo.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);


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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_articulo]";
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
        public DataTable BuscarNombre(Darticulo Articulo)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_articulo_nombre]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
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


        #region MetodoStockArticulos
        //Metodo Mostrar
        public DataTable StockArticulos()
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spstock_articulos]";
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

    }
}
