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

            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_cliente]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdCliente = new SqlParameter("@idcliente", SqlDbType.Int);
                parIdCliente.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdCliente);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Cliente.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parApellido = new SqlParameter("@apellidos", SqlDbType.VarChar, 50);
                parApellido.Value = Cliente.Apellido;
                comandoSql.Parameters.Add(parApellido);

                var parSexo = new SqlParameter("@sexo", SqlDbType.VarChar, 1);
                parSexo.Value = Cliente.Sexo;
                comandoSql.Parameters.Add(parSexo);

                var parFechaNacimiento = new SqlParameter("@fecha_nacimiento", SqlDbType.Date);
                parFechaNacimiento.Value = Cliente.FechaNacimiento;
                comandoSql.Parameters.Add(parFechaNacimiento);

                var parTipoDocumento = new SqlParameter("@tipo_documento", SqlDbType.VarChar, 20);
                parTipoDocumento.Value = Cliente.TipoDocumento;
                comandoSql.Parameters.Add(parTipoDocumento);

                var parNumDocumento = new SqlParameter("@num_documento", SqlDbType.VarChar, 14);
                parNumDocumento.Value = Cliente.NumeroDocumento;
                comandoSql.Parameters.Add(parNumDocumento);

                var parDireccion = new SqlParameter("@direccion", SqlDbType.VarChar, 100);
                parDireccion.Value = Cliente.Direccion;
                comandoSql.Parameters.Add(parDireccion);

                var parTelefono = new SqlParameter("@telefono", SqlDbType.VarChar, 12);
                parTelefono.Value = Cliente.Telefono;
                comandoSql.Parameters.Add(parTelefono);

                var ParEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
                ParEmail.Value = Cliente.Email;
                comandoSql.Parameters.Add(ParEmail);

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
        public string Editar(Dcliente Cliente)
        {
            string respuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speditar_cliente]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdCliente = new SqlParameter("@idcliente", SqlDbType.Int);
                parIdCliente.Value = Cliente.IdCliente;
                comandoSql.Parameters.Add(parIdCliente);

                var parNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                parNombre.Value = Cliente.Nombre;
                comandoSql.Parameters.Add(parNombre);

                var parApellido = new SqlParameter("@apellidos", SqlDbType.VarChar, 50);
                parApellido.Value = Cliente.Apellido;
                comandoSql.Parameters.Add(parApellido);

                var parSexo = new SqlParameter("@sexo", SqlDbType.VarChar, 1);
                parSexo.Value = Cliente.Sexo;
                comandoSql.Parameters.Add(parSexo);

                var parFechaNacimiento = new SqlParameter("@fecha_nacimiento", SqlDbType.Date);
                parFechaNacimiento.Value = Cliente.FechaNacimiento;
                comandoSql.Parameters.Add(parFechaNacimiento);

                var parTipoDocumento = new SqlParameter("@tipo_documento", SqlDbType.VarChar, 20);
                parTipoDocumento.Value = Cliente.TipoDocumento;
                comandoSql.Parameters.Add(parTipoDocumento);

                var parNumDocumento = new SqlParameter("@num_documento", SqlDbType.VarChar, 14);
                parNumDocumento.Value = Cliente.NumeroDocumento;
                comandoSql.Parameters.Add(parNumDocumento);

                var parDireccion = new SqlParameter("@direccion", SqlDbType.VarChar, 100);
                parDireccion.Value = Cliente.Direccion;
                comandoSql.Parameters.Add(parDireccion);

                var parTelefono = new SqlParameter("@telefono", SqlDbType.VarChar, 12);
                parTelefono.Value = Cliente.Telefono;
                comandoSql.Parameters.Add(parTelefono);

                var parEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
                parEmail.Value = Cliente.Email;
                comandoSql.Parameters.Add(parEmail);

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
        public string Eliminar(Dcliente Cliente)
        {
            string repuesta = "";
            var conexionSql = new SqlConnection(Utilidades.conexion);

            try
            {
                //Abrir StringConnection
                conexionSql.Open();

                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[speliminar_cliente]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdCliente = new SqlParameter("@idcliente", SqlDbType.Int);
                parIdCliente.Value = Cliente.IdCliente;
                comandoSql.Parameters.Add(parIdCliente);


                //Ejecucion del comando
                repuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo eliminar el registro";


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


        #region MetodoMostrar
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("cliente");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                SqlCommand comandoSql = new SqlCommand("[spmostrar_cliente]", conexionSql);
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
        public DataTable BuscarNombre(Dcliente Cliente)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("cliente");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {
                var comandoSql = new SqlCommand("[spbuscar_cliente_nombres]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Cliente.TextoBuscar;
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
        public DataTable BuscarApellido(Dcliente Cliente)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("cliente");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {

                var comandoSql = new SqlCommand("[spbuscar_cliente_apellidos]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Cliente.TextoBuscar;
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
        public DataTable BuscarNumDocumento(Dcliente Cliente)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("cliente");
            var conexionSql = new SqlConnection(Utilidades.conexion);


            try
            {

                var comandoSql = new SqlCommand("[spbuscar_cliente_num_documento]", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros
                var parTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar, 50);
                parTextoBuscar.Value = Cliente.TextoBuscar;
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


    }
}
