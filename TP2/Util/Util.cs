using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public static class Util
    {
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

        public static bool validarEmail(string email){
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public static bool validarNumero(string numero){
            return Regex.IsMatch(numero, @"^\d+$", RegexOptions.IgnoreCase);
        }

        /// <summary>Valida la fecha en formato dd/mm/yyyy</summary> 
        public static bool validarFecha(string fecha){
            return Regex.IsMatch(fecha, @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", RegexOptions.IgnoreCase);
        }

        public static bool validarMinLength(string item, int length){
            return item.Length >= length;
        }
        
        public static bool validarIguales(string item1, string item2)
        {
            return item1.Equals(item2);
        }
    }
}
