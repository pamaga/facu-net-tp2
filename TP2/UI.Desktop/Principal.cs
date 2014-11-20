using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin._activado)
            {
                if (appLogin.ShowDialog() != DialogResult.OK)
                {
                    this.Dispose();
                }
            }

        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios form = new Usuarios(TiposUsuarios.Alumno);
            form.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades();
            esp.ShowDialog();
        }

        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

          Planes plan = new Planes();
          plan.ShowDialog();
            
        }

        private void cursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursos form = new Cursos();
            form.ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones form = new Comisiones();
            form.ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias form = new Materias();
            form.ShowDialog();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reporteMaterias form = new reporteMaterias();
            form.ShowDialog();

        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios form = new Usuarios(TiposUsuarios.Docente);
            form.ShowDialog();
        }
    }
}
