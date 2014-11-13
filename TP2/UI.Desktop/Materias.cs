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
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();
            this.dgvMaterias.DataSource = ul.GetAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop form = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (!(this.dgvMaterias.SelectedRows.Equals(null)))
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                if (MessageBox.Show("¿Esta seguro de querer eliminar?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    MateriaLogic oEntity = new MateriaLogic();
                    oEntity.Delete(ID);
                    this.Listar();
                }
            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);           
        
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (!(this.dgvMaterias.SelectedRows.Count.Equals(0)))
            {

                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formEdit = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formEdit.ShowDialog();
                this.Listar();

            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void dgvMaterias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tsbEditar_Click(sender,e);
        }
    }
}
