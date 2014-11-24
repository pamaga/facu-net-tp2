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
    public partial class Cursos : BaseABM
    {
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        private Curso Entity
        {
            get;
            set;
        }
        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.loadCmbComision();
                this.loadCmbMateria();
                this.LoadGrid();
            }
        }
        */
        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }
        /*
        private void loadCmbComision()
        {
            this.comisionDropDownList.DataSource = this.getPlanes();
            this.comisionDropDownList.DataTextField = "DescComision";
            this.comisionDropDownList.DataValueField = "IDComision";
            this.comisionDropDownList.DataBind();
        }

        private void loadCmbMateria()
        {
            this.materiaDropDownList.DataSource = this.getPlanes();
            this.materiaDropDownList.DataTextField = "DescMateria";
            this.materiaDropDownList.DataValueField = "IDMateria";
            this.materiaDropDownList.DataBind();
        }
        */
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
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
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
            this.anioTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
            this.planTextBox.Text = this.Entity.Plan;
            this.comisionDropDownList.SelectedValue = this.Entity.IDComision.ToString();
            this.materiaDropDownList.SelectedValue = this.Entity.IDMateria.ToString();
        }

        private void LoadEntity(Curso curso)
        {
            this.Entity.AnioCalendario = int.Parse(this.anioTextBox.Text);
            this.Entity.Cupo = int.Parse(this.cupoTextBox.Text);
            this.Entity.Plan = this.planTextBox.Text;
            this.Entity.IDComision = int.Parse(this.comisionDropDownList.SelectedValue);
            this.Entity.IDMateria = int.Parse(this.materiaDropDownList.SelectedValue);
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }

        private void EnableForm(bool enable)
        {
            this.anioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
            this.planTextBox.Enabled = enable;
            this.comisionDropDownList.Enabled = enable;
            this.materiaDropDownList.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.anioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
            this.planTextBox.Text = string.Empty;
            this.comisionDropDownList.ClearSelection();
            this.materiaDropDownList.ClearSelection();
        }
    }
}