namespace CapaPresentacion
{
    partial class FrmIngreso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtIdProveedor = new System.Windows.Forms.TextBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Anular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalPagado = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dtFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtFechaProduccion = new System.Windows.Forms.DateTimePicker();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItbis = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdArticulo = new System.Windows.Forms.TextBox();
            this.txtCorrelativo = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtFechaIngresoAlmacen = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtIdIngreso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkAnular = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Location = new System.Drawing.Point(93, 8);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(41, 20);
            this.txtIdProveedor.TabIndex = 3;
            this.txtIdProveedor.Visible = false;
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anular});
            this.dataListado.Location = new System.Drawing.Point(9, 112);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(859, 352);
            this.dataListado.TabIndex = 1;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // Anular
            // 
            this.Anular.HeaderText = "Anular";
            this.Anular.Name = "Anular";
            this.Anular.ReadOnly = true;
            this.Anular.Width = 43;
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(331, 58);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(30, 23);
            this.btnBuscarProveedor.TabIndex = 18;
            this.btnBuscarProveedor.Text = "+";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Comprobante:";
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Items.AddRange(new object[] {
            "Factura",
            "Nota"});
            this.cbTipoComprobante.Location = new System.Drawing.Point(93, 112);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(85, 21);
            this.cbTipoComprobante.TabIndex = 5;
            this.cbTipoComprobante.Text = "Factura";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(93, 60);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(232, 20);
            this.txtProveedor.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtItbis);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtIdArticulo);
            this.groupBox1.Controls.Add(this.txtCorrelativo);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtFechaIngresoAlmacen);
            this.groupBox1.Controls.Add(this.btnBuscarProveedor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbTipoComprobante);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.txtIdProveedor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCodigos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtIdIngreso);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 446);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalPagado);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.dataListadoDetalle);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dtFechaVencimiento);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.dtFechaProduccion);
            this.groupBox2.Controls.Add(this.txtPrecioVenta);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtPrecioCompra);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtStock);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnBuscarArticulo);
            this.groupBox2.Controls.Add(this.txtArticulo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(850, 248);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // lblTotalPagado
            // 
            this.lblTotalPagado.AutoSize = true;
            this.lblTotalPagado.Location = new System.Drawing.Point(99, 229);
            this.lblTotalPagado.Name = "lblTotalPagado";
            this.lblTotalPagado.Size = new System.Drawing.Size(22, 13);
            this.lblTotalPagado.TabIndex = 53;
            this.lblTotalPagado.Text = "0.0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 229);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Total Pagado RD$";
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.AllowUserToOrderColumns = true;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Location = new System.Drawing.Point(6, 96);
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.Size = new System.Drawing.Size(838, 128);
            this.dataListadoDetalle.TabIndex = 52;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnQuitar.Location = new System.Drawing.Point(613, 57);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(39, 32);
            this.btnQuitar.TabIndex = 51;
            this.btnQuitar.Text = "r";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAgregar.Location = new System.Drawing.Point(613, 17);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(39, 32);
            this.btnAgregar.TabIndex = 50;
            this.btnAgregar.Text = "a";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(362, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "Fecha vencimiento:";
            // 
            // dtFechaVencimiento
            // 
            this.dtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVencimiento.Location = new System.Drawing.Point(468, 66);
            this.dtFechaVencimiento.Name = "dtFechaVencimiento";
            this.dtFechaVencimiento.Size = new System.Drawing.Size(113, 20);
            this.dtFechaVencimiento.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Fecha producción:";
            // 
            // dtFechaProduccion
            // 
            this.dtFechaProduccion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaProduccion.Location = new System.Drawing.Point(114, 70);
            this.dtFechaProduccion.Name = "dtFechaProduccion";
            this.dtFechaProduccion.Size = new System.Drawing.Size(113, 20);
            this.dtFechaProduccion.TabIndex = 39;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(468, 40);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(113, 20);
            this.txtPrecioVenta.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(381, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Precio Venta:";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(468, 15);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(113, 20);
            this.txtPrecioCompra.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(381, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Precio Compra:";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(114, 44);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(113, 20);
            this.txtStock.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Stock Inicial:";
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Location = new System.Drawing.Point(308, 16);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(30, 23);
            this.btnBuscarArticulo.TabIndex = 41;
            this.btnBuscarArticulo.Text = "+";
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(114, 18);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(188, 20);
            this.txtArticulo.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Artículo:";
            // 
            // txtItbis
            // 
            this.txtItbis.Enabled = false;
            this.txtItbis.Location = new System.Drawing.Point(93, 139);
            this.txtItbis.Name = "txtItbis";
            this.txtItbis.Size = new System.Drawing.Size(85, 20);
            this.txtItbis.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Impuestos (%):";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Location = new System.Drawing.Point(140, 8);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(41, 20);
            this.txtIdArticulo.TabIndex = 38;
            this.txtIdArticulo.Visible = false;
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.Location = new System.Drawing.Point(229, 113);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(127, 20);
            this.txtCorrelativo.TabIndex = 33;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(184, 113);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(39, 20);
            this.txtSerie.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Fecha Ingreso:";
            // 
            // dtFechaIngresoAlmacen
            // 
            this.dtFechaIngresoAlmacen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIngresoAlmacen.Location = new System.Drawing.Point(93, 86);
            this.dtFechaIngresoAlmacen.Name = "dtFechaIngresoAlmacen";
            this.dtFechaIngresoAlmacen.Size = new System.Drawing.Size(85, 20);
            this.dtFechaIngresoAlmacen.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Proveedor:";
            // 
            // txtCodigos
            // 
            this.txtCodigos.Location = new System.Drawing.Point(276, 34);
            this.txtCodigos.Name = "txtCodigos";
            this.txtCodigos.Size = new System.Drawing.Size(85, 20);
            this.txtCodigos.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Código Ventas:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(202, 418);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(90, 418);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(9, 418);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtIdIngreso
            // 
            this.txtIdIngreso.Enabled = false;
            this.txtIdIngreso.Location = new System.Drawing.Point(93, 34);
            this.txtIdIngreso.Name = "txtIdIngreso";
            this.txtIdIngreso.Size = new System.Drawing.Size(85, 20);
            this.txtIdIngreso.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(757, 88);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total Registros:";
            // 
            // chkAnular
            // 
            this.chkAnular.AutoSize = true;
            this.chkAnular.Location = new System.Drawing.Point(9, 88);
            this.chkAnular.Name = "chkAnular";
            this.chkAnular.Size = new System.Drawing.Size(56, 17);
            this.chkAnular.TabIndex = 2;
            this.chkAnular.Text = "Anular";
            this.chkAnular.UseVisualStyleBackColor = true;
            this.chkAnular.CheckedChanged += new System.EventHandler(this.chkEliminar_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(206, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(74, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(760, 49);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(103, 23);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.Text = "&Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicio";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dtFechaFin);
            this.tabPage1.Controls.Add(this.dtFechaInicio);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkAnular);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.btnAnular);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(105, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Fecha Fin";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(108, 48);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(83, 20);
            this.dtFechaFin.TabIndex = 9;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(9, 48);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(83, 20);
            this.dtFechaInicio.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 496);
            this.tabControl1.TabIndex = 7;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ingresos a almacén";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // FrmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(908, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIngreso_FormClosing);
            this.Load += new System.EventHandler(this.FrmIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtIdProveedor;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtIdIngreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkAnular;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtFechaIngresoAlmacen;
        private System.Windows.Forms.TextBox txtItbis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCorrelativo;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdArticulo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtFechaVencimiento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtFechaProduccion;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataListadoDetalle;
        private System.Windows.Forms.Label lblTotalPagado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anular;
    }
}