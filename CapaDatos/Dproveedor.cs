using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dproveedor
    {
        #region Propiedades
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string SectorComercial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string TextoBuscar { get; set; }

        #endregion


        #region Constructores
        public Dproveedor()
        {
        }

        public Dproveedor(int idProveedor, string razonSocial, string sectorComercial, string tipoDocumento, string numDocumento, string direccion, string telefono, string email, string url, string textoBuscar)
        {
            IdProveedor = idProveedor;
            RazonSocial = razonSocial;
            SectorComercial = sectorComercial;
            TipoDocumento = tipoDocumento;
            NumDocumento = numDocumento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Url = url;
            TextoBuscar = textoBuscar;
        }
        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dproveedor Proveedor)
        {

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Asignar y abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                SqlCommand comandoSql = new SqlCommand("[spinsertar_proveedor]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdProveedor = new SqlParameter("@idproveedor", SqlDbType.Int);
                parIdProveedor.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdProveedor);

                var parRazonSocial = new SqlParameter("@razon_social", SqlDbType.VarChar, 50);
                parRazonSocial.Value = Proveedor.RazonSocial;
                comandoSql.Parameters.Add(parRazonSocial);

                var parSectorComercial = new SqlParameter("@sector_comercial", SqlDbType.VarChar, 50);
                parSectorComercial.Value = Proveedor.SectorComercial;
                comandoSql.Parameters.Add(parSectorComercial);

                var parTipoDocumento = new SqlParameter("@tipo_documento", SqlDbType.VarChar, 20);
                parTipoDocumento.Value = Proveedor.TipoDocumento;
                comandoSql.Parameters.Add(parTipoDocumento);

                var parNumDocumento = new SqlParameter("@num_documento", SqlDbType.VarChar, 11);
                parNumDocumento.Value = Proveedor.NumDocumento;
                comandoSql.Parameters.Add(parNumDocumento);

                var parDireccion = new SqlParameter("@direccion", SqlDbType.VarChar, 100);
                parDireccion.Value = Proveedor.Direccion;
                comandoSql.Parameters.Add(parDireccion);

                var parTelefono = new SqlParameter("@telefono", SqlDbType.VarChar, 12);
                parTelefono.Value = Proveedor.Telefono;
                comandoSql.Parameters.Add(parTelefono);

                var parEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
                parEmail.Value = Proveedor.Email;
                comandoSql.Parameters.Add(parEmail);

                var parUrl = new SqlParameter("@url", SqlDbType.VarChar, 100);
                parUrl.Value = Proveedor.Url;
                comandoSql.Parameters.Add(parUrl);

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
        public string Editar(Dproveedor Proveedor)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speditar_proveedor]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdProveedor = new SqlParameter("@idproveedor", SqlDbType.Int);
                parIdProveedor.Value = IdProveedor;
                comandoSql.Parameters.Add(parIdProveedor);

                var parRazonSocial = new SqlParameter("@razon_social", SqlDbType.VarChar, 50);
                parRazonSocial.Value = Proveedor.RazonSocial;
                comandoSql.Parameters.Add(parRazonSocial);

                var ParSectorComercial = new SqlParameter("@sector_comercial", SqlDbType.VarChar, 50);
                ParSectorComercial.Value = Proveedor.SectorComercial;
                comandoSql.Parameters.Add(ParSectorComercial);

                var parTipoDocumento = new SqlParameter("@tipo_documento", SqlDbType.VarChar, 20);
                parTipoDocumento.Value = Proveedor.TipoDocumento;
                comandoSql.Parameters.Add(parTipoDocumento);

                var parNumDocumento = new SqlParameter("@num_documento", SqlDbType.VarChar, 11);
                parNumDocumento.Value = Proveedor.NumDocumento;
                comandoSql.Parameters.Add(parNumDocumento);

                var parDireccion = new SqlParameter("@direccion", SqlDbType.VarChar, 100);
                parDireccion.Value = Proveedor.Direccion;
                comandoSql.Parameters.Add(parDireccion);

                var parTelefono = new SqlParameter("@telefono", SqlDbType.VarChar, 12);
                parTelefono.Value = Proveedor.Telefono;
                comandoSql.Parameters.Add(parTelefono);

                var parEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
                parEmail.Value = Proveedor.Email;
                comandoSql.Parameters.Add(parEmail);

                var parUrl = new SqlParameter("@url", SqlDbType.VarChar, 100);
                parUrl.Value = Proveedor.Url;
                comandoSql.Parameters.Add(parUrl);

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
        public string Eliminar(Dproveedor Proveedor)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_proveedor]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdProveedor = new SqlParameter("@idproveedor", SqlDbType.Int);
                parIdProveedor.Value = Proveedor.IdProveedor;
                comandoSql.Parameters.Add(parIdProveedor);


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
            DataTable resultadoTabla = new DataTable("proveedor");
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                SqlCommand comandoSql = new SqlCommand("[spmostrar_proveedor]", conexionSql);
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


        #region Metodo BuscarRazonSocial
        //Metodo BuscarNombre
        public DataTable BuscarRazonSocial(Dproveedor Proveedor)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("proveedor");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                SqlCommand comandoSql = new SqlCommand("[spbuscar_proveedor_razon_social]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Proveedor.TextoBuscar;
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


        #region Metodo BuscarProveedorDocumento
        //Metodo BuscarNombre
        public DataTable BuscarProveedorDocumento(Dproveedor Proveedor)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("proveedor");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_proveedor_num_documento]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Proveedor.TextoBuscar;
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
