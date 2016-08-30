using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVenta : Form
    {
        private bool isNuevo = false;
        public int iDTrabajador;
        private DataTable dtDetalles;

        private decimal totalPagado = 0;

        private static FrmVenta _instancia;

        public static FrmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmVenta();
            }
            return _instancia;
        }

        public void SetCliente(string idCliente, string nombreCliente)
        {
            txtIdCliente.Text = idCliente;
            txtCliente.Text = nombreCliente;
        }

        public void SetArticulo(string idDetalleIngreso, string nombreArticulo,
            decimal precioCompra, decimal precioVenta, int stock, DateTime fechaVencimiento)
        {
            txtIdArticulo.Text = idDetalleIngreso;
            txtArticulo.Text = nombreArticulo;
            txtPrecioCompra.Text = Convert.ToString(precioCompra);
            txtPrecioVenta.Text = Convert.ToString(precioVenta);
            txtStockActual.Text = Convert.ToString(stock);
            dtFechaVencimiento.Value = fechaVencimiento;
        }

        public FrmVenta()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCliente, "Seleccione un cliente");
            ttMensaje.SetToolTip(btnBuscarCliente, "Seleccione un cliente");
            ttMensaje.SetToolTip(txtArticulo, "Seleccione un articulo");
            ttMensaje.SetToolTip(btnBuscarArticulo, "Seleccione un articulo");
            ttMensaje.SetToolTip(btnAgregar, "Agregar articulo");
            ttMensaje.SetToolTip(btnQuitar, "Quitar articulo");
            ttMensaje.SetToolTip(txtSerie, "Serie");
            ttMensaje.SetToolTip(txtCorrelativo, "Correlativo");

            txtIdArticulo.Visible = false;
            txtIdCliente.Visible = false;

            txtIdCliente.ReadOnly = true;
            txtArticulo.ReadOnly = true;
            dtFechaVencimiento.Enabled = false;
            txtPrecioCompra.ReadOnly = true;
            txtStockActual.ReadOnly = true;
            txtDescuento.Text = "0";
        }

        //Limpiar contoles
        private void Limpiar()
        {
            txtIdVenta.Clear();
            txtIdCliente.Clear();
            txtCliente.Clear();
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
            txtStockActual.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtDescuento.Text = "0.0";
        }


        //Habilitar los controles del formulario
        private void HabilitarControles(bool valor)
        {
            txtIdVenta.ReadOnly = !valor;
            txtSerie.ReadOnly = !valor;
            txtCliente.ReadOnly = !valor;
            txtCorrelativo.ReadOnly = !valor;
            dtFechaIngresoAlmacen.Enabled = valor;
            cbTipoComprobante.Enabled = valor;
            txtCantidad.ReadOnly = !valor;
            txtPrecioCompra.ReadOnly = !valor;
            txtPrecioVenta.ReadOnly = !valor;
            dtFechaVencimiento.Enabled = valor;
            txtStockActual.ReadOnly = !valor;
            txtDescuento.ReadOnly = !valor;

            btnBuscarArticulo.Enabled = valor;
            btnBuscarCliente.Enabled = valor;
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
            dataListado.DataSource = NVenta.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarBuscarFechas
        private void BuscarFechas()
        {
            dataListado.DataSource = NVenta.BuscarFechas(dtFechaInicio.Value.ToString("yyyy-MM-dd"), dtFechaFin.Value.ToString("yyyy-MM-dd"));
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }
        //Metodo MostrarDetalles
        private void MostrarDetalles()
        {
            dataListadoDetalle.DataSource = NVenta.MostrarDetalles(txtIdVenta.Text);
        }

        //Crear tabla
        private void CrearTablaDetalle()
        {
            dtDetalles = new DataTable("Detalles");
            dtDetalles.Columns.Add("iddetalle_ingreso", Type.GetType("System.Int32"));
            dtDetalles.Columns.Add("articulo", Type.GetType("System.String"));
            dtDetalles.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dtDetalles.Columns.Add("precio_venta", Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("descuento", Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("subtotal", Type.GetType("System.Decimal"));

            dataListadoDetalle.DataSource = dtDetalles;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            Mostrar();
            HabilitarControles(false);
            HabilitarBotones();
            CrearTablaDetalle();
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var vista = new FrmVistaClienteVenta();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            var vista = new FrmVistaArticuloVenta();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion =
                    MessageBox.Show("¿Realmente desea eliminar la/las ventas seleccionadas?",
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
                            respuesta = NVenta.Eliminar(IdIngreso);

                            if (respuesta.Equals("Ok"))
                            {
                                Utilidades.MensajeOK("El ingreso se eliminó correctamente.");
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
            txtIdVenta.Text = Convert.ToString(dataListado.CurrentRow.Cells["idventa"].Value);
            txtIdCliente.Text = Convert.ToString(dataListado.CurrentRow.Cells["cliente"].Value);
            dtFechaIngresoAlmacen.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            cbTipoComprobante.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            txtSerie.Text = Convert.ToString(dataListado.CurrentRow.Cells["serie"].Value);
            txtCorrelativo.Text = Convert.ToString(dataListado.CurrentRow.Cells["correlativo"].Value);
            lblTotalPagado.Text = Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);

            MostrarDetalles();
            tabControl1.SelectedIndex = 1;
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
            HabilitarBotones();
            HabilitarControles(true);
            Limpiar();
            limpiarDetalle();
            txtSerie.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            isNuevo = false;
            HabilitarBotones();
            Limpiar();
            limpiarDetalle();
            HabilitarControles(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                if (txtIdCliente.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtIdCliente, "Seleccione un proveedor");
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
                        respuesta = NVenta.Insertar(Convert.ToInt32(txtIdCliente.Text), iDTrabajador, dtFechaIngresoAlmacen.Value,
                            cbTipoComprobante.Text, txtSerie.Text, txtCorrelativo.Text, Convert.ToDecimal(txtItbis.Text), dtDetalles);
                    }

                    if (respuesta.Equals("Ok"))
                    {
                        if (isNuevo)
                        {
                            Utilidades.MensajeOK("La venta se insertó correctamente");
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
                else if (txtStockActual.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtStockActual, "Ingrese un valo");
                }
                else if (txtCantidad.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                }
                else if (txtPrecioVenta.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else if (txtDescuento.Text == string.Empty)
                {
                    Utilidades.MensajeError("Falta ingresar algunos datos.");
                    errorIcono.SetError(txtDescuento, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow fila in dtDetalles.Rows)
                    {
                        if (Convert.ToInt32(fila["iddetalle_ingreso"])
                            == Convert.ToInt32(txtIdArticulo.Text))
                        {
                            registrar = false;
                            Utilidades.MensajeError("El artículo ya se encuentra en el detalle");
                        }
                    }

                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                    {
                        var subTotal = Convert.ToDecimal(txtStockActual.Text) * Convert.ToDecimal(txtPrecioVenta.Text) - Convert.ToDecimal(txtDescuento.Text);
                        totalPagado = +subTotal;
                        lblTotalPagado.Text = totalPagado.ToString("#0.00#");

                        //Agregar detalle a datalistadodetalle
                        var fila = dtDetalles.NewRow();
                        fila["iddetalle_ingreso"] = Convert.ToInt32(txtIdArticulo.Text);
                        fila["articulo"] = txtArticulo.Text;
                        fila["cantidad"] = Convert.ToDecimal(txtCantidad.Text);
                        fila["Precio_venta"] = Convert.ToDecimal(txtPrecioVenta.Text);
                        fila["descuento"] = Convert.ToDecimal(txtDescuento.Text);

                        fila["subtotal"] = subTotal;

                        dtDetalles.Rows.Add(fila);
                        limpiarDetalle();


                    }
                    else
                    {
                        Utilidades.MensajeError("No hay stock suficiente");
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

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            var frm = new FrmReporteFactura();
            frm.IdVenta = Convert.ToInt32(dataListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();

        }
    }
}
