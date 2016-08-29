using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Utilidades
    {
        //cadena de conexion
        #region Cadena de Conexion
        public static String conexion = CapaDatos.Properties.Settings.Default.cn;
        #endregion


        #region Encriptacion

        public static string GenerarSalt()
        {

            return BCryptHelper.GenerateSalt();
        }

        public static string GenerarHash(string contrasena, string salt)
        {

            return BCryptHelper.HashPassword(contrasena, salt);
        }

        public static bool ValidarHash(string contrasena, string hashed)
        {
            return BCryptHelper.CheckPassword(contrasena, hashed);
        }

        #endregion


        #region Backup de la aplicacion
        public static string BackupBasedeDatos(string rutaBackup)
        {
            try
            {
                var conexionSql = new SqlConnection(conexion);
                conexionSql.Open();

                var comando = new SqlCommand("[spbackup]", conexionSql);
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                var parRuta = new SqlParameter();
                parRuta.ParameterName = "@ruta";
                parRuta.DbType = System.Data.DbType.String;
                parRuta.Size = 255;
                parRuta.Value = rutaBackup;

                comando.Parameters.Add(parRuta);

                var respuesta = comando.ExecuteNonQuery() == -1 ? "Ok" : "No se proces el backup:";
                conexionSql.Close();

                return respuesta.ToString();
            }
            catch (Exception ex)
            {

                return $"No se procesó el backup: \n{ex.Message}";
            }

        }
        #endregion


    }
}