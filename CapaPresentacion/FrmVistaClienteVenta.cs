using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVistaClienteVenta : Form
    {
        public FrmVistaClienteVenta()
        {
            InitializeComponent();
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
        }
        //Metodo Mostrar Presentaciones
        private void Mostrar()
        {
            dataListado.DataSource = Ncliente.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = Ncliente.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarApellido
        private void BuscarApellido()
        {
            dataListado.DataSource = Ncliente.BuscarApellido(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNumDocumento
        private void BuscarNumDocumento()
        {
            dataListado.DataSource = Ncliente.BuscarNumDocumento(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void FrmVistaClienteVenta_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Nombre"))
            {
                BuscarNombre();
            }
            else if (cbBuscar.Text.Equals("Apellido"))
            {
                BuscarApellido();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNumDocumento();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Nombre"))
            {
                BuscarNombre();
            }
            else if (cbBuscar.Text.Equals("Apellido"))
            {
                BuscarApellido();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNumDocumento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta formulario = FrmVenta.GetInstancia();

            string nombreApellido;
            string idCliente;

            idCliente = Convert.ToString(dataListado.CurrentRow.Cells["idcliente"].Value);
            nombreApellido = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value) + " " +
                Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value);

            formulario.SetCliente(idCliente, nombreApellido);

            Hide();

        }
    }
}
