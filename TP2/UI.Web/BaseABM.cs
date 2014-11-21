using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public class BaseABM : System.Web.UI.Page
    {
        public List<Especialidad> lstEsp;
        public List<Plan> lstPlan;

        public enum FormModes { Alta, Baja, Modificacion }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
                else return 0;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        protected bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
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
    }
}