using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteArticulos : Form
    {
        public FrmReporteArticulos()
        {
            InitializeComponent();
        }

        private void FrmReporteArticulos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spmostrar_articulo' table. You can move, or remove it, as needed.
            try
            {
                spmostrar_articuloTableAdapter.Fill(dsPrincipal.spmostrar_articulo);

                var configuracionPagina = new PageSettings();
                configuracionPagina.Margins.Top = 0;
                configuracionPagina.Margins.Right = 0;
                configuracionPagina.Margins.Bottom = 0;
                configuracionPagina.Margins.Left = 0;

                reportViewer1.SetPageSettings(configuracionPagina);
                reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                reportViewer1.RefreshReport();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
