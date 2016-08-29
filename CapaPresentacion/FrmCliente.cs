using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCliente : Form
    {

        private bool isNuevo = false; //Para identificar si se agregara un cliente
        private bool isEditar = false; //Para identificar si se Editara un cliente

        public FrmCliente()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(cbBuscar, "Seleccione el criterio por el cual desea buscar");
            ttMensaje.SetToolTip(cbTipoDocumento, "Seleccione el documento de identidad a registrar el cliente");
        }

        //Limpiar contoles
        private void Limpiar()
        {
            txtIdCliente.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtNumDocumento.Clear();
            txtDireccion.Clear();
            mtxtTelefono.Clear();
            txtEmail.Clear();
            cbTipoDocumento.Text = "";
            cbSexo.Text = "";
            txtNombre.Focus();

        }

        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtApellido.ReadOnly = !valor;
            txtNumDocumento.ReadOnly = !valor;
            txtDireccion.ReadOnly = !valor;
            mtxtTelefono.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            cbSexo.Enabled = valor;
            cbTipoDocumento.Enabled = valor;
        }


        //Habilitar los botones
        private void HabilitarBotones()
        {
            if (this.isEditar || this.isNuevo)
            {
                HabilitarControles(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                HabilitarControles(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        //Metodo Mostrar Presentaciones
        private void Mostrar()
        {
            this.dataListado.DataSource = Ncliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Ncliente.BuscarNombre(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarApellido
        private void BuscarApellido()
        {
            this.dataListado.DataSource = Ncliente.BuscarApellido(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNumDocumento
        private void BuscarNumDocumento()
        {
            this.dataListado.DataSource = Ncliente.BuscarNumDocumento(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
            HabilitarBotones();
            HabilitarControles(false);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea eliminar el/los clientes seleccionados?",
                    "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int IdCliente = 0;
                    string respuesta = "";

                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            IdCliente = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Ncliente.Eliminar(IdCliente);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("El/los clientes se eleminaron correctamente.");
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
            txtIdCliente.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcliente"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value);
            cbSexo.Text = Convert.ToString(dataListado.CurrentRow.Cells["sexo"].Value);
            dtFechaNacimineto.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            cbTipoDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_documento"].Value);
            txtNumDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
            mtxtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);

            tabControl1.SelectTab(1);
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

                if (txtNombre.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre del cliente");
                }
                else if (txtApellido.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtApellido, "Ingrese el apellido del cliente");

                }
                else if (txtNumDocumento.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtNumDocumento, "Ingrese el número de documento");

                }
                else if (txtDireccion.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtDireccion, "Ingrese la dirección del cliente");

                }
                else
                {
                    if (isNuevo)
                    {
                        respuesta = Ncliente.Insertar(txtNombre.Text.Trim().ToUpper(), txtApellido.Text.Trim().ToUpper(), cbSexo.Text, dtFechaNacimineto.Value,
                            cbTipoDocumento.Text, txtNumDocumento.Text, txtDireccion.Text, mtxtTelefono.Text, txtEmail.Text);
                    }
                    else
                    {
                        respuesta = Ncliente.Editar(Convert.ToInt32(txtIdCliente.Text), txtNombre.Text.Trim().ToUpper(), txtApellido.Text.Trim().ToUpper(),
                            cbSexo.Text, dtFechaNacimineto.Value, cbTipoDocumento.Text, txtNumDocumento.Text, txtDireccion.Text, mtxtTelefono.Text, txtEmail.Text);
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("El cliente se agregó correctamente");
                        }
                        else
                        {
                            Utilidades.MensajeOK("La cliente se editó correctamente");
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
            if (!txtIdCliente.Text.Equals(""))
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
    }
}
