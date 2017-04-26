using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginClass.login(txtUsuario.Text, txtContraseña.Text) == null)
                {
                    //MenuPrincipal menuPrincipal = new MenuPrincipal();
                    //menuPrincipal.Show();
                }
                //MenuPrincipal menuPrincipal = new MenuPrincipal();
                //this.Hide();
                //menuPrincipal.Show();
            }
            catch (Exception ex)
            {

            }
        }



    }
}
