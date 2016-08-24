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
                SqlCmd.CommandText = "[spinsertar_proveedor]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razon_social";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 50;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 12;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 100;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Editar(Dproveedor Proveedor)
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
                SqlCmd.CommandText = "[speditar_proveedor]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razon_social";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 50;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 12;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 100;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Eliminar(Dproveedor Proveedor)
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
                SqlCmd.CommandText = "[speliminar_proveedor]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);


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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_proveedor]";
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


        #region Metodo BuscarRazonSocial
        //Metodo BuscarNombre
        public DataTable BuscarRazonSocial(Dproveedor Proveedor)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_proveedor_razon_social]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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


        #region Metodo BuscarProveedorDocumento
        //Metodo BuscarNombre
        public DataTable BuscarProveedorDocumento(Dproveedor Proveedor)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_proveedor_num_documento]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
