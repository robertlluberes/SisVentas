using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmArticulo : Form
    {
        private bool isNuevo = false; //Para identificar si se agregara un Articulo
        private bool isEditar = false; //Para identificar si se Editara un Articulo

        public FrmArticulo()
        {
            InitializeComponent();
            //Mensajes de ayuda (ToolTip)
            ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre de la Artículo");
            ttMensaje.SetToolTip(pxImagen, "Selecione la imagen del Artículo");
            ttMensaje.SetToolTip(cbPresentacion, "Selecione la presentación del Artículo");
            ttMensaje.SetToolTip(txtIdCategoria, "Selecione la categoría del Artículo");

            txtIdCategoria.Visible = false;
            txtCategoria.ReadOnly = true;
            txtBuscar.Focus();

            LlenarComboPresentacion();
        }

        //Limpiar contoles
        private void Limpiar()
        {
            txtIdArticulo.Clear();
            txtIdCategoria.Clear();
            txtCodigos.Clear();
            txtCategoria.Clear();
            txtNombre.Clear();
            txtBuscar.Clear();
            txtDescripcion.Clear();

            txtNombre.Clear();
            txtCodigos.Focus();
            pxImagen.Image = CapaPresentacion.Properties.Resources.ImagenTransparente;
        }

        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtCodigos.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            txtIdArticulo.ReadOnly = !valor;
            txtDescripcion.ReadOnly = !valor;

            btnBuscarCategoria.Enabled = valor;
            cbPresentacion.Enabled = valor;
            btnCargar.Enabled = valor;
            btnLimpiar.Enabled = valor;


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
            dataListado.Columns[6].Visible = false;
            dataListado.Columns[8].Visible = false;
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = Narticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Narticulo.BuscarNombre(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Llenar los datos del combo box (presentaciones de los articulos)
        private void LlenarComboPresentacion()
        {
            cbPresentacion.DataSource = Npresentacion.Mostrar();
            cbPresentacion.ValueMember = "idpresentacion";
            cbPresentacion.DisplayMember = "nombre";
        }

        //Para llamar al desde el formulario FrmVistaCategoria
        private static FrmArticulo _Instancia;
        public static FrmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmArticulo();
            }
            return _Instancia;
        }

        //Recibirá la categoria desde el formulario FrmVistaCategoria
        public void SetCategoria(string idcategoria, string nombre)
        {
            txtIdCategoria.Text = idcategoria;
            txtCategoria.Text = nombre;
        }



        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            Mostrar();
            HabilitarBotones();
            HabilitarControles(false);

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Archivos de imagen (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            DialogResult Resultado = Dialog.ShowDialog();

            if (Resultado == DialogResult.OK)
            {
                pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                pxImagen.Image = Image.FromFile(Dialog.FileName);
                pxImagen.Image = Utilidades.CambiarTamanoImagen(pxImagen.Image, 50, 50);
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pxImagen.Image = global::CapaPresentacion.Properties.Resources.ImagenTransparente;
            pxImagen.Image = Utilidades.CambiarTamanoImagen(pxImagen.Image, 50, 50);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
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
                    errorIcono.SetError(txtNombre, "Ingrese un nombre");
                }
                else if (txtIdCategoria.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtCategoria, "Seleccione una Categoria");
                }
                else if (txtCodigos.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtCodigos, "Ingrese un valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    pxImagen.Image = Utilidades.CambiarTamanoImagen(pxImagen.Image, 50, 50);
                    pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); //Formato de la imagen.

                    byte[] imagen = ms.GetBuffer();

                    if (isNuevo)
                    {
                        respuesta = Narticulo.Insertar(txtCodigos.Text, txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdCategoria.Text), Convert.ToInt32(cbPresentacion.SelectedValue));
                    }
                    else
                    {
                        respuesta = Narticulo.Editar(Convert.ToInt32(txtIdArticulo.Text), txtCodigos.Text.Trim(), txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdCategoria.Text), Convert.ToInt32(cbPresentacion.SelectedValue));
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("El artículo se agregó correctamente");
                        }
                        else
                        {
                            Utilidades.MensajeOK("La artículo se editó correctamente");
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
                Utilidades.MensajeError(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdArticulo.Text.Equals(""))
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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            var formulario = new FrmVistaCategoriaArticulo();
            formulario.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea eliminar el/los artículos seleccionados?",
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
                            respuesta = Narticulo.Eliminar(IdCategoria);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("El artículo se elimino correctamente.");
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
            txtIdArticulo.Text = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            txtCodigos.Text = Convert.ToString(dataListado.CurrentRow.Cells["codigo"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);
            //Mostrar imagen
            byte[] imagen = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
            pxImagen.Image = Image.FromStream(ms);
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            txtIdCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["categoria"].Value);
            cbPresentacion.SelectedValue = Convert.ToString(dataListado.CurrentRow.Cells["idpresentacion"].Value);

            this.tabControl1.SelectTab(1);
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

        private void FrmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var frm = new FrmReporteArticulos();
            frm.ShowDialog();
        }
    }
}
