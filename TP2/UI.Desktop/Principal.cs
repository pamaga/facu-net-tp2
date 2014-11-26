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
    public partial class Principal : ApplicationForm
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
            BusinessLogic bl = new BusinessLogic();

            if (appLogin._activado)
            {
                if (appLogin.ShowDialog() != DialogResult.OK)
                {
                    this.Dispose();
                }
                else {
                    this.UsuarioLogueado = appLogin.Usr;
                    List<String> lstOptionNotAllowed = bl.getMenuNotAllowedByRol(appLogin.Usr);
                    foreach(String menu in lstOptionNotAllowed ){
                        ToolStripMenuItem ctrl = menuStrip1.Items.Find(menu, true)[0] as ToolStripMenuItem;
                        ctrl.Visible = false;
                    }

                    //this.personasToolStripMenuItem.Visible = false;

                    this.lblUsuario.Visible = true;
                    this.lblUsuario.Text = "Usuario: "+appLogin.Usr.NombreUsuario+" ("+appLogin.Usr.Nombre+" "+appLogin.Usr.Apellido+")";
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

        private void misMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void misMateriasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int ID = Util.Util.UsuarioLogueado.ID;

            AlumnosInscripciones formAi = new AlumnosInscripciones(ID);
            formAi.ShowDialog();
        }
    }
}
