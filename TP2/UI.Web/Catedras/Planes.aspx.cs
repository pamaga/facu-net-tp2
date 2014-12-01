using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web.Catedras
{
    public partial class Planes : BaseABM
    {
        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        private Plan Entity
        {
            get;
            set;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ToggleError(this.formError);
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                this.loadCmbEspecialidades();
            }
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }

        private void loadCmbEspecialidades()
        {
            this.especialidadDropDownList.DataSource = this.getEspecialidades();
            this.especialidadDropDownList.DataTextField = "Descripcion";
            this.especialidadDropDownList.DataValueField = "ID";
            this.especialidadDropDownList.DataBind();
        }

        #region Eventos
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
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
            this.Entity = new Plan();
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
            if (Validar())
            {
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
                this.formPanel.Visible = false;
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

            if (!Util.Util.validarRequerido(this.descripcionTextBox.Text))
            {
                mensaje += "- Complete todos los campos" + "<br />";
                error = true;
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
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.especialidadDropDownList.SelectedValue = this.Entity.IdEspecialidad.ToString();
        }

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IdEspecialidad = int.Parse(this.especialidadDropDownList.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.especialidadDropDownList.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.especialidadDropDownList.ClearSelection();
        }
    }
}