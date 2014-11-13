using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Business.Logic;
using Business.Entities;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {

        private Especialidad _especialidadActual;

        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }
        }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo):this(){
            this.Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo):this(){
            this.Modo = modo;
            EspecialidadLogic especialidad = new EspecialidadLogic();
            this.EspecialidadActual = especialidad.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;

            string txtAceptar = "Aceptar";

            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion)) txtAceptar = "Guardar";
            this.btnAceptar.Text = txtAceptar;
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.EspecialidadActual = new Especialidad();
                this.EspecialidadActual.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.EspecialidadActual.ID = Int32.Parse(txtID.Text);
                this.EspecialidadActual.State = BusinessEntity.States.Modified;
            }

            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
        }

        public override bool Validar()
        {
            if (this.txtDescripcion.Text == String.Empty)
            {
                this.Notificar("Error de validación", "Ingrese una descripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic eLogic = new EspecialidadLogic();
            eLogic.Save(this.EspecialidadActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }
    }
}
