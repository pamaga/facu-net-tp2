using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
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

        private int _IDComision;
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        private string _DescComision;
        public string DescComision
        {
            get { return _DescComision; }
            set { _DescComision = value; }
        }

        private int _IDMateria;
        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        private int _IDPlan;
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        private string _DescPlan;
        public string DescPlan
        {
            get { return _DescPlan; }
            set { _DescPlan = value; }
        }

        private string _DescMateria;
        public string DescMateria
        {
            get { return _DescMateria; }
            set { _DescMateria = value; }
        }
    }
}
