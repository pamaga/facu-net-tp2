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

        public UsuarioLogic(){
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public Usuario GetOne(int id){
            return UsuarioData.GetOne(id);
        }

        public List<Usuario> GetAll(){
            return UsuarioData.GetAll();
        }

        public void Save(Usuario user){
            UsuarioData.Save(user);
        }

        public void Delete(int id){
            UsuarioData.Delete(id);
        }
    }
}
