using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_Clase
{
    public class DataCache


    {

        private static Dictionary<int, Linea> programaFuente = new Dictionary<int, Linea>();  
    
        public static void Limpiar()
        {
        programaFuente.Clear();
        }

        public static void AgregarLinea(String linea)
        {
            if (linea != null)

        {
                int numeroLinea = ObtenerProximaLinea();

                programaFuente.Add(numeroLinea, Linea.Crear(numeroLinea, linea));
        }
        }

    public static void AgregarLineas(List<String> lineas)
    {
        foreach(String linea in lineas)
        {
            AgregarLinea(linea);
        }
    }

   

        public static int ObtenerProximaLinea()
    {
        return programaFuente.Count + 1;
        

        }

    public static Linea ObtennerLinea(int numeroLinea)
    {
            int numeroUltimaLinea = ObtenerProximaLinea();
        Linea lineaRetorno = Linea.Crear(numeroUltimaLinea, "@EOF@");

        if(numeroLinea <= 0)
        {
            throw new Exception("Número de linea inválido");

        }else if(numeroLinea <= programaFuente.Count)
        {
       
            lineaRetorno = programaFuente[numeroLinea];
        }

        return lineaRetorno;
    }

    }


    
}
