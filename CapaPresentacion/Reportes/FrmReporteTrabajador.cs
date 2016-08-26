using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteTrabajador : Form
    {
        public FrmReporteTrabajador()
        {
            InitializeComponent();
        }

        private void FrmReporteTrabajador_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spmostrar_trabajador' table. You can move, or remove it, as needed.
            try
            {
                var configuracionPagina = new PageSettings();
                configuracionPagina.Margins.Top = 0;
                configuracionPagina.Margins.Right = 0;
                configuracionPagina.Margins.Bottom = 0;
                configuracionPagina.Margins.Left = 0;

                reportViewer1.SetPageSettings(configuracionPagina);
                this.spmostrar_trabajadorTableAdapter.Fill(this.dsPrincipal.spmostrar_trabajador);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();

                MessageBox.Show(ex.Message);
            }
        }
    }
}
