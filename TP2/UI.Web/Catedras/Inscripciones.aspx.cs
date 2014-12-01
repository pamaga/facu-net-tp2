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
    public partial class Inscripciones : BaseABM
    {
        InscripcionLogic _logic;
        private InscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new InscripcionLogic();
                }
                return _logic;
            }
        }

        CursoLogic _cursoLogic;
        private CursoLogic CursoLogic
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursoLogic();
                }
                return _cursoLogic;
            }
        }

        private Inscripcion Entity
        {
            get;
            set;
        }

        Usuario _alumnoActual;
        public Usuario AlumnoActual
        {
            get { return _alumnoActual; }
            set { _alumnoActual = value; }
        }

        public Inscripciones(){
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ToggleError(this.formError);
            if (Session["tipo_usuario"].ToString().Equals("0") && !string.IsNullOrEmpty(Request.QueryString["id_alumno"]))
            {
                this.cargarAlumno(int.Parse(Request.QueryString["id_alumno"]));
            }
            else
            {
                this.cargarAlumno(int.Parse(Session["id_usuario"].ToString()));
                this.editarLinkButton.Visible = false;
                this.eliminarLinkButton.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                loadCmbMaterias();
                loadCmbCondiciones(); 

                PlanLogic pl = new PlanLogic();
                Plan planActual = pl.GetOne(AlumnoActual.IdPlan);
                this.lblNombrePlan.Text = planActual.DescCompleta;
            }           
        }

        private void loadCmbMaterias(){
            List<Curso> a = CursoLogic.GetAllCursosAnio(AlumnoActual.IdPlan);
            this.cmbMateria.DataSource = a;
            this.cmbMateria.DataTextField = "MateriaComision";
            this.cmbMateria.DataValueField = "ID";
            this.cmbMateria.DataBind();
        }

        private void loadCmbCondiciones(){
            this.cmbCondicion.DataSource = Enum.GetValues(typeof(Condiciones));
            this.cmbCondicion.DataBind();
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = this.CursoLogic.GetCursosAlumno(this.AlumnoActual.ID);
            this.GridView.DataKeyNames = new string[] { "IdInscripcion" };
            this.GridView.DataBind();
        }

        private void cargarAlumno(int IdAlumno)
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.AlumnoActual = ul.GetOne(IdAlumno);
            this.lblNombreAlumno.Text = this.AlumnoActual.NombreCompleto;
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
                this.LoadForm(this.SelectedID);

                this.cmbCondicion.Enabled = true;
                this.txtNota.Enabled = true;
                this.cmbMateria.Enabled = false;
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

            this.cmbCondicion.SelectedIndex = 0;
            this.cmbCondicion.Enabled = false;
            this.txtNota.Enabled = false;
            this.cmbMateria.Enabled = true;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new Inscripcion();
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

            if (this.cmbMateria.SelectedValue == null && FormMode.Equals(FormModes.Alta) ||
                (!Util.Util.validarRequerido(this.txtNota.Text) && FormMode.Equals(FormModes.Modificacion)))
            {
                mensaje += "- Complete todos los campos" + "<br />";
                error = true;
            }

            if ((!Util.Util.validarNumero(this.txtNota.Text) && FormMode.Equals(FormModes.Modificacion)))
            {
                mensaje += "- Ingrese un valor numérico para la nota" + "<br />";
                error = true;
            }

            if (!Logic.checkInscripcion(this.AlumnoActual.ID, int.Parse(this.cmbMateria.SelectedValue)) && FormMode.Equals(FormModes.Alta))
            {
                mensaje += "- El alumno ya se encuentra inscripto a esa materia" + "<br />";
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
            
            PlanLogic pl = new PlanLogic();
            Plan planActual = pl.GetOne(AlumnoActual.IdPlan);
            this.lblNombrePlan.Text = planActual.DescCompleta;

            this.cmbMateria.SelectedValue = this.Entity.IdCurso.ToString();
            this.cmbCondicion.SelectedIndex = (int)Enum.Parse(typeof(Condiciones), this.Entity.Condicion.ToString());
            this.txtNota.Text = this.Entity.Nota.ToString();
        }

        private void LoadEntity(Inscripcion insc)
        {

            insc.IdAlumno = this.AlumnoActual.ID;
            insc.IdCurso = int.Parse(this.cmbMateria.SelectedValue);
            insc.Condicion = (Condiciones)Enum.Parse(typeof(Condiciones),this.cmbCondicion.SelectedItem.Text);
            if (FormMode.Equals(FormModes.Alta))
            {
                insc.Nota = 0;
            }
            else if (FormMode.Equals(FormModes.Modificacion))
            {
                insc.Nota = int.Parse(this.txtNota.Text);
            }
        }

        private void SaveEntity(Inscripcion insc)
        {
            this.Logic.Save(insc);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.cmbMateria.ClearSelection();
            this.cmbCondicion.ClearSelection();
            this.txtNota.Text = string.Empty;
        }
    }
}