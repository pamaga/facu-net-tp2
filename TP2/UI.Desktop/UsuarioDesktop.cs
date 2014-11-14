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

        public UsuarioDesktop(ModoForm modo, TiposUsuarios TipoUsuario)
            : this()
        {
            this.TipoUsuario = TipoUsuario;
            this.Modo = modo;
            this.Text = this.Modo.ToString() + " de " + this.TipoUsuario.ToString();
        }

        public UsuarioDesktop(int ID, ModoForm modo, TiposUsuarios TipoUsuario)
            : this()
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
            if (this.txtNombre.Text == string.Empty ||
                this.txtApellido.Text == string.Empty ||
                this.txtEmail.Text == string.Empty ||
                this.txtUsuario.Text == string.Empty ||
                this.txtClave.Text == string.Empty ||
                this.txtClave2.Text == string.Empty ||
                this.txtTelefono.Text == string.Empty ||
                this.txtLegajo.Text == string.Empty ||
                this.txtFechaNac.Text == string.Empty)
            {
                this.Notificar("Error de validación", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }

            if (!this.txtClave.Text.Equals(this.txtClave2.Text))
            {
                this.Notificar("Error de validación", "Las claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Focus();
                return false;
            }

            if (this.txtClave.Text.Length < 8)
            {
                this.Notificar("Error de validación", "La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Focus();
                return false;
            }

            if (!Regex.IsMatch(this.txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                this.Notificar("Error de validación", "Ingrese un Email válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtEmail.Focus();
                return false;
            }

            if (!Regex.IsMatch(this.txtFechaNac.Text, @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", RegexOptions.IgnoreCase))
            {
                this.Notificar("Error de validación", "Ingrese la fecha en formato dd/mm/yyyy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtLegajo.Focus();
                return false;
            }

            if (!Regex.IsMatch(this.txtLegajo.Text, @"^\d+$", RegexOptions.IgnoreCase))
            {
                this.Notificar("Error de validación", "El legajo sólo puede contener números", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtLegajo.Focus();
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

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
