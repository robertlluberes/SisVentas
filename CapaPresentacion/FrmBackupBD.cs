using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBackupBD : Form
    {
        public FrmBackupBD()
        {
            InitializeComponent();
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                var archivoBackup = new SaveFileDialog();
                archivoBackup.Title = "Seleccione la ruta...";
                archivoBackup.Filter = "SQL Backup (*.bak)| *.bak";

                if (archivoBackup.ShowDialog() == DialogResult.OK)
                {
                    txtRutaBackup.Text = archivoBackup.FileName.ToString();
                }
            }
            catch (Exception ex)
            {

                Utilidades.MensajeError(ex.Message + ex.StackTrace);
            }

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            var Obj = new NbackupBD();
            var respuesta = Obj.BackupBasedeDatos(txtRutaBackup.Text);

            if (respuesta == "Ok")
            {
                Utilidades.MensajeOK("Bakcup realizado satisfactoriamente");
            }
            else
            {
                Utilidades.MensajeError(respuesta);
            }
        }
    }
}
