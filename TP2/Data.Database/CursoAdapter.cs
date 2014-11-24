using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {

        public List<Curso> GetAll()
        {
            List<Curso> Cursos = new List<Curso>();

            try
            {
                PlanAdapter Plan = new PlanAdapter();

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("SELECT C.id_curso, C.id_materia, C.id_comision, C.anio_calendario, C.cupo, M.desc_materia, CO.desc_comision, P.id_plan, P.desc_plan, P.id_especialidad FROM cursos AS C INNER JOIN materias AS M ON C.id_materia = M.id_materia INNER JOIN comisiones AS CO ON C.id_comision = CO.id_comision INNER JOIN planes AS P ON M.id_plan = P.id_plan", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso Curso = new Curso();

                    Plan PlanActual = Plan.GetOne((int)drCursos["id_plan"]);

                    Curso.ID = (int)drCursos["id_curso"];
                    Curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    Curso.Cupo = (int)drCursos["cupo"];
                    Curso.IDComision = (int)drCursos["id_comision"];
                    Curso.Comision = (string)drCursos["desc_comision"];
                    Curso.IDMateria = (int)drCursos["id_materia"];
                    Curso.Materia = (string)drCursos["desc_materia"];
                    Curso.IDPlan = (int)drCursos["id_plan"];
                    Curso.Plan = (string)drCursos["desc_plan"];

                    Cursos.Add(Curso);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso Curso = new Curso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("SELECT C.*, M.desc_materia, CO.desc_comision, CO.id_plan FROM cursos C JOIN materias M ON C.id_materia = M.id_materia JOIN comisiones CO ON C.id_comision = CO.id_comision WHERE C.id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    Curso.ID = (int)drCursos["id_curso"];
                    Curso.IDMateria = (int)drCursos["id_materia"];
                    Curso.IDComision = (int)drCursos["id_comision"];
                    Curso.IDPlan = (int)drCursos["id_plan"];
                    Curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    Curso.Cupo = (int)drCursos["cupo"];
                    Curso.Comision = (string)drCursos["desc_comision"];
                    Curso.Materia = (string)drCursos["desc_materia"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Curso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Curso:" + Ex.ToString(), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso Curso)
        {

            if (Curso.State == BusinessEntity.States.New)
            {
                this.Insert(Curso);
            }
            else if (Curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Curso.ID);
            }
            else if (Curso.State == BusinessEntity.States.Modified)
            {
                this.Update(Curso);
            }
            Curso.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Curso Curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo WHERE id_curso = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = Curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = Curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = Curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = Curso.Cupo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso Curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos (id_materia, id_comision, anio_calendario, cupo) " +
                    "VALUES (@id_materia, @id_comision, @anio_calendario, @cupo) " +
                    "SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = Curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = Curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = Curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = Curso.Cupo;
                Curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el Curso" + Ex, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

    }
}
