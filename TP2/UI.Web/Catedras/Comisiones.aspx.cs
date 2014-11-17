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
    public partial class Comisiones : System.Web.UI.Page
    {
        ComisionLogic _logic;
        private ComisionLogic Logic
        {
            get
            {
                if(_logic==null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        public enum FormModes { Alta, Baja, Modificacion }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Comision Entity
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
                else return 0;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
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
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
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
            this.idPlanTextBox.Text = this.Entity.IDPlan.ToString();
            this.planDescripcionTextBox.Text = this.Entity.PlanDescripcion;
            this.anioEspecialidadTextBox.Text = this.Entity.AnioEspecialidad.ToString();
        }

        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = this.descripcionTextBox.Text;
            comision.IDPlan = Int32.Parse(this.idPlanTextBox.Text);
            comision.PlanDescripcion = this.planDescripcionTextBox.Text;
            comision.AnioEspecialidad = Int32.Parse(this.anioEspecialidadTextBox.Text);
        }

        private void SaveEntity(Comision comision)
        {
            this.Logic.Save(comision);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
            this.planDescripcionTextBox.Enabled = enable;
            this.anioEspecialidadTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
            this.planDescripcionTextBox.Text = string.Empty;
            this.anioEspecialidadTextBox.Text = string.Empty;
        }
    }
}