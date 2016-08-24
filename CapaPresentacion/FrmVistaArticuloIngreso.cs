using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVistaArticuloIngreso : Form
    {
        public FrmVistaArticuloIngreso()
        {
            InitializeComponent();
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = Narticulo.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = Narticulo.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[1].Visible = false;
            dataListado.Columns[6].Visible = false;
            dataListado.Columns[8].Visible = false;
        }

        private void FrmVistaArticuloIngreso_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            var frm = FrmIngreso.GetInstancia();
            string idArticulo;
            string nombreArticulo;

            idArticulo = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            nombreArticulo = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);

            frm.SetArticulo(idArticulo, nombreArticulo);
            Hide();

        }
    }
}
