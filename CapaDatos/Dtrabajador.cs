using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dtrabajador
    {

        #region Contructores
        public Dtrabajador() { }

        public Dtrabajador(int idTabajador, string nombre, string apellido, string sexo, DateTime fechaNacimiento,
            string numeroDocumento, string direccion, string telefono, string email, string acceso, string usuario, string password, string textoBuscar)
        {

            IdTrabajador = idTabajador;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            FechaNacimiento = fechaNacimiento;
            NumeroDocumento = numeroDocumento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Acceso = acceso;
            Usuario = usuario;
            Password = password;
            TextoBuscar = textoBuscar;
        }
        #endregion


        #region Propiedades

        public int IdTrabajador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Acceso { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string TextoBuscar { get; set; }

        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(Dtrabajador Trabajador)
        {

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_trabajador]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdTrabajador = new SqlParameter("@idtrabajador", SqlDbType.Int);
                parIdTrabajador.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdTrabajador);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 20);
                parNombre.Value = Trabajador.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parApellido = new SqlParameter("@apellidos", SqlDbType.VarChar, 40);
                parApellido.Value = Trabajador.Apellido;
                comandoSql.Parameters.Add(parApellido);

                var parSexo = new SqlParameter("@sexo", SqlDbType.VarChar, 1);
                parSexo.Value = Trabajador.Sexo;
                comandoSql.Parameters.Add(parSexo);

                var parFechaNacimiento = new SqlParameter("@fecha_nacimiento", SqlDbType.Date);
                parFechaNacimiento.Value = Trabajador.FechaNacimiento;
                comandoSql.Parameters.Add(parFechaNacimiento);

                var parNumDocumento = new SqlParameter("@num_documento", SqlDbType.VarChar, 8);
                parNumDocumento.Value = Trabajador.NumeroDocumento;
                comandoSql.Parameters.Add(parNumDocumento);

                var parDireccion = new SqlParameter("@direccion", SqlDbType.VarChar, 100);
                parDireccion.Value = Trabajador.Direccion;
                comandoSql.Parameters.Add(parDireccion);

                var parTelefono = new SqlParameter("@telefono", SqlDbType.VarChar, 12);
                parTelefono.Value = Trabajador.Telefono;
                comandoSql.Parameters.Add(parTelefono);

                var parEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
                parEmail.Value = Trabajador.Email;
                comandoSql.Parameters.Add(parEmail);

                var parAcceso = new SqlParameter("@acceso", SqlDbType.VarChar, 20);
                parAcceso.Value = Trabajador.Acceso;
                comandoSql.Parameters.Add(parAcceso);

                var parUsuario = new SqlParameter("@usuario", SqlDbType.VarChar, 20);
                parUsuario.Value = Trabajador.Usuario;
                comandoSql.Parameters.Add(parUsuario);

                var parPassword = new SqlParameter("@password", SqlDbType.VarChar, 500);
                parPassword.Value = Utilidades.GenerarHash(Trabajador.Password, Utilidades.GenerarSalt());
                comandoSql.Parameters.Add(parPassword);

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
        public string Editar(Dtrabajador Trabajador)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speditar_trabajador]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdTrabajador = new SqlParameter("@idtrabajador", SqlDbType.Int);
                parIdTrabajador.Value = Trabajador.IdTrabajador;
                comandoSql.Parameters.Add(parIdTrabajador);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 20);
                parNombre.Value = Trabajador.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parApellido = new SqlParameter("@apellidos", SqlDbType.VarChar, 40);
                parApellido.Value = Trabajador.Apellido;
                comandoSql.Parameters.Add(parApellido);

                var parSexo = new SqlParameter("@sexo", SqlDbType.VarChar, 1);
                parSexo.Value = Trabajador.Sexo;
                comandoSql.Parameters.Add(parSexo);

                var parFechaNacimiento = new SqlParameter("@fecha_nacimiento", SqlDbType.Date);
                parFechaNacimiento.Value = Trabajador.FechaNacimiento;
                comandoSql.Parameters.Add(parFechaNacimiento);

                var parNumDocumento = new SqlParameter("@num_documento", SqlDbType.VarChar, 8);
                parNumDocumento.Value = Trabajador.NumeroDocumento;
                comandoSql.Parameters.Add(parNumDocumento);

                var parDireccion = new SqlParameter("@direccion", SqlDbType.VarChar, 100);
                parDireccion.Value = Trabajador.Direccion;
                comandoSql.Parameters.Add(parDireccion);

                var parTelefono = new SqlParameter("@telefono", SqlDbType.VarChar, 12);
                parTelefono.Value = Trabajador.Telefono;
                comandoSql.Parameters.Add(parTelefono);

                var parEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
                parEmail.Value = Trabajador.Email;
                comandoSql.Parameters.Add(parEmail);

                var parAcceso = new SqlParameter("@acceso", SqlDbType.VarChar, 20);
                parAcceso.Value = Trabajador.Acceso;
                comandoSql.Parameters.Add(parAcceso);

                var parUsuario = new SqlParameter("@usuario", SqlDbType.VarChar, 20);
                parUsuario.Value = Trabajador.Usuario;
                comandoSql.Parameters.Add(parUsuario);

                var parPassword = new SqlParameter("@password", SqlDbType.VarChar, 500);
                parPassword.Value = Utilidades.GenerarHash(Trabajador.Password, Utilidades.GenerarSalt());
                comandoSql.Parameters.Add(parPassword);

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
        public string Eliminar(Dtrabajador Cliente)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_trabajador]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdTrabajador = new SqlParameter("@idtrabajador", SqlDbType.Int);
                parIdTrabajador.Value = Cliente.IdTrabajador;
                comandoSql.Parameters.Add(parIdTrabajador);


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
            var resultadoTabla = new DataTable("trabajador");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spmostrar_trabajador]", conexionSql);
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


        #region MetodoBuscarNombre
        //Metodo BuscarNombre
        public DataTable BuscarNombre(Dtrabajador Trabajador)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("trabajador");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_trabajador_nombres]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 11);
                parTextoBuscar.Value = Trabajador.TextoBuscar;
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


        #region MetodoBuscarApellido
        //Metodo BuscarNombre
        public DataTable BuscarApellido(Dtrabajador Trabajador)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("trabajador");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                SqlCommand comandoSql = new SqlCommand("[spbuscar_trabajador_apellidos]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 11);
                parTextoBuscar.Value = Trabajador.TextoBuscar;
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


        #region MetodoBuscarNumDocumento
        //Metodo BuscarNombre
        public DataTable BuscarNumDocumento(Dtrabajador Trabajador)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("trabajador");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_trabajador_num_documento]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 11);
                parTextoBuscar.Value = Trabajador.TextoBuscar;
                comandoSql.Parameters.Add(parTextoBuscar);


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


        #region Login
        //Metodo BuscarNombre
        public DataTable Login(Dtrabajador Trabajador)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("trabajador");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {

                var comandoSql = new SqlCommand("[splogin]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parUsuario = new SqlParameter("@usuario", SqlDbType.VarChar, 20);
                parUsuario.Value = Trabajador.Usuario;
                comandoSql.Parameters.Add(parUsuario);


                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

                var hash = resultadoTabla.Rows[0][4].ToString();

                if (Utilidades.ValidarHash(Password, hash))
                {
                    return resultadoTabla;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
                resultadoTabla = null;
            }


            return resultadoTabla = null;
        }
        #endregion

    }
}
