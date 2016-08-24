using CapaDatos;

namespace CapaNegocio
{
    public class NbackupBD
    {
        public string BackupBasedeDatos(string rutaBackup)
        {

            return Utilidades.BackupBasedeDatos(rutaBackup);
        }
    }
}
