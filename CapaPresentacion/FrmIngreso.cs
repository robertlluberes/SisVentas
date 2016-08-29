using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmIngreso : Form
    {
        public int idTrabajador;
        private bool isNuevo;
        private DataTable dtDetalles;
        private decimal totalPagado = 0;

        //Obtener instancia del formulario
        #region Instancia
        private static FrmIngreso _instancia;

        public static FrmIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmIngreso();
            }

            return _instancia;
        }
        #endregion

        public FrmIngreso()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(btnBuscarProveedor, "Haga clic para seleccionar el proveedor");
            ttMensaje.SetToolTip(cbTipoComprobante, "Seleccione el tipo de comprobante");
            ttMensaje.SetToolTip(txtSerie, "Indique la serie del comprobante");
            ttMensaje.SetToolTip(txtCorrelativo, "Indique el correlativo del comprobante");
            ttMensaje.SetToolTip(btnBuscarArticulo, "Haga clic para seleccionar un artículo");
            ttMensaje.SetToolTip(btnAgregar, "Haga clic para agregar el artículo seleccionado");
            ttMensaje.SetToolTip(btnQuitar, "Haga clic para eliminar el artículo seleccionado");

            txtProveedor.ReadOnly = true;
            txtArticulo.ReadOnly = true;
        }

        public void SetProveedor(string idProveedor, string nombreProveedor)
        {
            txtIdProveedor.Text = idProveedor;
            txtProveedor.Text = nombreProveedor;
        }

        public void SetArticulo(string idArticulo, string nombreArticulo)
        {
            txtIdArticulo.Text = idArticulo;
            txtArticulo.Text = nombreArticulo;
        }


        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void FrmIngreso_Load(object sender, System.EventArgs e)
        {
            Mostrar();
            HabilitarBotones();
            HabilitarControles(false);
            CrearTablaDetalle();
        }

        private void btnBuscarProveedor_Click(object sender, System.EventArgs e)
        {
            var vista = new FrmVistaProveedorIngreso();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, System.EventArgs e)
        {
            var vista = new FrmVistaArticuloIngreso();
            vista.ShowDialog();

        }

        //Limpiar contoles
        private void Limpiar()
        {
            txtIdIngreso.Clear();
            txtIdProveedor.Clear();
            txtProveedor.Clear();
            txtSerie.Clear();
            txtCorrelativo.Clear();
            txtItbis.Clear();
            lblTotalPagado.Text = "0.0";

            CrearTablaDetalle();

            txtItbis.Text = "18";
        }

        //limpiar detalles
        private void limpiarDetalle()
        {
            txtIdArticulo.Clear();
            txtArticulo.Clear();
            txtStock.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
        }


        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtIdIngreso.ReadOnly = !valor;
            txtSerie.ReadOnly = !valor;
            txtCorrelativo.ReadOnly = !valor;
            txtItbis.ReadOnly = !valor;
            txtCodigos.ReadOnly = !valor;
            dtFechaIngresoAlmacen.Enabled = valor;
            cbTipoComprobante.Enabled = valor;
            txtStock.ReadOnly = !valor;
            txtPrecioCompra.ReadOnly = !valor;
            txtPrecioVenta.ReadOnly = !valor;
            dtFechaProduccion.Enabled = valor;
            dtFechaVencimiento.Enabled = valor;

            btnBuscarArticulo.Enabled = valor;
            btnBuscarProveedor.Enabled = valor;
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;
        }


        //Habilitar los botones
        private void HabilitarBotones()
        {
            if (isNuevo)
            {
                HabilitarControles(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;

            }
            else
            {
                HabilitarControles(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[1].Visible = false;
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = Ningreso.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarBuscarFechas
        private void BuscarFechas()
        {
            dataListado.DataSource = Ningreso.BuscarFechas(dtFechaInicio.Value.ToString("yyyy-MM-dd"), dtFechaFin.Value.ToString("yyyy-MM-dd"));
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }
        //Metodo MostrarDetalles
        private void MostrarDetalles()
        {
            dataListadoDetalle.DataSource = Ningreso.MostrarDetalles(txtIdIngreso.Text);
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            BuscarFechas();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea anular el/los registros seleccionados?",
                    "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int IdIngreso = 0;
                    string respuesta = "";

                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            IdIngreso = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Ningreso.Anular(IdIngreso);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("El ingreso se anuló correctamente.");
                            }
                            else
                            {
                                Utilidades.MensajeError(respuesta);
                            }
                        }
                    }
                    Mostrar();
                    chkAnular.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked)
            {
                dataListado.Columns[0].Visible = true;
                btnAnular.Enabled = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
                btnAnular.Enabled = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];

                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void CrearTablaDetalle()
        {
            dtDetalles = new DataTable("Detalles");
            dtDetalles.Columns.Add("idarticulo", Type.GetType("System.Int32"));
            dtDetalles.Columns.Add("articulo", Type.GetType("System.String"));
            dtDetalles.Columns.Add("precio_compra", Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("precio_venta", Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("stock_inicial", Type.GetType("System.Int32"));
            dtDetalles.Columns.Add("fecha_produccion", Type.GetType("System.DateTime"));
            dtDetalles.Columns.Add("fecha_vencimiento", Type.GetType("System.DateTime"));
            dtDetalles.Columns.Add("subtotal", Type.GetType("System.Decimal"));

            dataListadoDetalle.DataSource = dtDetalles;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            isNuevo = true;
            Limpiar();
            HabilitarBotones();
            HabilitarControles(true);
            limpiarDetalle();
            txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            isNuevo = false;
            HabilitarControles(false);
            HabilitarBotones();
            Limpiar();
            limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                if (txtIdProveedor.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtProveedor, "Seleccione un proveedor");
                }
                else if (txtSerie.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                }
                else if (txtCorrelativo.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                }
                else if (txtItbis.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtItbis, "Ingrese un valor");
                }
                else
                {

                    if (isNuevo)
                    {
                        respuesta = Ningreso.Insertar(idTrabajador, Convert.ToInt32(txtIdProveedor.Text), dtFechaIngresoAlmacen.Value,
                            cbTipoComprobante.Text, txtSerie.Text, txtCorrelativo.Text, Convert.ToDecimal(txtItbis.Text), "ËMITIDO", dtDetalles
                            );
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("El ingreso se agregó correctamente");
                        }
                    }
                    else
                    {
                        Utilidades.MensajeError(respuesta);
                    }

                    isNuevo = false;
                    HabilitarBotones();
                    Limpiar();
                    limpiarDetalle();
                    Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtIdArticulo.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtArticulo, "Seleccione un articulo");
                }
                else if (txtStock.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtStock, "Ingrese un valo");
                }
                else if (txtPrecioCompra.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                }
                else if (txtPrecioVenta.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow fila in dtDetalles.Rows)
                    {
                        if (Convert.ToInt32(fila["idarticulo"])
                            == Convert.ToInt32(txtIdArticulo.Text))
                        {
                            registrar = false;
                            Utilidades.MensajeError("El artículo ya se encuentra en el detalle");
                        }
                    }

                    if (registrar)
                    {
                        var subTotal = Convert.ToDecimal(txtStock.Text) * Convert.ToDecimal(txtPrecioCompra.Text);
                        totalPagado = +subTotal;
                        lblTotalPagado.Text = totalPagado.ToString("#0.00#");

                        //Agregar detalle a datalistadodetalle
                        var fila = dtDetalles.NewRow();
                        fila["idarticulo"] = Convert.ToInt32(txtIdArticulo.Text);
                        fila["articulo"] = txtArticulo.Text;
                        fila["precio_compra"] = Convert.ToDecimal(txtPrecioCompra.Text);
                        fila["Precio_venta"] = Convert.ToDecimal(txtPrecioVenta.Text);
                        fila["stock_inicial"] = Convert.ToInt32(txtStock.Text);
                        fila["fecha_produccion"] = dtFechaProduccion.Value;
                        fila["fecha_vencimiento"] = dtFechaProduccion.Value;
                        fila["subtotal"] = subTotal;

                        dtDetalles.Rows.Add(fila);
                        limpiarDetalle();


                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = dataListadoDetalle.CurrentCell.RowIndex;
                DataRow fila = dtDetalles.Rows[indiceFila];

                //Disminuir Total Pagado
                totalPagado = totalPagado - Convert.ToDecimal(fila["subtotal"].ToString());
                lblTotal.Text = totalPagado.ToString("#0.00#");
                //Remover fila
                dtDetalles.Rows.Remove(fila);
            }
            catch (Exception)
            {
                Utilidades.MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdIngreso.Text = Convert.ToString(dataListado.CurrentRow.Cells["idingreso"].Value);
            txtProveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["proveedor"].Value);
            dtFechaIngresoAlmacen.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            cbTipoComprobante.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            txtSerie.Text = Convert.ToString(dataListado.CurrentRow.Cells["serie"].Value);
            txtCorrelativo.Text = Convert.ToString(dataListado.CurrentRow.Cells["correlativo"].Value);
            lblTotalPagado.Text = Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);

            MostrarDetalles();
            tabControl1.SelectedIndex = 1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
