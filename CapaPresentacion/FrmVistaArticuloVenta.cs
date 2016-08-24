using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVistaArticuloVenta : Form
    {
        public FrmVistaArticuloVenta()
        {
            InitializeComponent();
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            if (dataListado.Rows.Count > 0)
            {
                dataListado.Columns[0].Visible = false;
            }
        }
        //Metodo 
        private void MostrarArticuloVentaNombre()
        {
            dataListado.DataSource = NVenta.BuscarArticuloVentaNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void MostrarArticuloVentaCodigo()
        {
            dataListado.DataSource = NVenta.BuscarAritculoVentaCodigo(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void FrmVistaArticuloVenta_Load(object sender, System.EventArgs e)
        {
            MostrarArticuloVentaNombre();
        }

        private void txtBuscar_TextChanged(object sender, System.EventArgs e)
        {
            if (cbBuscar.Text == "Nombre")
            {
                MostrarArticuloVentaNombre();
            }
            else if (cbBuscar.Text == "Codigo")
            {
                MostrarArticuloVentaCodigo();
            }
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            if (cbBuscar.Text == "Nombre")
            {
                MostrarArticuloVentaNombre();
            }
            else if (cbBuscar.Text == "Codigo")
            {
                MostrarArticuloVentaCodigo();
            }
        }

        private void dataListado_DoubleClick(object sender, System.EventArgs e)
        {
            FrmVenta formulario = FrmVenta.GetInstancia();

            string idDetalleIngreso;
            string nombreArticulo;
            decimal precioCompra;
            decimal precioVenta;
            int stock;
            DateTime fechaVencimiento;

            idDetalleIngreso = Convert.ToString(dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            nombreArticulo = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            precioCompra = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_compra"].Value);
            precioVenta = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_venta"].Value);
            stock = Convert.ToInt32(dataListado.CurrentRow.Cells["stock_actual"].Value);
            fechaVencimiento = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);

            formulario.SetArticulo(idDetalleIngreso, nombreArticulo, precioCompra, precioVenta, stock, fechaVencimiento);

            Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
