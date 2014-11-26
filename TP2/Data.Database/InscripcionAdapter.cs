using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class InscripcionAdapter : Adapter
    {
        public void Save(Inscripcion Insc)
        {

            if (Insc.State == BusinessEntity.States.New)
            {
                this.Insert(Insc);
            }
            else if (Insc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Insc.ID);
            }
            else if (Insc.State == BusinessEntity.States.Modified)
            {
                this.Update(Insc);
            }
            Insc.State = BusinessEntity.States.Unmodified;
        }

        public Inscripcion GetOne(int ID)
        {
            Inscripcion Insc = new Inscripcion();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInsc = new SqlCommand(
                    "SELECT I.* " +
                    "FROM alumnos_inscripciones I " + 
                    "WHERE I.id_inscripcion = @id", sqlConn);
                cmdInsc.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInsc = cmdInsc.ExecuteReader();
                if (drInsc.Read())
                {
                    Insc.ID = (int)drInsc["id_inscripcion"];
                    Insc.IdAlumno = (int)drInsc["id_alumno"];
                    Insc.IdCurso = (int)drInsc["id_curso"];
                    Insc.Condicion = (Condiciones)Enum.Parse(typeof(Condiciones),(string)drInsc["condicion"]);
                    Insc.Nota = (int)drInsc["nota"];
                }
                drInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Insc;
        }

        protected void Insert(Inscripcion Inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion, nota) " +
                    "VALUES (@id_alumno, @id_curso, @condicion, @nota) " +
                    "SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = (int)Inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = (int)Inscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = Inscripcion.Condicion.ToString();
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = (int)Inscripcion.Nota;
                Inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

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

        protected void Update(Inscripcion Insc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones " +
                    "SET condicion = @condicion, nota = @nota " +
                    "WHERE id_inscripcion = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Insc.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = Insc.Condicion.ToString();
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = (int)Insc.Nota;
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

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion:" + Ex.ToString(), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public bool checkInscripcion(int IdAlumno, int IdCurso)
        {
            bool ret;
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT COUNT(*) FROM alumnos_inscripciones AI WHERE AI.id_alumno = @id_alumno AND AI.id_curso = @id_curso", sqlConn);
                cmdCursos.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IdAlumno;
                cmdCursos.Parameters.Add("@id_curso", SqlDbType.Int).Value = IdCurso;
                Int32 nInsc = (Int32)cmdCursos.ExecuteScalar();
                if (nInsc > 0)
                {
                    ret = false;
                }else{
                    ret = true;
                }
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
            return ret;
        }

    }
}
