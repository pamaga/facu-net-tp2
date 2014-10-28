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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }


        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo):this(){
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo):this(){
            this.Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            this.UsuarioActual = usuario.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtClave2.Text = this.UsuarioActual.Clave;

            string txtAceptar = "Aceptar";

            if(Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion)){
                txtAceptar = "Guardar";
            }else if(Modo.Equals(ModoForm.Baja)){
                txtAceptar = "Eliminar";
            }
            this.btnAceptar.Text = txtAceptar;
        }

        public override void MapearADatos() {
            if(Modo.Equals(ModoForm.Alta)){
                this.UsuarioActual = new Usuario();
                this.UsuarioActual.State = BusinessEntity.States.New;
            } else if (Modo.Equals(ModoForm.Modificacion)) {
                this.UsuarioActual.State = BusinessEntity.States.Modified;
            } else if (Modo.Equals(ModoForm.Baja)) {
                this.UsuarioActual.State = BusinessEntity.States.Deleted;
            }


            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.EMail = this.txtEmail.Text;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Clave = this.txtClave2.Text;
        }

        public override bool Validar() {
            if( this.txtNombre.Text == String.Empty ||
                this.txtApellido.Text == String.Empty ||
                this.txtEmail.Text == String.Empty ||
                this.txtUsuario.Text == String.Empty ||
                this.txtClave.Text == String.Empty ||
                this.txtClave2.Text == String.Empty){
                    this.Notificar("Error de validación", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtNombre.Focus();
                    return false;
            }

            if (!this.txtClave.Text.Equals(this.txtClave2.Text)){
                this.Notificar("Error de validación", "Las claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Focus();
                return false;
            }

            if ( this.txtClave.Text.Length < 8 ){
                this.Notificar("Error de validación", "La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Focus();
                return false;
            }

            if ( !Regex.IsMatch(this.txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase) )
            {
                this.Notificar("Error de validación", "Ingrese un Email válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtEmail.Focus();
                return false;
            }

            return true; 
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic uLogic = new UsuarioLogic();
            uLogic.Save(this.UsuarioActual);
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if( this.Validar() ){
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
