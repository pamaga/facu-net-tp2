using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        Data.Database.CursoAdapter _CursoData;

        public Data.Database.CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public void Save(Curso esp)
        {
            CursoData.Save(esp);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }
    }
}
