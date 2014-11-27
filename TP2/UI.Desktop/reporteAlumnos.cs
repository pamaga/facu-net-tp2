using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class reporteAlumnos : Form
    {
        public reporteAlumnos()
        {
            InitializeComponent();
        }

        private void reporteAlumnos_Load(object sender, EventArgs e)
        {
            this.txtAnio.Text =  DateTime.Now.Year.ToString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.SPreporteAlumnosYMateriasDocentes' Puede moverla o quitarla según sea necesario.
            this.SPreporteAlumnosYMateriasDocentesTableAdapter.Fill(this.DataSet1.SPreporteAlumnosYMateriasDocentes, Convert.ToInt32(this.txtAnio.Text), Util.Util.UsuarioLogueado.ID);

            this.reportViewer1.RefreshReport();
        }

        private void reporteAlumnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.reportViewer1.Reset();
        }
    }
}
