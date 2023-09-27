using Compiladores_Clase.AnalisisLexico;
using Compiladores_Clase.GestorErrores;
using Compiladores_Clase.TablaCompenetes;
using Compiladores_Clase.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Compiladores_Clase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataCache.AgregarLinea("");
            DataCache.AgregarLinea("Segunda Línea");
            DataCache.AgregarLinea("5  3  2  1");

            AnalizadorLexico analex = new AnalizadorLexico();

            try
            {
                ComponenteLexico componente = analex.DevolverSiguienteComponente();

                do
                {
                    componente = analex.DevolverSiguienteComponente();

                } while (!CategoriaGramatical.FIN_DE_ARCHIVO.Equals(componente.Categoria));

              

            }catch(Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
            ImprimirComponentes(TipoComponente.SIMBOLO);
            ImprimirComponentes(TipoComponente.LITERAL);
            ImprimirComponentes(TipoComponente.DUMMY);
            ImprimirComponentes(TipoComponente.PALABRA_RESERVADA);
                Thread.Sleep(20000);

        }

        private static void ImprimirComponentes(TipoComponente tipo)
        {
            Console.WriteLine("Inicio componentes " + tipo.ToString());

            List<ComponenteLexico> componentes =
                TablaMaestra.ObtenerTablaMaestra().ObtenerTodosSimbolos(tipo);
            foreach (ComponenteLexico componente in componentes)
            {
                Console.WriteLine(componente.ToString());
            }


            Console.WriteLine("Fin componentes " + tipo.ToString());

        }

        private static void ImprimirErrores(TipoError tipo)
        {
            Console.WriteLine("Inicio errores " + tipo.ToString());

            List<Error> errores =
                ManejadorErrores.ObtenerManejadorErrores().ObtenerErrores(tipo);

            foreach (Error errore in errores)
            {
                Console.WriteLine(errore.ToString());
            }


            Console.WriteLine("Fin componentes " + tipo.ToString());

        }

    }
}
