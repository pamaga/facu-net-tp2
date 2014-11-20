using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        Data.Database.ComisionAdapter _comisionData;

        public Data.Database.ComisionAdapter ComisionData
        {
            get { return _comisionData; }
            set { _comisionData = value; }
        }

        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }

        public Comision GetOne(int id){
            return ComisionData.GetOne(id);
        }

        public List<Comision> GetSome(int IDPlan)
        {
            return ComisionData.GetSome(IDPlan);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public void Save(Comision esp)
        {
            ComisionData.Save(esp);
        }

        public void Delete(int id){
            ComisionData.Delete(id);
        }
    }
}
