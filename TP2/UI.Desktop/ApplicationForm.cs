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
    public partial class ApplicationForm : Form
    {
        public List<Especialidad> lstEsp;
        public List<Plan> lstPlan;

        public enum ModoForm 
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        private ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }


        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {

        }
        public List<Especialidad> getEspecialidades(){
            if (null == lstEsp)
            {
                EspecialidadLogic esp = new EspecialidadLogic();
                this.lstEsp = esp.GetAll();
            }
            return this.lstEsp;
        }
        public List<Plan> getPlanes()
        {
            if (null == lstEsp)
            {
                PlanLogic esp = new PlanLogic();
                this.lstPlan = esp.GetAll();
            }
            return this.lstPlan;
        }

        public string getEspecialidadById(int id)
        {
            this.getEspecialidades();
            string nombre = this.lstEsp.Find(o => o.ID == id).Descripcion;
            return nombre;
        }

        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(this.Text, mensaje, botones, icono);
        }
    }
}
