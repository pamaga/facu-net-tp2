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
    public partial class CursoDesktop : ApplicationForm
    {
        private Curso _Curso;
        public Curso Curso
        {
          get { return _Curso; }
          set { _Curso = value; }
        }

        public CursoDesktop()
        {
            InitializeComponent();
            this.loadCmbEspecialidades();
        }

        public CursoDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
            this.cmbEnable(false);
            this.cmbEspecialidades.SelectedItem = null;
        }

        public CursoDesktop(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            CursoLogic logic = new CursoLogic();
            this.Curso = logic.GetOne(ID);
            MapearDeDatos();
            this.cmbEnable(true);
        }

        private void loadCmbEspecialidades()
        {
            this.cmbEspecialidades.DisplayMember = "Descripcion";
            this.cmbEspecialidades.ValueMember = "ID";
            this.cmbEspecialidades.DataSource = this.getEspecialidades();
        }

        private void loadCmbPlanes(int IDEspecialidad)
        {
            this.cmbPlanes.DisplayMember = "Descripcion";
            this.cmbPlanes.ValueMember = "ID";
            this.cmbPlanes.DataSource = this.getPlanes(IDEspecialidad);
        }

        private void loadCmbMaterias(int IDPlan)
        {
            MateriaLogic MatLogic = new MateriaLogic();
            this.cmbMaterias.DataSource = MatLogic.GetSome(IDPlan);
            this.cmbMaterias.DisplayMember = "Descripcion";
            this.cmbMaterias.ValueMember = "ID";
        }

        private void loadCmbComisiones(int IDPlan)
        {
            ComisionLogic ComLogic = new ComisionLogic();
            this.cmbComisiones.DataSource = ComLogic.GetSome(IDPlan);
            this.cmbComisiones.DisplayMember = "Descripcion";
            this.cmbComisiones.ValueMember = "ID";
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.Curso.ID.ToString();
            this.txtCupo.Text = Curso.Cupo.ToString();
            this.txtAnio.Text = Curso.AnioCalendario.ToString();
            this.cmbEspecialidades.SelectedValue = Curso.IDEspecialidad;
            this.loadCmbPlanes(Curso.IDEspecialidad);
            this.cmbPlanes.SelectedValue = Curso.IDPlan;
            this.loadCmbMaterias(Curso.IDPlan);
            this.cmbMaterias.SelectedValue = Curso.IDMateria;
            this.loadCmbComisiones(Curso.IDPlan);
            this.cmbComisiones.SelectedValue = Curso.IDComision;
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.Curso = new Curso();
                this.Curso.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.Curso.ID = Int32.Parse(txtID.Text);
                this.Curso.State = BusinessEntity.States.Modified;
            }

            this.Curso.IDComision = (int)this.cmbComisiones.SelectedValue;
            this.Curso.IDMateria = (int)this.cmbMaterias.SelectedValue;
            this.Curso.AnioCalendario = Convert.ToInt32(this.txtAnio.Text);
            this.Curso.Cupo = Convert.ToInt32(this.txtCupo.Text);
            this.Curso.IDPlan = (int)this.cmbPlanes.SelectedValue;
            this.Curso.IDEspecialidad = (int)this.cmbEspecialidades.SelectedValue;
        }

        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (
                !Util.Util.validarRequerido(this.txtAnio.Text) ||
                !Util.Util.validarRequerido(this.txtCupo.Text) ||
                !Util.Util.validarRequerido(this.cmbEspecialidades.SelectedValue) ||
                !Util.Util.validarRequerido(this.cmbPlanes.SelectedValue) ||
                !Util.Util.validarRequerido(this.cmbMaterias.SelectedValue) ||
                !Util.Util.validarRequerido(this.cmbComisiones.SelectedValue))
            {
                mensaje += "- Complete todos los campos" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarNumero(this.txtAnio.Text) || !Util.Util.validarLength(this.txtAnio.Text, 4))
            {
                mensaje += "- El año debe ser en formato yyyy (Ej: 2014)" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarNumero(this.txtCupo.Text))
            {
                mensaje += "- El ingrese un valor numérico para el cupo" + Environment.NewLine;
                error = true;
            }

            if (error)
            {
                this.Notificar("Error de validación", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !error;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic uLogic = new CursoLogic();
            uLogic.Save(this.Curso);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int IDEspecialidad = int.Parse(this.cmbEspecialidades.SelectedValue.ToString());
            if (IDEspecialidad != 0)
            {
                this.loadCmbPlanes(IDEspecialidad);
                this.cmbPlanes.Enabled = true;
            }
            else
            {
                this.cmbPlanes.Enabled = false;
            }
            this.cmbPlanes.SelectedItem = null;
            this.cmbMaterias.SelectedItem = null;
            this.cmbMaterias.Enabled = false;
            this.cmbComisiones.SelectedItem = null;
            this.cmbComisiones.Enabled = false;
        }

        private void cmbPlanes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int IDPlan = int.Parse(this.cmbPlanes.SelectedValue.ToString());
            if (IDPlan != 0)
            {
                this.loadCmbMaterias(IDPlan);
                this.loadCmbComisiones(IDPlan);
                this.cmbEnable(true);
            }
            else
            {
                this.cmbMaterias.SelectedItem = null;
                this.cmbComisiones.SelectedItem = null;
                this.cmbMaterias.Enabled = false;
                this.cmbComisiones.Enabled = false;
            }
        }

        private void cmbEnable(bool enable)
        {
            this.cmbPlanes.Enabled = enable;
            this.cmbMaterias.Enabled = enable;
            this.cmbComisiones.Enabled = enable;
        }
    }
}
