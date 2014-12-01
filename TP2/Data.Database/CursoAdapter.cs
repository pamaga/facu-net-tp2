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

                //SqlCommand cmdCursos = new SqlCommand("SELECT C.id_curso, C.id_materia, C.id_comision, C.anio_calendario, C.cupo, M.desc_materia, CO.desc_comision, P.id_plan, P.desc_plan, P.id_especialidad FROM cursos AS C INNER JOIN materias AS M ON C.id_materia = M.id_materia INNER JOIN comisiones AS CO ON C.id_comision = CO.id_comision INNER JOIN planes AS P ON M.id_plan = P.id_plan", sqlConn);
                SqlCommand cmdCursos = new SqlCommand("SELECT C.*, M.*, CO.*, P.*, E.* FROM cursos C JOIN materias M ON C.id_materia = M.id_materia JOIN comisiones CO ON C.id_comision = CO.id_comision JOIN planes P ON CO.id_plan = P.id_plan JOIN especialidades E ON P.id_especialidad = E.id_especialidad", sqlConn);
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
                    Curso.IDEspecialidad = (int)drCursos["id_especialidad"];
                    Curso.Especialidad = (string)drCursos["desc_especialidad"];

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

        public List<Curso> GetAllDocente(int IdDocente)
        {
            List<Curso> Cursos = new List<Curso>();

            try
            {
                PlanAdapter Plan = new PlanAdapter();

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("SELECT C.*, M.*, CO.*, P.*, E.* FROM cursos C JOIN materias M ON C.id_materia = M.id_materia JOIN comisiones CO ON C.id_comision = CO.id_comision JOIN planes P ON CO.id_plan = P.id_plan JOIN especialidades E ON P.id_especialidad = E.id_especialidad JOIN docentes_cursos DC ON C.id_curso = DC.id_curso WHERE DC.id_docente = @id_docente", sqlConn);
                cmdCursos.Parameters.Add("@id_docente", SqlDbType.Int).Value = IdDocente;
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
                    Curso.IDEspecialidad = (int)drCursos["id_especialidad"];
                    Curso.Especialidad = (string)drCursos["desc_especialidad"];

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


        /*Recupera todas las materias de este año, para el plan*/
        public List<Curso> GetAllCursosAnio(int IdPlan)
        {
            List<Curso> Cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand(
                    "SELECT C.*, M.desc_materia, CO.desc_comision, P.id_plan, P.desc_plan " +
                    "FROM cursos AS C " +
                    "INNER JOIN materias AS M ON C.id_materia = M.id_materia " +
                    "INNER JOIN comisiones AS CO ON C.id_comision = CO.id_comision " +
                    "INNER JOIN planes AS P ON M.id_plan = P.id_plan " +
                    "WHERE C.anio_calendario = @anio_actual AND P.id_plan = @id_plan", sqlConn);
                cmdCursos.Parameters.Add("@id_plan", SqlDbType.Int).Value = IdPlan;
                cmdCursos.Parameters.Add("@anio_actual", SqlDbType.Int).Value = DateTime.Now.Year;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso Curso = new Curso();

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

        public List<Curso> GetCursosAlumno(int IdAlumno)
        {
            List<Curso> Cursos = new List<Curso>();

            try
            {
                //PlanAdapter Plan = new PlanAdapter();

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand(
                    "SELECT C.id_curso, C.id_materia, C.id_comision, C.anio_calendario, C.cupo, M.desc_materia, CO.desc_comision, P.id_plan, P.desc_plan, P.id_especialidad, AI.condicion, AI.nota, AI.id_inscripcion " +
                    "FROM cursos AS C " +
                    "INNER JOIN materias AS M ON C.id_materia = M.id_materia " +
                    "INNER JOIN comisiones AS CO ON C.id_comision = CO.id_comision " +
                    "INNER JOIN planes AS P ON M.id_plan = P.id_plan " +
                    "INNER JOIN alumnos_inscripciones AS AI ON C.id_curso = AI.id_curso " +
                    "WHERE AI.id_alumno = @id_alumno", sqlConn);
                cmdCursos.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IdAlumno;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso Curso = new Curso();

                    Curso.ID = (int)drCursos["id_curso"];
                    Curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    Curso.Cupo = (int)drCursos["cupo"];
                    Curso.IDComision = (int)drCursos["id_comision"];
                    Curso.Comision = (string)drCursos["desc_comision"];
                    Curso.IDMateria = (int)drCursos["id_materia"];
                    Curso.Materia = (string)drCursos["desc_materia"];
                    Curso.IDPlan = (int)drCursos["id_plan"];
                    Curso.Plan = (string)drCursos["desc_plan"];
                    Curso.IdInscripcion = (int)drCursos["id_inscripcion"];
                    Curso.Nota = (int)drCursos["nota"];
                    Curso.Condicion = (Condiciones)Enum.Parse(typeof(Condiciones), (string)drCursos["condicion"]);

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
                SqlCommand cmdCursos = new SqlCommand("SELECT C.*, M.*, CO.*, P.*, E.* FROM cursos C JOIN materias M ON C.id_materia = M.id_materia JOIN comisiones CO ON C.id_comision = CO.id_comision JOIN planes P ON CO.id_plan = P.id_plan JOIN especialidades E ON P.id_especialidad = E.id_especialidad WHERE C.id_curso = @id", sqlConn);
                /*SqlCommand cmdCursos = new SqlCommand(
                    "SELECT C.*, M.desc_materia, CO.desc_comision, CO.id_plan "+
                    "FROM cursos C "+
                    "JOIN materias M ON C.id_materia = M.id_materia "+
                    "JOIN comisiones CO ON C.id_comision = CO.id_comision "+
                    "WHERE C.id_curso = @id", sqlConn);*/
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    Curso.ID = (int)drCursos["id_curso"];
                    Curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    Curso.Cupo = (int)drCursos["cupo"];
                    Curso.IDComision = (int)drCursos["id_comision"];
                    Curso.IDMateria = (int)drCursos["id_materia"];
                    Curso.IDPlan = (int)drCursos["id_plan"];
                    Curso.Comision = (string)drCursos["desc_comision"];
                    Curso.IDEspecialidad = (int)drCursos["id_especialidad"];
                    Curso.Especialidad = (string)drCursos["desc_especialidad"];
                    Curso.Materia = (string)drCursos["desc_materia"];
                    Curso.Plan = (string)drCursos["desc_plan"];
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
