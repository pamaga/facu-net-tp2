using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private int _IDEspecialidad;
        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }

        private string _Especialidad;
        public string Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }

        private int _IDPlan;
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        private string _Plan;
        public string Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _HSSemanales;
        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }

        private int _HSTotales;
        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }
    }
}
