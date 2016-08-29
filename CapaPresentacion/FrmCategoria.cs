using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class FrmCategoria : Form
    {
        private bool isNuevo = false; //Para identificar si se agregara una Categoria
        private bool isEditar = false; //Para identificar si se Editara una Categoria

        public FrmCategoria()
        {
            InitializeComponent();
            //Mensajes de ayuda (ToolTip)
            ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoría");
        }

        //Limpiar contoles
        private void Limpiar()
        {
            txtDescripcion.Clear();
            txtIdCategoria.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
        }

        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            this.txtIdCategoria.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
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
        //Metodo Mostrar categorias
        private void Mostrar()
        {
            this.dataListado.DataSource = Ncategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Ncategoria.BuscarNombre(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Limpiar();
            this.HabilitarBotones();
            this.HabilitarControles(true);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.HabilitarControles(false);
            this.HabilitarBotones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                        respuesta = Ncategoria.Insertar(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        respuesta = Ncategoria.Editar(Convert.ToInt32(txtIdCategoria.Text), txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("La categoria se agregó correctamente");
                        }
                        else
                        {
                            Utilidades.MensajeOK("La categoria se editó correctamente");
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);

            this.tabControl1.SelectTab(1);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdCategoria.Text.Equals(""))
            {
                this.isEditar = true;
                this.HabilitarBotones();
                this.HabilitarControles(true);
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
                    MessageBox.Show("¿Realmente desea eliminar la/las categorias seleccionadas?",
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
                            respuesta = Ncategoria.Eliminar(IdCategoria);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("La/las Categoria/s se eleminaron correctamente.");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var Formulario = new FrmReporteCategorias();
            Formulario.Show();
        }
    }
}
