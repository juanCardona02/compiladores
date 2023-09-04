using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_Clase
{
    public class Linea
    {

        private int numerLinea;
        private string contenido;

        private Linea(int numerLinea, string contenido)
        {
            NumerLinea = numerLinea;
            Contenido = contenido;
         
        }

        public static Linea Crear(int numerLinea,string  contenido)
        {
            return new Linea(numerLinea, contenido);
        }
        public int NumerLinea { get => numerLinea; set => numerLinea = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
