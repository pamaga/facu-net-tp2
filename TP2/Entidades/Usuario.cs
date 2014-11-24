using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public enum TiposUsuarios
    {
        Administrador,
        Docente,
        Alumno
    }

    public class Usuario : BusinessEntity
    {
        private string _NombreUsuario;
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        private TiposUsuarios _tipoUsuario;
        public TiposUsuarios TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string _EMail;
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        private string _fechaNac;
        public string FechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        private int _Legajo;
        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        private string _Telefono;
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        private int _idPlan;

        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }
        private string _NombreCompleto;
        public string NombreCompleto {
            get { return this.Nombre + " " + this.Apellido; }
            
        }

    }
}
