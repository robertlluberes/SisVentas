using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(cbBuscar, "Seleccione el criterio por el cual desea buscar");
            ttMensaje.SetToolTip(cbTipoDocumento, "Seleccione el documento de identidad a registrar del proveedor");
        }
        private bool isNuevo = false; //Para identificar si se agregara un proveedor
        private bool isEditar = false; //Para identificar si se Editara un proveedor


        //Limpiar contoles
        private void Limpiar()
        {
            txtRazonSocial.Clear(); ;
            txtNumDocumento.Clear();
            txtIdProveedor.Clear();
            txtDireccion.Clear();
            mtxtTelefono.Clear();
            txtEmail.Clear();
            txtUrl.Clear();
            cbTipoDocumento.Text = "";
            cbSectorComercial.Text = "";
            txtRazonSocial.Focus();

        }

        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtRazonSocial.ReadOnly = !valor;
            cbSectorComercial.Enabled = valor;
            cbTipoDocumento.Enabled = valor;
            txtNumDocumento.ReadOnly = !valor;
            txtDireccion.ReadOnly = !valor;
            mtxtTelefono.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            txtUrl.ReadOnly = !valor;
        }


        //Habilitar los botones
        private void HabilitarBotones()
        {
            if (isEditar || isNuevo)
            {
                HabilitarControles(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                HabilitarControles(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
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

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            Mostrar();
            HabilitarBotones();
            HabilitarControles(false);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea eliminar el/los proveedores seleccionados?",
                    "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int IdProveedor = 0;
                    string respuesta = "";

                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            IdProveedor = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Nproveedor.Eliminar(IdProveedor);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("El/los proveedor/es se eleminaron correctamente.");
                            }
                            else
                            {
                                Utilidades.MensajeError(respuesta);
                            }
                        }
                    }
                    Mostrar();
                    chkEliminar.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            isNuevo = true;
            isEditar = false;
            Limpiar();
            HabilitarBotones();
            HabilitarControles(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                if (txtRazonSocial.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtRazonSocial, "Ingrese la razón social del proveedor");
                }
                else if (txtNumDocumento.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtNumDocumento, "Ingrese el número de documento");

                }
                else if (txtDireccion.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtDireccion, "Ingrese la dirección del proveedor");

                }
                else
                {
                    if (isNuevo)
                    {
                        respuesta = Nproveedor.Insertar(txtRazonSocial.Text.Trim().ToUpper(), cbSectorComercial.Text,
                            cbTipoDocumento.Text, txtNumDocumento.Text, txtDireccion.Text, mtxtTelefono.Text, txtEmail.Text, txtUrl.Text);
                    }
                    else
                    {
                        respuesta = Nproveedor.Editar(Convert.ToInt32(txtIdProveedor.Text), txtRazonSocial.Text.Trim().ToUpper(), cbSectorComercial.Text,
                            cbTipoDocumento.Text, txtNumDocumento.Text, txtDireccion.Text, mtxtTelefono.Text, txtEmail.Text, txtUrl.Text);
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("El proveedor se agregó correctamente");
                        }
                        else
                        {
                            Utilidades.MensajeOK("La proveedor se editó correctamente");
                        }
                    }
                    else
                    {
                        Utilidades.MensajeError(respuesta);
                    }
                    isNuevo = false;
                    isEditar = false;
                    HabilitarBotones();
                    Limpiar();
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdProveedor.Text.Equals(""))
            {
                isEditar = true;
                HabilitarBotones();
                HabilitarControles(true);
            }
            else
            {
                Utilidades.MensajeError("Debe seleccionar primero un registro a editar desde la pestaña Listado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            isNuevo = false;
            isEditar = false;
            HabilitarControles(false);
            HabilitarBotones();
            Limpiar();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdProveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            txtRazonSocial.Text = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
            cbSectorComercial.Text = Convert.ToString(dataListado.CurrentRow.Cells["sector_comercial"].Value);
            cbTipoDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_documento"].Value);
            txtNumDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
            mtxtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);

            tabControl1.SelectTab(1);
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var formulario = new FrmReporteProveedor();
            formulario.Show();
        }
    }
}
