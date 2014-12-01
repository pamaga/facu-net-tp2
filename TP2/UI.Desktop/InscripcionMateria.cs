using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class InscripcionMateria : ApplicationForm
    {
        private Inscripcion _inscripcionActual;
        public Inscripcion InscripcionActual
        {
            get { return _inscripcionActual; }
            set { _inscripcionActual = value; }
        }

        private Usuario _alumnoActual;
        public Usuario AlumnoActual
        {
            get { return _alumnoActual; }
            set { _alumnoActual = value; }
        }

        public InscripcionMateria()
        {
            InitializeComponent();
        }

        public InscripcionMateria(Usuario AlumnoActual, ModoForm modo):this()
        {
            this.AlumnoActual = AlumnoActual;
            this.Modo = modo;
        }

        public InscripcionMateria(Usuario AlumnoActual, int IDInscripcion, ModoForm modo):this()
        {

            this.AlumnoActual = AlumnoActual;
            this.Modo = modo;
            InscripcionLogic logic = new InscripcionLogic();
            this.InscripcionActual = logic.GetOne(IDInscripcion);
        }

        private void InscripcionMateria_Load(object sender, EventArgs e)
        {
            this.lblNombreAlumno.Text = this.AlumnoActual.Nombre + " " + this.AlumnoActual.Apellido + " (" + this.AlumnoActual.Legajo + ")";

            PlanLogic pl = new PlanLogic();
            Plan planActual = pl.GetOne(AlumnoActual.IdPlan);
            this.lblNombrePlan.Text = planActual.DescCompleta;

            CursoLogic cl = new CursoLogic();
            this.cmbMateria.DataSource = cl.GetAllCursosAnio(AlumnoActual.IdPlan);
            this.cmbMateria.DisplayMember = "MateriaComision";
            this.cmbMateria.ValueMember = "ID";

            this.cmbCondicion.DataSource = Enum.GetValues(typeof(Condiciones));

            if(this.Modo.Equals(ModoForm.Alta)){
                this.cmbCondicion.SelectedIndex = 0;
                this.cmbCondicion.Enabled = false;
                this.txtNota.Enabled = false;
            }
            else if (this.Modo.Equals(ModoForm.Modificacion))
            {
                this.cmbMateria.Enabled = false;
                MapearDeDatos();
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.InscripcionActual.ID.ToString();
            this.cmbMateria.SelectedValue = this.InscripcionActual.IdCurso;
            this.cmbCondicion.SelectedItem = this.InscripcionActual.Condicion;
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();

            string txtAceptar = "Aceptar";

            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion)) txtAceptar = "Guardar";
            this.btnAceptar.Text = txtAceptar;
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.InscripcionActual = new Inscripcion();
                this.InscripcionActual.State = BusinessEntity.States.New;
                
                this.InscripcionActual.IdAlumno = this.AlumnoActual.ID;
                this.InscripcionActual.IdCurso = (int)this.cmbMateria.SelectedValue;
                this.InscripcionActual.Nota = 0;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.InscripcionActual.ID = Int32.Parse(txtID.Text);
                this.InscripcionActual.State = BusinessEntity.States.Modified;
                this.InscripcionActual.Nota = int.Parse(this.txtNota.Text);
            }
            this.InscripcionActual.Condicion = (Condiciones)this.cmbCondicion.SelectedValue;

        }

        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (
                (this.cmbMateria.SelectedValue == null && Modo.Equals(ModoForm.Alta)) ||
                (!Util.Util.validarRequerido(this.txtNota.Text) && Modo.Equals(ModoForm.Modificacion))
                )
            {
                mensaje += "- Complete todos los campos" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarNumero(this.txtNota.Text) && Modo.Equals(ModoForm.Modificacion))
            {
                mensaje += "- Ingrese un valor numérico para la nota" + Environment.NewLine;
                error = true;
            }

            InscripcionLogic iLogic = new InscripcionLogic();

            if (!iLogic.checkInscripcion(this.AlumnoActual.ID, (int)this.cmbMateria.SelectedValue) && Modo.Equals(ModoForm.Alta))
            {
                mensaje += "- El alumno ya se encuentra inscripto a esa materia" + Environment.NewLine;
                error = true;
            }


            if (error)
            {
                this.Notificar("Error de validación", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !error;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            InscripcionLogic iLogic = new InscripcionLogic();
            iLogic.Save(this.InscripcionActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

    }
}
