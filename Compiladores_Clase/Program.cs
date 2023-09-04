using Compiladores_Clase.AnalisisLexico;
using Compiladores_Clase.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_Clase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataCache.AgregarLinea("");
            DataCache.AgregarLinea("Segunda linea  ");
            DataCache.AgregarLinea("5 3  2  1");

            AnalizadorLexico analizadorLex= new AnalizadorLexico();

            string lexema = analizadorLex.DevolverSiguienteComponenete();
            do
            {
                lexema = analizadorLex.DevolverSiguienteComponenete();
            }
            while (!UtilTexto.EsFinArchivo(lexema));
        }
    }
}
