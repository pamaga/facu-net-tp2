using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
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

        private int _IDComision;
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        private string _Comision;
        public string Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        private int _IDMateria;
        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        private string _Materia;
        public string Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        private int _AnioCalendario;
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
    }
}
