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
    public partial class UsuarioDesktop : ApplicationForm
    {
        private TiposUsuarios _tipoUsuario;
        public TiposUsuarios TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

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

        public UsuarioDesktop(ModoForm modo, TiposUsuarios TipoUsuario):this()
        {
            this.TipoUsuario = TipoUsuario;
            this.Modo = modo;
            this.Text = this.Modo.ToString() + " de " + this.TipoUsuario.ToString();
        }

        public UsuarioDesktop(int ID, ModoForm modo, TiposUsuarios TipoUsuario):this()
        {
            this.Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            this.UsuarioActual = usuario.GetOne(ID);
            this.TipoUsuario = TipoUsuario;
            this.Text = this.Modo.ToString() + " de " + this.TipoUsuario.ToString();
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtClave2.Text = this.UsuarioActual.Clave;
            this.txtFechaNac.Text = this.UsuarioActual.FechaNac;
            this.txtLegajo.Text = this.UsuarioActual.Legajo.ToString();
            this.txtTelefono.Text = this.UsuarioActual.Telefono;

            string txtAceptar = "Aceptar";

            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                txtAceptar = "Guardar";
            }
            else if (Modo.Equals(ModoForm.Baja))
            {
                txtAceptar = "Eliminar";
            }
            this.btnAceptar.Text = txtAceptar;
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.UsuarioActual = new Usuario();
                this.UsuarioActual.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.UsuarioActual.State = BusinessEntity.States.Modified;
            }
            else if (Modo.Equals(ModoForm.Baja))
            {
                this.UsuarioActual.State = BusinessEntity.States.Deleted;
            }


            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.EMail = this.txtEmail.Text;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.TipoUsuario = this.TipoUsuario;
            this.UsuarioActual.FechaNac = this.txtFechaNac.Text;
            this.UsuarioActual.Legajo = int.Parse(this.txtLegajo.Text);
            this.UsuarioActual.Telefono = this.txtTelefono.Text;
        }

        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (
                !Util.Util.validarRequerido(this.txtNombre.Text) ||
                !Util.Util.validarRequerido(this.txtApellido.Text) ||
                !Util.Util.validarRequerido(this.txtEmail.Text) ||
                !Util.Util.validarRequerido(this.txtUsuario.Text) ||
                !Util.Util.validarRequerido(this.txtClave.Text) ||
                !Util.Util.validarRequerido(this.txtClave2.Text) ||
                !Util.Util.validarRequerido(this.txtTelefono.Text) ||
                !Util.Util.validarRequerido(this.txtLegajo.Text) ||
                !Util.Util.validarRequerido(this.txtFechaNac.Text))
            {
                mensaje += "- Complete todos los campos" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarIguales(this.txtClave.Text,this.txtClave2.Text))
            {
                mensaje += "- Las claves no coinciden" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarMinLength(this.txtClave.Text,8))
            {
                mensaje += "- La clave debe tener al menos 8 caracteres" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarEmail(this.txtEmail.Text))
            {
                mensaje += "- Ingrese un Email válido" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarFecha(this.txtFechaNac.Text))
            {
                mensaje += "- Ingrese la fecha en formato dd/mm/yyyy" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarNumero(this.txtLegajo.Text))
            {
                mensaje += "- El legajo sólo puede contener números" + Environment.NewLine;
                error = true;
            }
            if(error){
                this.Notificar("Error de validación", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !error;
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
            if (this.Validar())
            {
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
