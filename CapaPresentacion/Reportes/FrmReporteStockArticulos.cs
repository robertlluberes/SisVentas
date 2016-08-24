using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteStockArticulos : Form
    {
        public FrmReporteStockArticulos()
        {
            InitializeComponent();
        }

        private void FrmReporteStockArticulos_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'dsPrincipal.spstock_articulos' table. You can move, or remove it, as needed.
            try
            {
                this.spstock_articulosTableAdapter.Fill(this.dsPrincipal.spstock_articulos);

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
                this.reportViewer1.RefreshReport();
                Utilidades.MensajeError(ex.Message);
            }

        }
    }
}
