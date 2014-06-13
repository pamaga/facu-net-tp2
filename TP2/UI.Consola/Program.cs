using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Logic;


namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuarios Usuarios = new Usuarios();
            int userInput = 0;
            do
            {

                userInput = Usuarios.Menu();

                switch (userInput)
                {
                    case 1:
                        Usuarios.ListadoGeneral();
                        break;
                    case 2:
                        Usuarios.Consultar();
                        break;
                }

            } while (userInput != 6);
        }

       
    }
}
