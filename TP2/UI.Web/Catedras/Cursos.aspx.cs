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
        #region PROPIEDADES
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

        private int SelectedPlan
        {
            get
            {
                if (this.ViewState["SelectedPlan"] != null) return (int)this.ViewState["SelectedPlan"];
                else return 0;
            }
            set
            {
                this.ViewState["SelectedPlan"] = value;
            }
        }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ToggleError(this.formError);
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                this.loadCmbEspecialidades();
                loadCmbDocentes();
            }
        }

        #region DATABIND
        private void LoadGrid()
        {
            if (Session["tipo_usuario"].ToString().Equals("1"))
            {
                this.GridView.DataSource = this.Logic.GetAllDocente((int)Session["id_usuario"]);
                this.nuevoLinkButton.Visible = false;
                this.editarLinkButton.Visible = false;
                this.eliminarLinkButton.Visible = false;
            }else{
                this.GridView.DataSource = this.Logic.GetAll();
            }
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

        private void loadCmbComision(int IDPlan)
        {
            this.comisionDropDownList.DataSource = this.getComisiones(IDPlan);
            this.comisionDropDownList.DataTextField = "Descripcion";
            this.comisionDropDownList.DataValueField = "ID";
            this.comisionDropDownList.DataBind();
        }

        private void loadCmbMateria(int IDPlan)
        {
            this.materiaDropDownList.DataSource = this.getMaterias(IDPlan);
            this.materiaDropDownList.DataTextField = "Descripcion";
            this.materiaDropDownList.DataValueField = "ID";
            this.materiaDropDownList.DataBind();
        }

        private void loadCmbDocentes()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.cmbDocentes.DataSource = ul.GetAll(TiposUsuarios.Docente);
            this.cmbDocentes.DataTextField = "NombreCompleto";
            this.cmbDocentes.DataValueField = "ID";
            this.cmbDocentes.DataBind();
        }
        #endregion

        #region EVENTOS
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
            this.Entity = new Curso();
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

        protected void especialidadDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedEspecialidad = int.Parse(this.especialidadDropDownList.SelectedValue);
            if (this.SelectedEspecialidad != -1)
            {
                this.loadCmbPlan(this.SelectedEspecialidad);
                this.planDropDownList.Enabled = true;
            }
            else
            {
                this.planDropDownList.Enabled = false;
            }
            this.ddlPlanReset();
            this.materiaDropDownList.Enabled = false;
            this.ddlMateriaReset();
            this.comisionDropDownList.Enabled = false;
            this.ddlComisionReset();
        }

        protected void planDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedPlan = int.Parse(this.planDropDownList.SelectedValue);
            if (this.SelectedPlan != -1)
            {
                this.loadCmbMateria(this.SelectedPlan);
                this.loadCmbComision(this.SelectedPlan);
                this.materiaDropDownList.Enabled = true;
                this.comisionDropDownList.Enabled = true;
            }
            else
            {
                this.materiaDropDownList.Enabled = false;
                this.ddlMateriaReset();
                this.comisionDropDownList.Enabled = false;
                this.ddlComisionReset();
            }
        }
        #endregion


        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + "<br />";

            if (!Util.Util.validarRequerido(this.anioTextBox.Text) ||
                !Util.Util.validarRequerido(this.cupoTextBox.Text) ||
                !Util.Util.validarRequerido(this.especialidadDropDownList.SelectedValue) ||
                !Util.Util.validarRequerido(this.planDropDownList.SelectedValue) ||
                !Util.Util.validarRequerido(this.materiaDropDownList.SelectedValue) ||
                !Util.Util.validarRequerido(this.comisionDropDownList.SelectedValue))
            {
                mensaje += "- Complete todos los campos" + "<br />";
                error = true;
            }

            if (!Util.Util.validarNumero(this.anioTextBox.Text) ||
               !Util.Util.validarLength(this.anioTextBox.Text,4))
            {
                mensaje += "- Ingrese el año en formato yyyy" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarNumero(this.anioTextBox.Text) ||
                !Util.Util.validarNumero(this.cupoTextBox.Text))
            {
                mensaje += "- Ingrese un valor numérico para el cupo" + Environment.NewLine;
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
            this.anioTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
            this.especialidadDropDownList.SelectedValue = this.Entity.IDEspecialidad.ToString();
            this.loadCmbPlan(this.Entity.IDEspecialidad);
            this.planDropDownList.SelectedValue = this.Entity.IDPlan.ToString();
            this.loadCmbComision(this.Entity.IDPlan);
            this.comisionDropDownList.SelectedValue = this.Entity.IDComision.ToString();
            this.loadCmbMateria(this.Entity.IDPlan);
            this.materiaDropDownList.SelectedValue = this.Entity.IDMateria.ToString();

            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> docentes = ul.GetDocentesByCurso(id);
            this.cmbDocentes.ClearSelection();
            foreach (Usuario docente in docentes)
            {
                this.cmbDocentes.Items.FindByValue(docente.ID.ToString()).Selected = true;
            }
        }

        private void LoadEntity(Curso curso)
        {
            this.Entity.AnioCalendario = int.Parse(this.anioTextBox.Text);
            this.Entity.Cupo = int.Parse(this.cupoTextBox.Text);
            this.Entity.IDEspecialidad = int.Parse(this.especialidadDropDownList.SelectedValue);
            this.Entity.IDPlan = int.Parse(this.planDropDownList.SelectedValue);
            this.Entity.IDComision = int.Parse(this.comisionDropDownList.SelectedValue);
            this.Entity.IDMateria = int.Parse(this.materiaDropDownList.SelectedValue);
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
            saveDocentes(curso.ID);
        }

        private void saveDocentes(int IdCurso){
            UsuarioLogic ul = new UsuarioLogic();

            int[] docentes = this.cmbDocentes.GetSelectedIndices();
            string noRemover = "";
            foreach (int docente in docentes)
            {
                int IdDocente = int.Parse(this.cmbDocentes.Items[docente].Value);
                noRemover += "," + IdDocente.ToString();
                if (!ul.isAssignedDocenteToCurso(IdDocente, IdCurso))
                {
                    ul.addDocenteToCurso(IdDocente, IdCurso);
                }
            }
            if (!noRemover.Equals("")) noRemover = noRemover.Substring(1);
            ul.removeDocentesFromCurso(noRemover, IdCurso);
        }

        private void EnableForm(bool enable)
        {
            this.anioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
            this.especialidadDropDownList.Enabled = enable;
            if (this.FormMode == FormModes.Alta)
            {
                this.planDropDownList.Enabled = !enable;
                this.comisionDropDownList.Enabled = !enable;
                this.materiaDropDownList.Enabled = !enable;
            }
            else
            {
                this.planDropDownList.Enabled = enable;
                this.comisionDropDownList.Enabled = enable;
                this.materiaDropDownList.Enabled = enable;
            }
        }

        private void DeleteEntity(int id)
        {
            this.deleteDocentes(id);
            this.Logic.Delete(id);
        }


        private void deleteDocentes(int IdCurso)
        {
            UsuarioLogic ul = new UsuarioLogic();
            ul.removeDocentesFromCurso("", IdCurso);
        }


        private void ClearForm()
        {
            this.anioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
            this.especialidadDropDownList.ClearSelection();
            this.ddlPlanReset();
            this.ddlComisionReset();
            this.ddlMateriaReset();
            this.cmbDocentes.ClearSelection();
        }

        protected void ddlPlanReset()
        {
            this.planDropDownList.Items.Insert(0, new ListItem("Seleccione una especialidad", "-1"));
            this.planDropDownList.SelectedValue = "-1";
        }

        protected void ddlMateriaReset()
        {
            this.materiaDropDownList.Items.Insert(0, new ListItem("Seleccione un plan", "-1"));
            this.materiaDropDownList.SelectedValue = "-1";
        }

        protected void ddlComisionReset()
        {
            this.comisionDropDownList.Items.Insert(0, new ListItem("Seleccione un plan", "-1"));
            this.comisionDropDownList.SelectedValue = "-1";
        }
    }
}