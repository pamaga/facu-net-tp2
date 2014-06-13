using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData { get; set; }
        public UsuarioLogic() {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public List<Usuario> GetAll() {
            return UsuarioData.GetAll();
        }
        public Usuario GetOne(int ID) { return UsuarioData.GetOne(ID); }
        public void Save(Usuario _Usuario) { UsuarioData.Save(_Usuario); }
        public void Delete(int ID) { UsuarioData.Delete(ID); }

    }

}
