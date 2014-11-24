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
    public partial class Comisiones : BaseABM
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

        private Comision Entity
        {
            get;
            set;
        }

        private int SelectedEspecialidad
        {
            get
            {
                if (this.ViewState["SelectedEspecialidad"] != null) return (int)this.ViewState["SelectedEspecialidad"];
                else return 0;
            }
            set
            {
                this.ViewState["SelectedEspecialidad"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void loadCmbPlan(int IDEspecialidad)
        {
            this.planDropDownList.DataSource = this.getPlanes(IDEspecialidad);
            this.planDropDownList.DataTextField = "Descripcion";
            this.planDropDownList.DataValueField = "ID";
            this.planDropDownList.DataBind();
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
            this.especialidadDropDownList.SelectedValue = this.Entity.IDEspecialidad.ToString();
            this.loadCmbPlan(this.Entity.IDEspecialidad);
            this.planDropDownList.SelectedValue = this.Entity.IDPlan.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.anioEspecialidadTextBox.Text = this.Entity.AnioEspecialidad.ToString();
        }

        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = this.descripcionTextBox.Text;
            comision.IDPlan = int.Parse(this.planDropDownList.SelectedValue);
            comision.IDEspecialidad = Int32.Parse(this.especialidadDropDownList.SelectedValue);
            comision.AnioEspecialidad = Int32.Parse(this.anioEspecialidadTextBox.Text);
        }

        private void SaveEntity(Comision comision)
        {
            this.Logic.Save(comision);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.especialidadDropDownList.Enabled = enable;
            this.anioEspecialidadTextBox.Enabled = enable;
            if (this.FormMode == FormModes.Alta) this.planDropDownList.Enabled = !enable;
            else this.planDropDownList.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.especialidadDropDownList.ClearSelection();
            this.anioEspecialidadTextBox.Text = string.Empty;
            this.planDropDownList.Items.Insert(0, new ListItem("Seleccione una especialidad", "-1"));
            this.planDropDownList.SelectedValue = "-1";
        }

        protected void especialidadDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedEspecialidad = int.Parse(this.especialidadDropDownList.SelectedValue);
            if (this.SelectedEspecialidad != -1)
            {
                int IDEspecialidad = int.Parse(especialidadDropDownList.SelectedValue);
                this.loadCmbPlan(IDEspecialidad);
                this.planDropDownList.Enabled = true;
            }
            else
            {
                this.planDropDownList.Enabled = false;
                this.planDropDownList.Items.Insert(0, new ListItem("Seleccione una especialidad", "-1"));
                this.planDropDownList.SelectedValue = "-1";
            }
        }
    }
}