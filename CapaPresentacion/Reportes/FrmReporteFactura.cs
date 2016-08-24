using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteFactura : Form
    {
        public int IdVenta { get; set; }
        public FrmReporteFactura()
        {
            InitializeComponent();
        }

        private void FrmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spreporte_factura' table. You can move, or remove it, as needed.


            try
            {
                spreporte_facturaTableAdapter.Fill(dsPrincipal.spreporte_factura, IdVenta);

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
