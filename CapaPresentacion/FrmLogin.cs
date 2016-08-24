using CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //Metodo Ingresar.
        private void Ingresar()
        {
            DataTable Datos = Ntrabajador.Login(txtUsuario.Text, txtPassword.Text);

            if (Datos == null)
            {
                MessageBox.Show("Usuario y/o contraseña invalido", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipal frm = new FrmPrincipal();
                frm.idTrabajador = Datos.Rows[0][0].ToString();
                frm.apellido = Datos.Rows[0][1].ToString();
                frm.nombre = Datos.Rows[0][2].ToString();
                frm.acceso = Datos.Rows[0][3].ToString();
                frm.Show();
                Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            Ingresar();

        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Ingresar();
            }
        }
    }
}
