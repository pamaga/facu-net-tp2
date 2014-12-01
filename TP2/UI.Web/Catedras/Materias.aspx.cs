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
            this.Entity = new Materia();
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

            if (!Util.Util.validarRequerido(this.descripcionTextBox.Text) ||
                !Util.Util.validarRequerido(this.horasSemanalesTextBox.Text) ||
                !Util.Util.validarRequerido(this.horasTotalesTextBox.Text) ||
                !Util.Util.validarRequerido(this.especialidadDropDownList.SelectedValue) ||
                !Util.Util.validarRequerido(this.planDropDownList.SelectedValue))
            {
                mensaje += "- Complete todos los campos" + "<br />";
                error = true;
            }

            if (!Util.Util.validarNumero(this.horasSemanalesTextBox.Text) ||
               !Util.Util.validarNumero(this.horasTotalesTextBox.Text))
            {
                mensaje += "- Ingrese un valor numérico para las horas" + Environment.NewLine;
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
            this.especialidadDropDownList.SelectedValue = this.Entity.IDEspecialidad.ToString();
            this.loadCmbPlan(this.Entity.IDEspecialidad);
            this.planDropDownList.SelectedValue = this.Entity.IDPlan.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.horasSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.horasTotalesTextBox.Text = this.Entity.HSTotales.ToString();
        }

        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = this.descripcionTextBox.Text;
            materia.IDPlan = Int32.Parse(this.planDropDownList.SelectedValue);
            materia.IDEspecialidad = Int32.Parse(this.especialidadDropDownList.SelectedValue);
            materia.HSSemanales = Int32.Parse(this.horasSemanalesTextBox.Text);
            materia.HSTotales = Int32.Parse(this.horasTotalesTextBox.Text);
        }

        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.horasSemanalesTextBox.Enabled = enable;
            this.horasTotalesTextBox.Enabled = enable;
            this.especialidadDropDownList.Enabled = enable;
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
            this.horasSemanalesTextBox.Text = string.Empty;
            this.horasTotalesTextBox.Text = string.Empty;
            this.especialidadDropDownList.ClearSelection();
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