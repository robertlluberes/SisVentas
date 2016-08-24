using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Utilidades
    {
        //cadena de conexion
        public static String conexion = CapaDatos.Properties.Settings.Default.cn;


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

        public static string BackupBasedeDatos(string rutaBackup)
        {
            try
            {
                var sqlCon = new SqlConnection(conexion);
                sqlCon.Open();

                var comando = new SqlCommand("[spbackup]", sqlCon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                var ParRuta = new SqlParameter();
                ParRuta.ParameterName = "@ruta";
                ParRuta.DbType = System.Data.DbType.String;
                ParRuta.Size = 255;
                ParRuta.Value = rutaBackup;

                comando.Parameters.Add(ParRuta);

                var rpta = comando.ExecuteNonQuery() == -1 ? "Ok" : "No se proces el backup:";
                sqlCon.Close();

                return rpta.ToString();
            }
            catch (Exception ex)
            {

                return $"No se procesó el backup: \n{ex.Message}";
            }

        }


    }
}