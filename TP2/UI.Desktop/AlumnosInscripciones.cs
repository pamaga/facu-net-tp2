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

    public partial class AlumnosInscripciones : ApplicationForm
    {

        Usuario _alumnoActual;
        public Usuario AlumnoActual
        {
            get { return _alumnoActual; }
            set { _alumnoActual = value; }
        }

        public AlumnosInscripciones(int IdAlumno):this()
        {
            cargarAlumno(IdAlumno);
        }

        public AlumnosInscripciones()
        {
            InitializeComponent();
            this.dgvAluInsc.AutoGenerateColumns = false;
        }

        private void cargarAlumno(int IdAlumno){
            UsuarioLogic ul = new UsuarioLogic();
            this.AlumnoActual = ul.GetOne(IdAlumno);
            this.Text = "Materias de " + this.AlumnoActual.Nombre + " " + this.AlumnoActual.Apellido;
        }

        private void AlumnosInscripciones_Load(object sender, EventArgs e)
        {
            if(Util.Util.UsuarioLogueado.TipoUsuario > 0){
                this.btnEditar.Visible = false;
                this.btnEliminar.Visible = false;
            }
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvAluInsc.DataSource = cl.GetCursosAlumno(this.AlumnoActual.ID);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            InscripcionMateria form = new InscripcionMateria(AlumnoActual, ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvAluInsc.SelectedRows.Count.Equals(0)))
            {
                int IdInscripcion = ((Business.Entities.Curso)this.dgvAluInsc.SelectedRows[0].DataBoundItem).IdInscripcion;
                InscripcionMateria formEdit = new InscripcionMateria(AlumnoActual, IdInscripcion, ApplicationForm.ModoForm.Modificacion);
                formEdit.ShowDialog();
                this.Listar();

            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvAluInsc.SelectedRows.Equals(null)))
            {
                int IdInscripcion = ((Business.Entities.Curso)this.dgvAluInsc.SelectedRows[0].DataBoundItem).IdInscripcion;
                if (MessageBox.Show("¿Esta seguro de querer eliminar?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    InscripcionLogic oEntity = new InscripcionLogic();
                    oEntity.Delete(IdInscripcion);
                    this.Listar();
                }
            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
