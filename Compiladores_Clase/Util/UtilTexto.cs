using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_Clase.Util
{
   public class UtilTexto
    {

        public static bool EsLetra(string caracter)
        {
            return Char.IsLetter(caracter, 0);
        }
        public static bool EsDigito(string caracter)
        {
            return Char.IsDigit(caracter, 0);
        }

        public static bool EsGuionBajo(string caracter)
        {
            return "_".Equals(caracter);
        }
        
        public static bool EsComa(string caracter)
        {
            return ",".Equals(caracter);
        }
        public static bool EsFinArchivo(string caracter)
        {
            return "@EOF@".Equals(caracter);
        }public static bool EsFinLinea(string caracter)
        {
            return "@FL@".Equals(caracter);
        }
        

        public static bool EsSignoPesos(string caracter)
        {
            return "$".Equals(caracter);
        }public static bool EsLetraODigito(string caracter)
        {
            return Char.IsLetterOrDigit(caracter,0);
        }


    }
}
