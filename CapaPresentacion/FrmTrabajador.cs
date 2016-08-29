using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmTrabajador : Form
    {

        private bool isNuevo = false; //Para identificar si se agregara un trabajador
        private bool isEditar = false; //Para identificar si se Editara un trabajador


        public FrmTrabajador()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(cbPerfilUsuario, "Seleccione el perfil que tendrá el usuario");

        }

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            Mostrar();
            HabilitarBotones();
            HabilitarControles(false);
        }


        //Limpiar contoles
        private void Limpiar()
        {
            txtIdTrabajador.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtNumDocumento.Clear();
            txtDireccion.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            txtConfirmarPassword.Clear();
            mtxtTelefono.Clear();
            txtEmail.Clear();
            txtNombre.Focus();

        }

        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtUsuario.ReadOnly = !valor;
            txtPassword.ReadOnly = !valor;
            txtConfirmarPassword.ReadOnly = !valor;
            txtApellido.ReadOnly = !valor;
            txtNumDocumento.ReadOnly = !valor;
            txtDireccion.ReadOnly = !valor;
            mtxtTelefono.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            cbSexo.Enabled = valor;
            cbPerfilUsuario.Enabled = valor;

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
            dataListado.Columns[12].Visible = false;
        }
        //Metodo Mostrar Presentaciones
        private void Mostrar()
        {
            dataListado.DataSource = Ntrabajador.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = Ntrabajador.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarApellido
        private void BuscarApellido()
        {
            dataListado.DataSource = Ntrabajador.BuscarApellido(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNumDocumento
        private void BuscarNumDocumento()
        {
            dataListado.DataSource = Ntrabajador.BuscarNumDocumento(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea eliminar el/los trabajadores seleccionados?",
                    "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int IdTrabajador = 0;
                    string respuesta = "";

                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            IdTrabajador = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Ntrabajador.Eliminar(IdTrabajador);

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
            txtIdTrabajador.Text = Convert.ToString(dataListado.CurrentRow.Cells["idtrabajador"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value);
            cbSexo.Text = Convert.ToString(dataListado.CurrentRow.Cells["sexo"].Value);
            dtFechaNacimineto.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_nac"].Value);
            txtNumDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
            mtxtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);
            cbPerfilUsuario.Text = Convert.ToString(dataListado.CurrentRow.Cells["acceso"].Value);
            txtUsuario.Text = Convert.ToString(dataListado.CurrentRow.Cells["usuario"].Value);
            txtPassword.Text = Convert.ToString(dataListado.CurrentRow.Cells["password"].Value);
            txtConfirmarPassword.Text = Convert.ToString(dataListado.CurrentRow.Cells["password"].Value);

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
                else if (txtUsuario.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtUsuario, "Ingrese el usuario del cliente");

                }
                else if (txtPassword.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtPassword, "Ingrese contraseña del usuario");

                }
                else if (txtConfirmarPassword.Text == string.Empty || txtConfirmarPassword.Text != txtPassword.Text)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtConfirmarPassword, "Ingrese confirme la contraseña del usuario");
                }
                else
                {
                    if (isNuevo)
                    {
                        respuesta = Ntrabajador.Insertar(txtNombre.Text.Trim().ToUpper(), txtApellido.Text.Trim().ToUpper(), cbSexo.Text, dtFechaNacimineto.Value,
                             txtNumDocumento.Text, txtDireccion.Text, mtxtTelefono.Text, txtEmail.Text, cbPerfilUsuario.Text, txtUsuario.Text, txtPassword.Text);
                    }
                    else
                    {
                        respuesta = Ntrabajador.Editar(Convert.ToInt32(txtIdTrabajador.Text), txtNombre.Text.Trim().ToUpper(), txtApellido.Text.Trim().ToUpper(), cbSexo.Text, dtFechaNacimineto.Value,
                             txtNumDocumento.Text, txtDireccion.Text, mtxtTelefono.Text, txtEmail.Text, cbPerfilUsuario.Text, txtUsuario.Text, txtPassword.Text);
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("El trabajador se agregó correctamente");
                        }
                        else
                        {
                            Utilidades.MensajeOK("La trabajador se editó correctamente");
                        }
                    }
                    else
                    {
                        Utilidades.MensajeError($"No se agrego el trabajador:\n {respuesta}");
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
            if (!txtIdTrabajador.Text.Equals(""))
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var formulario = new FrmReporteTrabajador();
            formulario.Show();
        }
    }
}
