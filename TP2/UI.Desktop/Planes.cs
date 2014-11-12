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
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
             this.dgvPlanes.AutoGenerateColumns = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Listar(){
            PlanLogic ul = new PlanLogic();
            this.dgvPlanes.DataSource = ul.GetAll();
        }
  

        private void Planes_Load(object sender, EventArgs e)
        {
         this.Listar();
        }

         private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

         private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (!(this.dgvPlanes.SelectedRows.Count.Equals(0)))
            {
                
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formEdit = new PlanDesktop(ID,ApplicationForm.ModoForm.Modificacion);
                formEdit.ShowDialog();
                this.Listar();
                 
            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvPlanes.SelectedRows.Equals(null)))
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                if (MessageBox.Show("¿Esta seguro de querer eliminar?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    PlanLogic oEntity = new PlanLogic();
                    oEntity.Delete(ID);
                    this.Listar();
                }
            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPlanes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbEditar_Click_1(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvPlanes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvPlanes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tsbEditar_Click_1(sender, e);
        }

        private void tsUsuarios_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

      
    }
}




