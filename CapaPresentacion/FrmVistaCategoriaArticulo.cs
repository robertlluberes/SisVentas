using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVistaCategoriaArticulo : Form
    {
        public FrmVistaCategoriaArticulo()
        {
            InitializeComponent();
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;

        }
        //Metodo Mostrar categorias
        private void Mostrar()
        {
            dataListado.DataSource = Ncategoria.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = Ncategoria.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total Registros: " + dataListado.Rows.Count;
        }

        private void frmVistaCategoriaArticulo_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmArticulo formulario = FrmArticulo.GetInstancia();

            string idcategoria;
            string nombreCategoria;
            idcategoria = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            nombreCategoria = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);

            formulario.SetCategoria(idcategoria, nombreCategoria);
            Hide();

        }
    }
}
