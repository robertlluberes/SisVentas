using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;

        public string idTrabajador;
        public string nombre;
        public string apellido;
        public string acceso;

        private void GestionAcceso()
        {

            if (acceso == "Administrador")
            {
                mnuAlmacen.Enabled = true;
                mnuCompras.Enabled = true;
                mnuVentas.Enabled = true;
                mnuMantenimiento.Enabled = true;
                mnuConsultas.Enabled = true;
                mnuHerramientas.Enabled = true;
                tsCompras.Enabled = true;
                tsVentas.Enabled = true;
            }
            else if (acceso == "Vendedor")
            {
                mnuAlmacen.Enabled = false;
                mnuCompras.Enabled = false;
                mnuVentas.Enabled = true;
                mnuMantenimiento.Enabled = false;
                mnuConsultas.Enabled = true;
                mnuHerramientas.Enabled = true;
                tsCompras.Enabled = false;
                tsVentas.Enabled = true;
            }
            else if (acceso == "Almacenista")
            {
                mnuAlmacen.Enabled = true;
                mnuCompras.Enabled = true;
                mnuVentas.Enabled = false;
                mnuMantenimiento.Enabled = false;
                mnuConsultas.Enabled = true;
                mnuHerramientas.Enabled = true;
                tsCompras.Enabled = true;
                tsVentas.Enabled = false;
            }
            else
            {
                mnuAlmacen.Enabled = false;
                mnuCompras.Enabled = false;
                mnuVentas.Enabled = false;
                mnuMantenimiento.Enabled = false;
                mnuConsultas.Enabled = false;
                mnuHerramientas.Enabled = false;
                tsCompras.Enabled = false;
                tsVentas.Enabled = false;
            }
        }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void presentaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Consulta.FrmConsultaStockArticulos();
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void presentaciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmPresentacion frm = new FrmPresentacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulo frm = FrmArticulo.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new FrmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajador frm = new FrmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            GestionAcceso();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = FrmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.idTrabajador = Convert.ToInt32(idTrabajador);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVenta Formulario = FrmVenta.GetInstancia();
            Formulario.MdiParent = this;
            Formulario.Show();
            Formulario.iDTrabajador = Convert.ToInt32(idTrabajador);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Formulario = new FrmBackupBD();
            Formulario.MdiParent = this;
            Formulario.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Formulario = new FrmAcercaDe();
            Formulario.MdiParent = this;
            Formulario.Show();
        }
    }
}
