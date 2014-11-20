using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public bool _activado = true;
        private Usuario _usr;

        public Usuario Usr
        {
            get { return _usr; }
            set { _usr = value; }
        }

        public formLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usr = ul.getUsuarioPermitido(this.txtUsuario.Text, this.txtPass.Text);

            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (Usr != null)
            {
               // MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos (usuario:" + this.txtUsuario.Text + " clave:" + this.txtPass.Text + ")", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
