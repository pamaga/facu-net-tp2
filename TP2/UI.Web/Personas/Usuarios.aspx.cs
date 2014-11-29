using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web.Personas
{
    public partial class Usuarios : BaseABM
    {
        private UsuarioLogic _Logic;
        public UsuarioLogic Logic
        {
            get
            {
                if (_Logic == null) _Logic = new UsuarioLogic();
                return _Logic;
            }
        }

        private Usuario Entity
        {
            get;
            set;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ToggleError(this.formError);
            if (!Page.IsPostBack){
                this.LoadGrid();
                LoadCmbPlanes();
            }
            DiffUsuarios();
        }

        private void LoadCmbPlanes(){
            PlanLogic pl = new PlanLogic();
            this.cmbPlan.DataSource = pl.GetAll();
            this.cmbPlan.DataTextField = "DescCompleta";
            this.cmbPlan.DataValueField = "ID";
            this.cmbPlan.DataBind();
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll( (TiposUsuarios)Enum.Parse(typeof(TiposUsuarios),Request.QueryString["TipoUsuario"]) );
            this.gridView.DataBind();
        }

        #region Eventos
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedID);
                this.formPanel.Visible = false;
                this.FormMode = FormModes.Baja;
                this.LoadGrid();
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    if(Validar()){
                        this.SaveEntity(this.Entity);
                        this.formPanel.Visible = false;
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    if (Validar())
                    {
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.formPanel.Visible = false;
                    }
                    break;
                default:
                    break;
            }
            this.LoadGrid();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
        #endregion


        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + "<br />";

            if (
                !Util.Util.validarRequerido(this.nombreTextBox.Text) ||
                !Util.Util.validarRequerido(this.apellidoTextBox.Text) ||
                !Util.Util.validarRequerido(this.emailTextBox.Text) ||
                !Util.Util.validarRequerido(this.nombreUsuarioTextBox.Text) ||
                !Util.Util.validarRequerido(this.claveTextBox.Text) ||
                !Util.Util.validarRequerido(this.repetirClaveTextBox.Text) ||
                !Util.Util.validarRequerido(this.txtTelefono.Text) ||
                !Util.Util.validarRequerido(this.txtLegajo.Text) ||
                !Util.Util.validarRequerido(this.txtFechaNac.Text))
            {
                mensaje += "- Complete todos los campos" + "<br />";
                error = true;
            }

            if (!Util.Util.validarIguales(this.claveTextBox.Text, this.repetirClaveTextBox.Text))
            {
                mensaje += "- Las claves no coinciden" + "<br />";
                error = true;
            }

            if (!Util.Util.validarMinLength(this.claveTextBox.Text, 8))
            {
                mensaje += "- La clave debe tener al menos 8 caracteres" + "<br />";
                error = true;
            }

            if (!Util.Util.validarEmail(this.emailTextBox.Text))
            {
                mensaje += "- Ingrese un Email válido" + "<br />";
                error = true;
            }

            if (!Util.Util.validarFecha(this.txtFechaNac.Text))
            {
                mensaje += "- Ingrese la fecha en formato dd/mm/yyyy" + "<br />";
                error = true;
            }

            if (!Util.Util.validarNumero(this.txtLegajo.Text))
            {
                mensaje += "- El legajo sólo puede contener números" + "<br />";
                error = true;
            }

            if (Util.Util.validarRequerido(this.txtLegajo.Text))
            {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario usr = ul.getUserByLegajo(Convert.ToInt32(this.txtLegajo.Text));
                if ((this.FormMode == FormModes.Alta && usr != null) || (this.FormMode == FormModes.Modificacion && usr != null && this.Entity.ID != usr.ID))
                {
                    mensaje += "- El usuario con el legajo ingresado ya existe" + "<br />";
                    error = true;
                }
            }

            if (error)
            {
                this.ToggleError(this.formError, mensaje);
            }
            else
            {
                this.ToggleError(this.formError);
            }
            return !error;
        }

        private void ToggleError(Label lblError)
        {
            lblError.CssClass = "";
            lblError.Text = "";
        }

        private void ToggleError(Label lblError, string msj)
        {
            lblError.CssClass = "formError";
            lblError.Text = msj;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.EMail;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
            claveTextBox.Attributes["value"] = this.Entity.Clave;
            repetirClaveTextBox.Attributes["value"] = this.Entity.Clave;
            this.txtLegajo.Text = this.Entity.Legajo.ToString();
            this.txtTelefono.Text = this.Entity.Telefono;
            this.txtFechaNac.Text = this.Entity.FechaNac;
            this.cmbPlan.SelectedValue = this.Entity.IdPlan.ToString();
        }

        private void DiffUsuarios(){
            if(TiposUsuarios.Alumno != ((TiposUsuarios)Enum.Parse(typeof(TiposUsuarios), Request.QueryString["TipoUsuario"]))){
                this.lblPlan.Visible = false;
                this.cmbPlan.Visible = false;
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.EMail = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Legajo = int.Parse(this.txtLegajo.Text);
            usuario.Telefono = this.txtTelefono.Text;
            usuario.FechaNac = this.txtFechaNac.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
            usuario.IdPlan = int.Parse(this.cmbPlan.SelectedValue);
            usuario.TipoUsuario = (TiposUsuarios)Enum.Parse(typeof(TiposUsuarios), Request.QueryString["TipoUsuario"]);
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.txtLegajo.Visible = enable;
            this.txtTelefono.Visible = enable;
            this.txtFechaNac.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtFechaNac.Text = string.Empty;
            claveTextBox.Attributes["value"] = string.Empty;
            repetirClaveTextBox.Attributes["value"] = string.Empty;
        }
    }
}