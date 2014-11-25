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
    public partial class ComisionDesktop : ApplicationForm
    {
        private Comision _Comision;

        public Comision Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        public ComisionDesktop()
        {
            InitializeComponent();
            this.loadCmbEspecialidades();
        }

        public ComisionDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            ComisionLogic logic = new ComisionLogic();
            this.Comision = logic.GetOne(ID);
            MapearDeDatos();
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

        
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.Comision.ID.ToString();

            this.txtDescripcion.Text = Comision.Descripcion;
            this.cmbEspecialidades.SelectedValue = Comision.IDEspecialidad;
            this.loadCmbPlanes(Comision.IDEspecialidad);
            this.cmbPlanes.SelectedValue = Comision.IDPlan;
            this.txtAnio.Text = Comision.AnioEspecialidad.ToString();
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.Comision = new Comision();
                this.Comision.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.Comision.ID = Int32.Parse(txtID.Text);
                this.Comision.State = BusinessEntity.States.Modified;
            }

            this.Comision.Descripcion = this.txtDescripcion.Text;
            this.Comision.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
            this.Comision.IDPlan = (int)this.cmbPlanes.SelectedValue;
            this.Comision.IDEspecialidad = (int)this.cmbEspecialidades.SelectedValue;
        }

        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (!Util.Util.validarRequerido(this.txtDescripcion.Text) ||
                !Util.Util.validarRequerido(this.txtAnio.Text) ||
                !Util.Util.validarRequerido(this.cmbEspecialidades.SelectedValue) ||
                !Util.Util.validarRequerido(this.cmbPlanes.SelectedValue))
            {
                mensaje += "- Complete todos los campos" + Environment.NewLine;
                error = true;
            }

            if (!Util.Util.validarNumero(this.txtAnio.Text) || !Util.Util.validarLength(this.txtAnio.Text, 1))
            {
                mensaje += "- El año debe ser en formato a (Ej: 1)" + Environment.NewLine;
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
            ComisionLogic uLogic = new ComisionLogic();
            uLogic.Save(this.Comision);
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
            }
        }
    }
}
