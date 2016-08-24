using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteCategorias : Form
    {
        public FrmReporteCategorias()
        {
            InitializeComponent();
        }

        private void FrmReporteCategorias_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spmostrar_categoria' table. You can move, or remove it, as needed.
            try
            {
                this.spmostrar_categoriaTableAdapter.Fill(this.dsPrincipal.spmostrar_categoria);

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
