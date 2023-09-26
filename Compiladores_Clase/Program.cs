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
            DataCache.AgregarLinea("Segunda Línea");
            DataCache.AgregarLinea("5 + 3 + 2 + 1");

            AnalizadorLexico analex = new AnalizadorLexico();
            ComponenteLexico componente = analex.DevolverSiguienteComponente();

            do
            {
                Console.WriteLine(componente.ToString());
                componente = analex.DevolverSiguienteComponente();

            } while (!CategoriaGramatical.FIN_DE_ARCHIVO.Equals(componente.Categoria));
            Console.WriteLine(componente.ToString());
        }
    }
}
