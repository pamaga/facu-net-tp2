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
        private Curso _CursoActual;
        public Curso CursoActual
        {
          get { return _CursoActual; }
          set { _CursoActual = value; }
        }

        public CursoDesktop()
        {
            InitializeComponent();
            //loadCmbPlan();
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(cmbPlan_SelectedIndexChanged);
            this.cmbPlan.SelectedIndex = this.cmbPlan.Items.Count - 1;
        }

        public CursoDesktop(ModoForm modo):this(){
            this.Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo):this()
        {
           
            this.Modo = modo;
            CursoLogic logic = new CursoLogic();
            this.CursoActual = logic.GetOne(ID);
            MapearDeDatos();
           
        }

        private void loadCmbPlan(int IDEspecialidad)
        {
            this.cmbPlan.DataSource = this.getPlanes(IDEspecialidad);
            this.cmbPlan.DisplayMember = "DescCompleta";
            this.cmbPlan.ValueMember = "ID";
        }

        private void loadCmbMateria(int IDPlan)
        {
            MateriaLogic MatLogic = new MateriaLogic();

            this.cmbMateria.DataSource = MatLogic.GetSome(IDPlan);
            this.cmbMateria.DisplayMember = "Descripcion";
            this.cmbMateria.ValueMember = "ID";
        }

        private void loadCmbComision(int IDPlan)
        {
            ComisionLogic ComLogic = new ComisionLogic();

            this.cmbComision.DataSource = ComLogic.GetSome(IDPlan);
            this.cmbComision.DisplayMember = "Descripcion";
            this.cmbComision.ValueMember = "ID";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadCmbMateria((int)this.cmbPlan.SelectedValue);
            this.loadCmbComision((int)this.cmbPlan.SelectedValue);
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();

            this.txtCupo.Text = CursoActual.Cupo.ToString();
            this.txtAnio.Text = CursoActual.AnioCalendario.ToString();
            this.cmbPlan.SelectedValue = CursoActual.IDPlan;
            this.cmbMateria.SelectedValue = CursoActual.IDMateria;
            this.cmbComision.SelectedValue = CursoActual.IDComision;
            this.txtAnio.Text = CursoActual.AnioCalendario.ToString();

            string txtAceptar = "Aceptar";

            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion)) txtAceptar = "Guardar";
            this.btnAceptar.Text = txtAceptar;
        }

        public override void MapearADatos()
        {
            if (Modo.Equals(ModoForm.Alta))
            {
                this.CursoActual = new Curso();
                this.CursoActual.State = BusinessEntity.States.New;
            }
            else if (Modo.Equals(ModoForm.Modificacion))
            {
                this.CursoActual.ID = Int32.Parse(txtID.Text);
                this.CursoActual.State = BusinessEntity.States.Modified;
            }

            this.CursoActual.IDComision = (int)this.cmbComision.SelectedValue;
            this.CursoActual.IDMateria = (int)this.cmbMateria.SelectedValue;
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnio.Text);
            this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
        }

        public override bool Validar()
        {
            bool error = false;
            string mensaje = "Errores en el formulario:" + Environment.NewLine;

            if (
                this.cmbMateria.SelectedValue == null ||
                this.cmbComision.SelectedValue == null ||
                !Util.Util.validarRequerido(this.txtAnio.Text) ||
                !Util.Util.validarRequerido(this.txtCupo.Text))
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
            uLogic.Save(this.CursoActual);
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
