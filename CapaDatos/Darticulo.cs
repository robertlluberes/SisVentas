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
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                // abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_articulo]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdArticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                parIdArticulo.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdArticulo);

                var parCodigo = new SqlParameter("@codigo", SqlDbType.VarChar, 50);
                parCodigo.Value = Articulo.Codigo;
                comandoSql.Parameters.Add(parCodigo);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Articulo.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parDescripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 24);
                parDescripcion.Value = Articulo.Descripcion;
                comandoSql.Parameters.Add(parDescripcion);

                var parImagen = new SqlParameter("@imagen", SqlDbType.Image);
                parImagen.Value = Articulo.Imagen;
                comandoSql.Parameters.Add(parImagen);

                var parIdCategoria = new SqlParameter("@idcategoria", SqlDbType.Int);
                parIdCategoria.Value = Articulo.IdCategoria;
                comandoSql.Parameters.Add(parIdCategoria);

                var parIdPresentacion = new SqlParameter("@idpresentacion", SqlDbType.Int);
                parIdPresentacion.Value = Articulo.IdPresentacion;
                comandoSql.Parameters.Add(parIdPresentacion);

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
        public string Editar(Darticulo Articulo)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speditar_articulo]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdArticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                parIdArticulo.Value = Articulo.IdArticulo;
                comandoSql.Parameters.Add(parIdArticulo);

                var parCodigo = new SqlParameter("@codigo", SqlDbType.VarChar, 50);
                parCodigo.Value = Articulo.Codigo;
                comandoSql.Parameters.Add(parCodigo);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Articulo.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parDescripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 24);
                parDescripcion.Value = Articulo.Descripcion;
                comandoSql.Parameters.Add(parDescripcion);

                var parImagen = new SqlParameter("@imagen", SqlDbType.Image);
                parImagen.Value = Articulo.Imagen;
                comandoSql.Parameters.Add(parImagen);

                var parIdCategoria = new SqlParameter("@idcategoria", SqlDbType.Int);
                parIdCategoria.Value = Articulo.IdCategoria;
                comandoSql.Parameters.Add(parIdCategoria);

                var parIdPresentacion = new SqlParameter("@idpresentacion", SqlDbType.Int);
                parIdPresentacion.Value = Articulo.IdPresentacion;
                comandoSql.Parameters.Add(parIdPresentacion);

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
        public string Eliminar(Darticulo Articulo)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_articulo]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdArticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                parIdArticulo.Value = Articulo.IdArticulo;
                comandoSql.Parameters.Add(parIdArticulo);


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
            var resultadoTabla = new DataTable("articulo");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {

                var comandoSql = new SqlCommand("[spmostrar_articulo]", conexionSql);
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
        public DataTable BuscarNombre(Darticulo Articulo)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("articulo");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {

                var comandoSql = new SqlCommand("[spbuscar_articulo_nombre]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var ParTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                ParTextoBuscar.Value = Articulo.TextoBuscar;
                comandoSql.Parameters.Add(ParTextoBuscar);


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


        #region MetodoStockArticulos
        //Metodo Mostrar
        public DataTable StockArticulos()
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("articulo");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spstock_articulos]", conexionSql);
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

    }
}
