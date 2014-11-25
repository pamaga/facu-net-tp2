using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        Data.Database.UsuarioAdapter _usuarioData;

        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public Usuario getUserByLegajo(int legajo)
        {
            return UsuarioData.getUserByLegajo(legajo);
        }

        public Usuario getUsuarioPermitido(string usuario, string clave)
        {
            return UsuarioData.GetUserValid(usuario, clave);
        }

        public List<Usuario> GetAll(TiposUsuarios TipoUsuario)
        {
            return UsuarioData.GetAll(TipoUsuario);
        }

        public List<Usuario> GetDocentesByCurso(int IdCurso)
        {
            return UsuarioData.GetDocentesByCurso(IdCurso);
        }

        public int addDocenteToCurso(int docente, int curso) {
            return UsuarioData.addDocenteToCurso(docente,curso);
        }
        public void removeDocenteToCurso(int docente, int curso)
        {
            UsuarioData.removeDocenteToCurso(docente, curso);
        }

        public bool isAssignedDocenteToCurso(int docente, int curso)
        {
            List<Usuario> aUsers = UsuarioData.GetDocentesByCurso(curso);

            foreach (Usuario u in aUsers) {
                if (u.ID == docente) return true;
            }
            return false;

        }

        public void Save(Usuario user)
        {
            UsuarioData.Save(user);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }
       
    }
}
