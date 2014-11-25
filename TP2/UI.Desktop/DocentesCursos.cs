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
    public partial class DocentesCursos : ApplicationForm
    {
        private Curso cursoActual = null;
        public DocentesCursos()
        {
            InitializeComponent();
           
        }
        public DocentesCursos(Curso cur):this()
        {
            this.cursoActual = cur;
            this.Listar();
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
           UsuarioLogic ul = new UsuarioLogic();
           
            this.cmbDocentes.DataSource =  ul.GetAll(TiposUsuarios.Docente);
            this.cmbDocentes.DisplayMember = "NombreCompleto";
            this.cmbDocentes.ValueMember = "ID";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            if (!ul.isAssignedDocenteToCurso((int)this.cmbDocentes.SelectedValue, (int)this.cursoActual.ID))
            {
                ul.addDocenteToCurso((int)this.cmbDocentes.SelectedValue, (int)this.cursoActual.ID);
            }
            else {
                MessageBox.Show("El docente ya esta asignado");
            }

           
            this.Listar();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvDocentes.AutoGenerateColumns = false;
            this.dgvDocentes.DataSource = ul.GetDocentesByCurso(this.cursoActual.ID);
        }

        private void dgvDocentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             DataGridView dg = (DataGridView)sender;
             Usuario cur = (Usuario)dg.CurrentRow.DataBoundItem;
            if (e.ColumnIndex == 2)
            {
                if (DialogResult.Yes == MessageBox.Show("Desea quitar el docente del curso", "Quitar el docente del curso?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) {
                     UsuarioLogic ul = new UsuarioLogic();
                     ul.removeDocenteToCurso(cur.ID, this.cursoActual.ID);
                     this.Listar();
                }
            }
        }
    }
}
