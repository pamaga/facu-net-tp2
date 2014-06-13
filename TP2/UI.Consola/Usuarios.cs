using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        public UsuarioLogic UsuarioNegocio { set; get; }

        public Usuarios() { 
            UsuarioNegocio = new UsuarioLogic();
        }
        public static int Menu()
        {
            System.Console.WriteLine("1 - Listado general");
            System.Console.WriteLine("2 - Consulta");
            System.Console.WriteLine("3 - Agregar");
            System.Console.WriteLine("4 - Modificar");
            System.Console.WriteLine("5 - Eliminar");
            System.Console.WriteLine("6 - Salir");
            int _Key;
            try
            {
                 _Key = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                
                _Key = 0;
            }
            return _Key;
        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void Consultar() {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del usuario a consultar:");
            int ID = int.Parse(Console.ReadLine());
            this.MostrarDatos(UsuarioNegocio.GetOne(ID));

        }
        public void Agregar() { }
        public void Modificar() { }
        public void Eliminar() { }
        public void MostrarDatos(Usuario usr) {
            string tab = "\t\t";
            Console.WriteLine("Usuario: {0}",usr.ID);
            Console.WriteLine(tab+"Nombre: {0}", usr.Nombre);
            Console.WriteLine(tab+"Nombre de usuario: {0}", usr.NombreUsuario);
            Console.WriteLine(tab+"Clave: {0}", usr.Clave);
            Console.WriteLine(tab+"Email: {0}", usr.Email);
            Console.WriteLine(tab+"Habilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        
        }
    }
}
