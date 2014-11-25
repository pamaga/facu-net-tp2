using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia _Materia;

        public Materia Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }
        public MateriaDesktop()
        {
            InitializeComponent();
            this.loadCmbEspecialidades();
        }

        public MateriaDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
        }

        private void loadCmbEspecialidades()
        {
            this.cmbEspecialidades.DisplayMember = "Descripcion";
            this.cmbEspecialidades.ValueMember = "ID";
            this.cmbEspecialidades.DataSource = this.getEspecialidades();
            this.cmbEspecialidades.SelectedItem = null;
        }

        private void loadCmbPlanes(int IDEspecialidad)
        {
            this.cmbPlanes.DisplayMember = "Descripcion";
            this.cmbPlanes.ValueMember = "ID";
            this.cmbPlanes.DataSource = this.getPlanes(IDEspecialidad);
        }

        public MateriaDesktop(int ID, ModoForm modo):this()
        {
           
            this.Modo = modo;
            MateriaLogic logic = new MateriaLogic();
            this.Materia = logic.GetOne(ID);
            MapearDeDatos();
           
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.Materia.ID.ToString();

            this.txtMateria.Text = Materia.Descripcion;
            this.cmbEspecialidades.SelectedValue = Materia.IDEspecialidad;
            this.loadCmbPlanes(Materia.IDEspecialidad);
            this.cmbPlanes.SelectedValue = Materia.IDPlan;
            this.txtHsSemanales.Text = Materia.HSSemanales.ToString();
            this.txtHsTotales.Text = Materia.HSTotales.ToString();
          }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (!Util.Util.validarRequerido(this.txtMateria.Text) ||
                !Util.Util.validarRequerido(this.txtHsSemanales.Text) ||
                !Util.Util.validarRequerido(this.txtHsTotales.Text) ||
                !Util.Util.validarRequerido(this.cmbEspecialidades.SelectedValue) ||
                !Util.Util.validarRequerido(this.cmbPlanes.SelectedValue))
            {
                mensaje += "- Complete todos los campos" + Environment.NewLine;
                error = true;
            }

            if(!Util.Util.validarNumero(this.txtHsSemanales.Text) ||
               !Util.Util.validarNumero(this.txtHsTotales.Text))
            {
                mensaje += "- Ingrese un valor numérico para las horas" + Environment.NewLine;
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
            MateriaLogic uLogic = new MateriaLogic();
            uLogic.Save(this.Materia);
        }
        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.Materia = new Materia();
                this.Materia.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.Materia.ID = Int32.Parse(txtID.Text);
                this.Materia.State = BusinessEntity.States.Modified;
            }

            this.Materia.Descripcion = this.txtMateria.Text;
            this.Materia.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
            this.Materia.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
            this.Materia.IDEspecialidad = (int)this.cmbEspecialidades.SelectedValue;
            this.Materia.IDPlan = (int)this.cmbPlanes.SelectedValue;

        }

        private void cmbEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int IDEspecialidad = int.Parse(this.cmbEspecialidades.SelectedValue.ToString());
            if (IDEspecialidad != 0)
            {
                this.loadCmbPlanes(IDEspecialidad);
            }
        }
    }
}
