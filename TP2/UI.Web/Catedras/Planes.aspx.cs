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
            if (!Page.IsPostBack) this.LoadGrid();
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
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
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
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
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Plan();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
        #endregion

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