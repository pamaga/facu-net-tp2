using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Business.Logic
{
    public class BusinessLogic
    {

        public List<String> getMenuNotAllowedByRol(Usuario usr)
        {
            List<String> optionNotAllowed = new List<string>();
            switch (Convert.ToInt32(usr.TipoUsuario))
            {
                case 0:
                    optionNotAllowed.Add("misMateriasToolStripMenuItem");
                    break;
                case 1:
                    optionNotAllowed.Add("personasToolStripMenuItem");
                    optionNotAllowed.Add("catedrasToolStripMenuItem");
                    optionNotAllowed.Add("misMateriasToolStripMenuItem");
                    break;
                case 2:
                    optionNotAllowed.Add("personasToolStripMenuItem");
                    optionNotAllowed.Add("catedrasToolStripMenuItem");
                    break;


            }

            return optionNotAllowed;
        }
    }
}
