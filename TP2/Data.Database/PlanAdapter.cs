using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter:Adapter
    {

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try{
            
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT P.*, E.desc_especialidad FROM planes P left join especialidades E on P.id_especialidad = E.id_especialidad", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Especialidad = (string)drPlanes["desc_especialidad"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];

                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Planes", Ex);
                throw ExcepcionManejada;
            }finally{
                this.CloseConnection();
            }
            return planes;
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            Plan oEntity = new Plan();

            try
            {

                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT P.*, E.desc_especialidad FROM planes P left join especialidades E on P.id_especialidad = E.id_especialidad WHERE P.id_plan=@id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    oEntity.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    oEntity.Especialidad = (string)drPlanes["desc_especialidad"];
                    oEntity.ID = (int)drPlanes["id_plan"];
                    oEntity.Descripcion = (string)drPlanes["desc_plan"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el plan", Ex);
                throw ExcepcionManejada;
            }finally{
                this.CloseConnection();
            }
            return oEntity;
        }

        public void Delete(int ID)
        {
            try{
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            } catch(Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan:" + Ex.ToString(), Ex);
            } finally {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {

            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Plan plan)
        {
            try{
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc,id_especialidad = @id_esp WHERE id_plan = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes (desc_plan,id_especialidad) " +
                    "VALUES (@desc,@id_esp) " +
                    "SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IdEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
              
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el plan" + Ex, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    
    }
}
