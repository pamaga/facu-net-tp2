using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class InscripcionLogic
    {
        private InscripcionAdapter _InscripcionData;
        public InscripcionAdapter InscripcionData
        {
            get { return _InscripcionData; }
            set { _InscripcionData = value; }
        }

        public InscripcionLogic()
        {
            InscripcionData = new InscripcionAdapter();
        }

        public Inscripcion GetOne(int id)
        {
            return InscripcionData.GetOne(id);
        }

        public void Save(Inscripcion Insc)
        {
            InscripcionData.Save(Insc);
        }

        public void Delete(int id)
        {
            InscripcionData.Delete(id);
        }

        public bool checkInscripcion(int IdAlumno, int IdCurso){
            return InscripcionData.checkInscripcion(IdAlumno,IdCurso);
        }
    }
}
