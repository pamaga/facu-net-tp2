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
    public partial class Materias : BaseABM
    {
        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if(_logic==null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private Materia Entity
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
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
            this.horasSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.horasTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            this.planDescripcionTextBox.Text = this.Entity.Plan;
        }

        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = this.descripcionTextBox.Text;
            materia.IDPlan = Int32.Parse(this.idPlanTextBox.Text);
            materia.HSSemanales = Int32.Parse(this.horasSemanalesTextBox.Text);
            materia.HSTotales = Int32.Parse(this.horasTotalesTextBox.Text);
            materia.Plan = this.planDescripcionTextBox.Text;
        }

        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
            this.horasSemanalesTextBox.Enabled = enable;
            this.horasTotalesTextBox.Enabled = enable;
            this.planDescripcionTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
            this.horasSemanalesTextBox.Text = string.Empty;
            this.horasTotalesTextBox.Text = string.Empty;
            this.planDescripcionTextBox.Text = string.Empty;
        }
    }
}