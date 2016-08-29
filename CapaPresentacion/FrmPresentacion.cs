using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPresentacion : Form
    {
        private bool isNuevo = false; //Para identificar si se agregara una Presentacion
        private bool isEditar = false; //Para identificar si se Editara una Presentacion

        public FrmPresentacion()
        {
            InitializeComponent();
            //Mensajes de ayuda (ToolTip)
            ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre de la Presentación");
        }


        //Limpiar contoles
        private void Limpiar()
        {
            txtDescripcion.Clear();
            txtIdPresentacion.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
        }

        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtIdPresentacion.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            txtDescripcion.ReadOnly = !valor;
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
            dataListado.DataSource = Npresentacion.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = Npresentacion.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            Mostrar();
            HabilitarControles(false);
            HabilitarBotones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                if (txtNombre.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtNombre, "Ingrese un nombre");
                }
                else
                {
                    if (isNuevo)
                    {
                        respuesta = Npresentacion.Insertar(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        respuesta = Npresentacion.Editar(Convert.ToInt32(txtIdPresentacion.Text), txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("La Presentación se agregó correctamente");
                        }
                        else
                        {
                            Utilidades.MensajeOK("La Presentación se editó correctamente");
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
                MessageBox.Show(ex.Message);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdPresentacion.Text.Equals(""))
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea eliminar la/las presentaciones seleccionadas?",
                    "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int IdCategoria = 0;
                    string respuesta = "";

                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            IdCategoria = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Npresentacion.Eliminar(IdCategoria);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("La/s presentación/es se eleminaron correctamente.");
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdPresentacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["idpresentacion"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);

            tabControl1.SelectTab(1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var Formulario = new FrmReportePresentacion();
            Formulario.Show();
        }
    }
}
