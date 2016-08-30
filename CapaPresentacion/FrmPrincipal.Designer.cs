namespace CapaPresentacion
{
    partial class FrmPrincipal
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsIngreso = new System.Windows.Forms.ToolStripButton();
            this.tsVentas = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentanas = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuSisVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.artículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presentaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.stockDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsIngreso,
            this.tsVentas});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(808, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tsIngreso
            // 
            this.tsIngreso.Image = global::CapaPresentacion.Properties.Resources.compra_b1;
            this.tsIngreso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsIngreso.Name = "tsIngreso";
            this.tsIngreso.Size = new System.Drawing.Size(71, 22);
            this.tsIngreso.Text = "Ingresos";
            this.tsIngreso.Click += new System.EventHandler(this.tsIngreso_Click);
            // 
            // tsVentas
            // 
            this.tsVentas.Image = global::CapaPresentacion.Properties.Resources.ventas_m;
            this.tsVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVentas.Name = "tsVentas";
            this.tsVentas.Size = new System.Drawing.Size(62, 22);
            this.tsVentas.Text = "Ventas";
            this.tsVentas.Click += new System.EventHandler(this.tsVentas_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(808, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(102, 17);
            this.toolStripStatusLabel.Text = "Sistema de Ventas";
            // 
            // mnuVer
            // 
            this.mnuVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.mnuVer.Name = "mnuVer";
            this.mnuVer.Size = new System.Drawing.Size(36, 20);
            this.mnuVer.Text = "&Ver";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.toolBarToolStripMenuItem.Text = "&Barra de Herramienta";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.statusBarToolStripMenuItem.Text = "&Barra de estado";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // mnuHerramientas
            // 
            this.mnuHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.mnuHerramientas.Name = "mnuHerramientas";
            this.mnuHerramientas.Size = new System.Drawing.Size(90, 20);
            this.mnuHerramientas.Text = "&Herramientas";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.optionsToolStripMenuItem.Text = "&Base de Datos";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // mnuVentanas
            // 
            this.mnuVentanas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.mnuVentanas.Name = "mnuVentanas";
            this.mnuVentanas.Size = new System.Drawing.Size(67, 20);
            this.mnuVentanas.Text = "&Ventanas";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSisVentas,
            this.mnuAlmacen,
            this.mnuCompras,
            this.mnuVentas,
            this.mnuMantenimiento,
            this.mnuConsultas,
            this.mnuVer,
            this.mnuHerramientas,
            this.mnuVentanas,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.mnuVentanas;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(808, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuSisVentas
            // 
            this.mnuSisVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.mnuSisVentas.Name = "mnuSisVentas";
            this.mnuSisVentas.Size = new System.Drawing.Size(68, 20);
            this.mnuSisVentas.Text = "SisVentas";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mnuAlmacen
            // 
            this.mnuAlmacen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artículosToolStripMenuItem,
            this.categoríasToolStripMenuItem,
            this.presentaciónToolStripMenuItem});
            this.mnuAlmacen.Name = "mnuAlmacen";
            this.mnuAlmacen.Size = new System.Drawing.Size(66, 20);
            this.mnuAlmacen.Text = "Almacén";
            // 
            // artículosToolStripMenuItem
            // 
            this.artículosToolStripMenuItem.Name = "artículosToolStripMenuItem";
            this.artículosToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.artículosToolStripMenuItem.Text = "Artículos";
            this.artículosToolStripMenuItem.Click += new System.EventHandler(this.artículosToolStripMenuItem_Click);
            // 
            // categoríasToolStripMenuItem
            // 
            this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.categoríasToolStripMenuItem.Text = "Categorías";
            this.categoríasToolStripMenuItem.Click += new System.EventHandler(this.categoríasToolStripMenuItem_Click);
            // 
            // presentaciónToolStripMenuItem
            // 
            this.presentaciónToolStripMenuItem.Name = "presentaciónToolStripMenuItem";
            this.presentaciónToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.presentaciónToolStripMenuItem.Text = "Presentación";
            this.presentaciónToolStripMenuItem.Click += new System.EventHandler(this.presentaciónToolStripMenuItem_Click_1);
            // 
            // mnuCompras
            // 
            this.mnuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.mnuCompras.Name = "mnuCompras";
            this.mnuCompras.Size = new System.Drawing.Size(67, 20);
            this.mnuCompras.Text = "Compras";
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            this.ingresosToolStripMenuItem.Click += new System.EventHandler(this.ingresosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // mnuVentas
            // 
            this.mnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem1,
            this.clientesToolStripMenuItem});
            this.mnuVentas.Name = "mnuVentas";
            this.mnuVentas.Size = new System.Drawing.Size(57, 20);
            this.mnuVentas.Text = " Ventas";
            // 
            // ventasToolStripMenuItem1
            // 
            this.ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            this.ventasToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.ventasToolStripMenuItem1.Text = "Ventas";
            this.ventasToolStripMenuItem1.Click += new System.EventHandler(this.ventasToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trabajadoresToolStripMenuItem});
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Size = new System.Drawing.Size(101, 20);
            this.mnuMantenimiento.Text = "Mantenimiento";
            // 
            // trabajadoresToolStripMenuItem
            // 
            this.trabajadoresToolStripMenuItem.Name = "trabajadoresToolStripMenuItem";
            this.trabajadoresToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.trabajadoresToolStripMenuItem.Text = "Trabajadores";
            this.trabajadoresToolStripMenuItem.Click += new System.EventHandler(this.trabajadoresToolStripMenuItem_Click);
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockDeToolStripMenuItem});
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Size = new System.Drawing.Size(71, 20);
            this.mnuConsultas.Text = "Consultas";
            // 
            // stockDeToolStripMenuItem
            // 
            this.stockDeToolStripMenuItem.Name = "stockDeToolStripMenuItem";
            this.stockDeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.stockDeToolStripMenuItem.Text = "Stock de Artículos";
            this.stockDeToolStripMenuItem.Click += new System.EventHandler(this.stockDeToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 20);
            this.helpMenu.Text = "&Ayuda";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "&Acerca de...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmPrincipal";
            this.Text = "Sistema de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuVer;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHerramientas;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVentanas;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuSisVentas;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCompras;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVentas;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem trabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem stockDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsIngreso;
        private System.Windows.Forms.ToolStripButton tsVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuAlmacen;
        private System.Windows.Forms.ToolStripMenuItem artículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presentaciónToolStripMenuItem;
    }
}



