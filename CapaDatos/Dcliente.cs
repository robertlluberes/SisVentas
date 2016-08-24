using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dcliente
    {

        #region Contructores
        public Dcliente()
        {
        }

        public Dcliente(int idCliente, string nombre, string apellido, string sexo, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string direccion, string telefono, string email, string textoBuscar)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            FechaNacimiento = fechaNacimiento;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            TextoBuscar = textoBuscar;
        }
        #endregion


        #region Propiedades

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string TextoBuscar { get; set; }


        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dcliente Cliente)
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
                SqlCmd.CommandText = "[spinsertar_cliente]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellidos";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Cliente.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fecha_nacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.Date;
                ParFechaNacimiento.Value = Cliente.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Cliente.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 14;
                ParNumDocumento.Value = Cliente.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 12;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Editar(Dcliente Cliente)
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
                SqlCmd.CommandText = "[speditar_cliente]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.Value = Cliente.IdCliente;
                ParIdCliente.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellidos";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Cliente.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fecha_nacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.Date;
                ParFechaNacimiento.Value = Cliente.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Cliente.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 14;
                ParNumDocumento.Value = Cliente.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 12;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Eliminar(Dcliente Cliente)
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
                SqlCmd.CommandText = "[speliminar_cliente]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);


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
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_cliente]";
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
        public DataTable BuscarNombre(Dcliente Cliente)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_cliente_nombres]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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


        #region MetodoBuscarApellido
        //Metodo BuscarNombre
        public DataTable BuscarApellido(Dcliente Cliente)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_cliente_apellidos]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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


        #region MetodoBuscarNumDocumento
        //Metodo BuscarNombre
        public DataTable BuscarNumDocumento(Dcliente Cliente)
        {
            //Cadena de conexion y DataTable (tabla)
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                SqlCon.ConnectionString = Utilidades.conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_cliente_num_documento]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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
