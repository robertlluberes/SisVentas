using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteProveedor : Form
    {
        public FrmReporteProveedor()
        {
            InitializeComponent();
        }

        private void FrmReporteProveedor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spmostrar_proveedor' table. You can move, or remove it, as needed.
            try
            {

                var configuracionPagina = new PageSettings();
                this.spmostrar_proveedorTableAdapter.Fill(this.dsPrincipal.spmostrar_proveedor);
                configuracionPagina.Margins.Top = 0;
                configuracionPagina.Margins.Right = 0;
                configuracionPagina.Margins.Bottom = 0;
                configuracionPagina.Margins.Left = 0;

                reportViewer1.SetPageSettings(configuracionPagina);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
