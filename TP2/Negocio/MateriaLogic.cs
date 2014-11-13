using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        Data.Database.MateriaAdapter _materiaData;

        public Data.Database.MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }

        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        public Materia GetOne(int id){
            return MateriaData.GetOne(id);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Save(Materia esp)
        {
            MateriaData.Save(esp);
        }

        public void Delete(int id){
            MateriaData.Delete(id);
        }
    }
}
