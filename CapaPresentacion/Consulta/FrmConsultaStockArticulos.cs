using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Consulta
{
    public partial class FrmConsultaStockArticulos : Form
    {
        public FrmConsultaStockArticulos()
        {
            InitializeComponent();
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = Narticulo.StockArticulos();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void FrmConsultaStockArticulos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var formulario = new FrmReporteStockArticulos();
            formulario.Show();
        }
    }
}
