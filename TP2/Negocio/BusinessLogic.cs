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
                    //ADMIN
                    optionNotAllowed.Add("misMateriasToolStripMenuItem");
                    optionNotAllowed.Add("listadoDeAlumnosToolStripMenuItem");
                    optionNotAllowed.Add("alumnosPorCursosToolStripMenuItem");
                    
                    break;
                case 1:
                    //DOCENTE
                    optionNotAllowed.Add("personasToolStripMenuItem");
                   // optionNotAllowed.Add("catedrasToolStripMenuItem");
                    optionNotAllowed.Add("misMateriasToolStripMenuItem");
                    optionNotAllowed.Add("alumnosPorCursosToolStripMenuItem");

                    optionNotAllowed.Add("planesToolStripMenuItem1");
                    optionNotAllowed.Add("especialidadesToolStripMenuItem");
                    optionNotAllowed.Add("comisionesToolStripMenuItem");
                    optionNotAllowed.Add("materiasToolStripMenuItem");
                    
                    break;
                    //ALUMNO
                case 2:
                    optionNotAllowed.Add("personasToolStripMenuItem");
                    optionNotAllowed.Add("catedrasToolStripMenuItem");
                    optionNotAllowed.Add("listadoDeAlumnosToolStripMenuItem");
                    break;


            }

            return optionNotAllowed;
        }
    }
}
