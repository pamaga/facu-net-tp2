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
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop form = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        public void Listar()
        {
            ComisionLogic ul = new ComisionLogic();
            this.dgvComisiones.DataSource = ul.GetAll();
        }

        private void dgvComisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsUsuarios_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Listar();
            MessageBox.Show("actualizado");
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvComisiones.SelectedRows.Count.Equals(0)))
            {

                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formEdit = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formEdit.ShowDialog();
                this.Listar();

            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void dgvComisiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tsbEditar_Click(sender, e);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvComisiones.SelectedRows.Equals(null)))
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                if (MessageBox.Show("¿Esta seguro de querer eliminar?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    ComisionLogic oEntity = new ComisionLogic();
                    oEntity.Delete(ID);
                    this.Listar();
                }
            }
            else this.Notificar("No hay fila seleccionada", "Por favor, seleccione una fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);           
        
        }

        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
