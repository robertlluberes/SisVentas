using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVistaProveedorIngreso : Form
    {
        public FrmVistaProveedorIngreso()
        {
            InitializeComponent();
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[1].Visible = false;
        }
        //Metodo Mostrar Presentaciones
        private void Mostrar()
        {
            dataListado.DataSource = Nproveedor.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarRazonSocial
        private void BuscarRazonSocial()
        {
            dataListado.DataSource = Nproveedor.BuscarRazonSocial(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNumDocumento
        private void BuscarNumDocumento()
        {
            dataListado.DataSource = Nproveedor.BuscarProveedorDocumento(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void FrmVistaProveedorIngreso_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            var frm = FrmIngreso.GetInstancia();
            string nombreProveedor;
            string idProveedor;

            idProveedor = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            nombreProveedor = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);

            frm.SetProveedor(idProveedor, nombreProveedor);
            Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazonSocial();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNumDocumento();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazonSocial();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNumDocumento();
            }
        }
    }
}
