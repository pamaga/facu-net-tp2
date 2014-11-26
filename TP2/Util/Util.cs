using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Business.Entities;

namespace Util
{
    public static class Util
    {

        private static Usuario _usuarioLogueado;
        public static Usuario UsuarioLogueado
        {
            get { return Util._usuarioLogueado; }
            set { Util._usuarioLogueado = value; }
        }

        public static string DateToDb(string date)
        {
            string[] arr = date.Split('/');
            Array.Reverse(arr);
            return string.Join("-", arr);
        }

        public static string DbToDdate(string date)
        {
            string[] arr = date.Split('-');
            Array.Reverse(arr);
            return string.Join("/", arr);
        }

        public static bool validarRequerido(string item){
            return !string.IsNullOrEmpty(item);
        }

        public static bool validarRequerido(object item)
        {
            if (item == null || item.ToString() == "-1") return false;
            else return true;
        }

        public static bool validarEmail(string email){
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public static bool validarNumero(string numero){
            return Regex.IsMatch(numero, @"^\d+$", RegexOptions.IgnoreCase);
        }

        /// <summary>Valida la fecha en formato dd/mm/yyyy</summary> 
        public static bool validarFecha(string fecha){
            return Regex.IsMatch(fecha, @"^(((((0[1-9])|(1\d)|(2[0-9]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$", RegexOptions.IgnoreCase);
        }

        public static bool validarMinLength(string item, int length){
            return item.Length >= length;
        }

        public static bool validarLength(string item, int length)
        {
            return item.Length == length;
        }

        public static bool validarIguales(string item1, string item2)
        {
            return item1.Equals(item2);
        }
    }
}
