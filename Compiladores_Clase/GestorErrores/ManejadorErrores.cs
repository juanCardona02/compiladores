using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_Clase.GestorErrores
{
    public class ManejadorErrores
    {

        private Dictionary<TipoError,List<Error>> errores = new Dictionary<TipoError, List<Error>>();
        
        private static readonly ManejadorErrores INSTANCIA = new ManejadorErrores();

        private ManejadorErrores() {

            Limpiar();
        
        }

        public static ManejadorErrores ObtenerManejadorErrores() {
        
            return INSTANCIA;
        }

        public void Limpiar()
        {

            
        }

        public void ReportarError(Error error)
        {
            if (error != null)
            {
                errores[error.Tipo].Add(error);


                if (CategoriaErrror.STOPPER.Equals(error.Categoria))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("****************ERROR TIPO STOPPER ****************").Append("\r\n");
                    stringBuilder.Append("Se ha presentado un error tipo stopper dentro del proceso").Append(error.Tipo).Append("\r\n");
                    stringBuilder.Append("Por favor solucionar el problema para seguir con el proceso de compilación").Append("\r\n");
                    stringBuilder.Append("Verifique la tabla de errores para mayor detalle").Append("\r\n");
                    throw new Exception(stringBuilder.ToString());

                }
            }

        }

        public bool HayErrores(TipoError tipo)
        {
            return errores.ContainsKey(tipo) && errores[tipo].Count > 0;

        }


        public bool HayErroresAnalisis()
        {
            return HayErrores(TipoError.LEXICO) || HayErrores(TipoError.SINTACTICO) || HayErrores(TipoError.SEMANTICO);

        }

        public bool HayErroresSintesis()
        {
            return HayErrores(TipoError.GENERADOR_INTERMEDIO) || HayErrores(TipoError.OPTIMIZACION) || HayErrores(TipoError.GENERADOR_CODIGO_FINAL);

        }

        public bool HayErroresCompilacion()
        {

            return HayErroresAnalisis() || HayErroresSintesis();
        }

        public List<Error> ObtenerErrores(TipoError tipo)
        {

            return errores[tipo];
        }

    }
}
