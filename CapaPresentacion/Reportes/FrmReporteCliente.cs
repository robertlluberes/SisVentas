using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteCliente : Form
    {
        public FrmReporteCliente()
        {
            InitializeComponent();
        }

        private void FrmReporteCliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spmostrar_cliente' table. You can move, or remove it, as needed.
            try
            {
                this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
                var configuracionPagina = new PageSettings();
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
