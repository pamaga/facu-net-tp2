using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
    {

        public List<Comision> GetAll()
        {
            List<Comision> Comisiones = new List<Comision>();

            try{
            
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT C.*,P.desc_plan, E.* FROM comisiones C LEFT JOIN planes P ON P.id_plan = C.id_plan LEFT JOIN especialidades E ON E.id_especialidad = P.id_especialidad", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision Comision = new Comision();

                    Comision.ID = (int)drComisiones["id_comision"];
                    Comision.Descripcion = (string)drComisiones["desc_comision"];
                    Comision.IDPlan = (int)drComisiones["id_plan"];
                    Comision.Plan = (string)drComisiones["desc_plan"];
                    Comision.IDEspecialidad = (int)drComisiones["id_especialidad"];
                    Comision.Especialidad = (string)drComisiones["desc_especialidad"];
                    Comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    
                    Comisiones.Add(Comision);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }finally{
                this.CloseConnection();
            }
            return Comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision oEntity = new Comision();

            try
            {

                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT C.*, P.desc_plan, E.* FROM comisiones C LEFT JOIN planes P ON P.id_plan = C.id_plan LEFT JOIN especialidades E ON E.id_especialidad = P.id_especialidad WHERE C.id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    oEntity.ID = (int)drComisiones["id_comision"];
                    oEntity.Descripcion = (string)drComisiones["desc_comision"];
                    oEntity.IDPlan = (int)drComisiones["id_plan"];
                    oEntity.Plan = (string)drComisiones["desc_plan"];
                    oEntity.IDEspecialidad = (int)drComisiones["id_especialidad"];
                    oEntity.Especialidad = (string)drComisiones["desc_especialidad"];
                    oEntity.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la comision", Ex);
                throw ExcepcionManejada;
            }finally{
                this.CloseConnection();
            }
            return oEntity;
        }

        public List<Comision> GetSome(int IDPlan)
        {
            List<Comision> Comisiones = new List<Comision>();

            try
            {

                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT C.*,P.desc_plan, E.desc_especialidad FROM comisiones C LEFT JOIN planes P ON P.id_plan = C.id_plan LEFT JOIN especialidades E ON E.id_especialidad = P.id_especialidad WHERE C.id_plan = @id_plan", sqlConn);
                cmdComisiones.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision Comision = new Comision();

                    Comision.ID = (int)drComisiones["id_comision"];
                    Comision.Descripcion = (string)drComisiones["desc_comision"];
                    Comision.IDPlan = (int)drComisiones["id_plan"];
                    Comision.Plan = (string)drComisiones["desc_plan"] + " - " + (string)drComisiones["desc_especialidad"];
                    Comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];

                    Comisiones.Add(Comision);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Comisiones;
        }

        public void Delete(int ID)
        {
            try{
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            } catch(Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comision:" + Ex.ToString(), Ex);
            } finally {
                this.CloseConnection();
            }
        }

        public void Save(Comision Comision)
        {

            if (Comision.State == BusinessEntity.States.New)
            {
                this.Insert(Comision);
            }
            else if (Comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Comision.ID);
            }
            else if (Comision.State == BusinessEntity.States.Modified)
            {
                this.Update(Comision);
            }
            Comision.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Comision Comision)
        {
            try{
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc, id_plan = @id_plan, anio_especialidad = @anio WHERE id_comision = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Comision.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = Comision.Descripcion;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = Comision.IDPlan;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = Comision.AnioEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision Comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones (desc_Comision,id_plan,anio_especialidad) " +
                    "VALUES (@desc,@id_plan,@anio) " +
                    "SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = Comision.Descripcion;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = Comision.IDPlan;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = Comision.AnioEspecialidad;
                Comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
              
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision" + Ex, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    
    }
}
