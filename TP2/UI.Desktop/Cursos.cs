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
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            
        }

        public void Listar()
        {
            CursoLogic ul = new CursoLogic();
            if(Util.Util.UsuarioLogueado.TipoUsuario.Equals(TiposUsuarios.Docente)){
                this.dgvCursos.DataSource = ul.GetAllDocente(Util.Util.UsuarioLogueado.ID);
            }else{
                this.dgvCursos.DataSource = ul.GetAll();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
            if (Util.Util.UsuarioLogueado.TipoUsuario == TiposUsuarios.Docente) {
                this.dgvCursos.Columns[6].Visible = false;
                this.tsCursos.Enabled = false;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop form = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvCursos.SelectedRows.Count.Equals(0)))
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop formEdit = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formEdit.ShowDialog();
                this.Listar();

            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvCursos.SelectedRows.Equals(null)))
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                if (MessageBox.Show("¿Esta seguro de querer eliminar?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    CursoLogic oEntity = new CursoLogic();
                    oEntity.Delete(ID);
                    this.Listar();
                }
            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dg = (DataGridView)sender;
            Curso cur = (Curso) dg.CurrentRow.DataBoundItem;
            if (e.ColumnIndex == 6 )
            {
               
                DocentesCursos dc = new DocentesCursos(cur);
                dc.Show();         
            }
         }
     }
}
