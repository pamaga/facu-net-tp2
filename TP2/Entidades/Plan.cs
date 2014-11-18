using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string _Descripcion;
        private string _Especialidad;

        public string Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IdEspecialidad;
        public int IdEspecialidad
        {
            get { return _IdEspecialidad; }
            set { _IdEspecialidad = value; }
        }

        private string _DescCompleta;

        public string DescCompleta
        {
            get { return this.Descripcion + " - " + this.Especialidad; }
        }
    }
}
