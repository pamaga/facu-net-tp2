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
using System.Diagnostics;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan _plan;

        public Plan Plan
        {
            get { return _plan; }
            set { _plan = value; }
        }

        public PlanDesktop()
        {
            InitializeComponent();
            this.loadCmb();
         
           
        }
        public PlanDesktop(ModoForm modo):this()
        {
             this.Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo):this()
        {
           
            this.Modo = modo;
            PlanLogic logic = new PlanLogic();
            this.Plan = logic.GetOne(ID);
            MapearDeDatos();
           
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.Plan.ID.ToString();

            this.txtDescripcion.Text = Plan.Descripcion;
            this.cmbEspecialidades.SelectedValue = Plan.IdEspecialidad;
            string txtAceptar = "Aceptar";

            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion)) txtAceptar = "Guardar";
            this.btnAceptar.Text = txtAceptar;
        }
        private void loadCmb() {
            this.cmbEspecialidades.DataSource = this.getEspecialidades();
            this.cmbEspecialidades.DisplayMember = "Descripcion";
            this.cmbEspecialidades.ValueMember = "ID";
        }
        private void PlanDesktop_Load(object sender, EventArgs e)
        {
           
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic uLogic = new PlanLogic();
            uLogic.Save(this.Plan);
        }

        public override bool Validar() {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (!Util.Util.validarRequerido(this.txtDescripcion.Text))
            {
                mensaje += "- Complete la descripción" + Environment.NewLine;
                error = true;
            }

            if (error)
            {
                this.Notificar("Error de validación", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !error;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.Plan = new Plan();
                this.Plan.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.Plan.ID = Int32.Parse(txtID.Text);
                this.Plan.State = BusinessEntity.States.Modified;
            }


            this.Plan.Descripcion = this.txtDescripcion.Text;
            this.Plan.IdEspecialidad = (int)this.cmbEspecialidades.SelectedValue; 
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
