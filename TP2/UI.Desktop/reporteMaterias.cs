using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data.Database;

namespace UI.Desktop
{
    public partial class reporteMaterias : Form
    {
        public reporteMaterias()
        {
            InitializeComponent();
        }

        private void reporteMaterias_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.SPEstadoAcademicoAlumno' Puede moverla o quitarla según sea necesario.
            this.SPEstadoAcademicoAlumnoTableAdapter.Fill(DataSet1.SPEstadoAcademicoAlumno, Convert.ToInt32(Util.Util.UsuarioLogueado.ID));
            

            this.MateriaBindingSource.DataSource = new MateriaAdapter().GetAll();
            this.reportViewer1.RefreshReport();
        }

        private void reporteMaterias_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.reportViewer1.Reset();
        }
    }
}
