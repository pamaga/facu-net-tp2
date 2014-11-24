using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        Data.Database.PlanAdapter _planData;

        public Data.Database.PlanAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }

        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        public Plan GetOne(int id){
            return PlanData.GetOne(id);
        }

        public List<Plan> GetAll(int IDEspecialidad)
        {
            return PlanData.GetAll(IDEspecialidad);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Save(Plan esp)
        {
            PlanData.Save(esp);
        }

        public void Delete(int id){
            PlanData.Delete(id);
        }
    }
}
