using Compiladores_Clase.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_Clase.AnalisisLexico
{
    public class AnalizadorLexico
    {

        private int numeroLineaActual = 0;
        private int puntero = 0;
        private int posicionIncial = 0;
        private int posicionFinal = 0;
        private string caracterActual = "";
        private string lexema = "";
        private string categoria = "";
        private string estadoActual = "";
        private string contenidoLineaActual = "";
        private bool continuarAnalisis = false;


        public AnalizadorLexico() {

            CargarNuevaLiena();
        }


        private void CargarNuevaLiena()
        {
            if (!"@EOF@".Equals(contenidoLineaActual))
            {
                numeroLineaActual += 1;
                contenidoLineaActual = DataCache.ObtennerLinea(numeroLineaActual).Contenido;
                numeroLineaActual = DataCache.ObtennerLinea(numeroLineaActual).NumerLinea;
                puntero = 1;
                
            }

        }
        private void LeerSiguienteCaracter()
        {
            if ("@EOF@".Equals(contenidoLineaActual))
            {
                caracterActual = "@EOF@";
            }else if (puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@FL@";
            }
            else {
                caracterActual = contenidoLineaActual.Substring(puntero - 1,1);
                puntero += 1;
              }
        }

        private void DevolverPuntero()
        {
            if (!"@FL@".Equals(caracterActual))
            { 
                puntero -= 1;
            }

        }

        private void Concatenar()
        {
            lexema += caracterActual;
        }

        private void Resetear()
        {
            estadoActual = "q0";
            lexema = "";
            categoria = "";
            posicionIncial= 0;
            posicionFinal = 0;
            caracterActual = "";
            continuarAnalisis = true;
        }

        public string DevolverSiguienteComponenete()
        {
            Resetear();

            while (continuarAnalisis)
            {
                if ("q0".Equals(estadoActual))
                {
                    ProcesarEstado0();
                    
                }
                else if ("q1".Equals(estadoActual))
                {
                    ProcesarEstado1();

                }
                else if ("q2".Equals(estadoActual))
                {
                    ProcesarEstado2();

                }
                else if ("q3".Equals(estadoActual))
                {
                    ProcesarEstado3();

                }
                else if ("q4".Equals(estadoActual))
                {
                    ProcesarEstado4();
                  
                }else if ("q12".Equals(estadoActual))
                {
                    ProcesarEstado12();
                  
                }else if ("q13".Equals(estadoActual))
                {
                    ProcesarEstado13();
                  
                }
                else if ("q14".Equals(estadoActual))
                {
                    ProcesarEstado14();

                }else if ("q15".Equals(estadoActual))
                {
                    ProcesarEstado15();

                }
                else if ("q16".Equals(estadoActual))
                {
                    ProcesarEstado16();

                }
                else if ("q17".Equals(estadoActual))
                {
                    ProcesarEstado17();

                }
                else
                {
                    ProcesarEstado18();

                }


            
            }
                return lexema;
        }
        private void QuitarespaciosBlanco()
        {
            while ("".Equals(caracterActual.Trim()) || "\t".Equals(caracterActual))
            {
                LeerSiguienteCaracter();
            }

        }
        private void ProcesarEstado0()
        {
            QuitarespaciosBlanco();

            if(UtilTexto.EsLetra(caracterActual) || UtilTexto.EsGuionBajo(caracterActual) || UtilTexto.EsSignoPesos(caracterActual))
            {
                estadoActual = "q4";
            }
            else if (UtilTexto.EsDigito(caracterActual))
            {
                estadoActual = "q1";
            }

            else if (UtilTexto.EsFinArchivo(caracterActual))
            {
                estadoActual = "q12";
            }

            else if (UtilTexto.EsFinLinea(caracterActual))
            {
                estadoActual = "q13";
            }

            else
            {
                estadoActual = "q18";
            }


        }

        private void ProcesarEstado1()
        {

            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsDigito(caracterActual))
            {

                estadoActual = "q1";
            }
            else if (UtilTexto.EsComa(caracterActual))
            {
                estadoActual = "q2";
            }
            else
            {
                estadoActual = "q14";

            }

        }

        public void ProcesarEstado2()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsDigito(caracterActual))
            {

                estadoActual = "q3";
            }
            else
            {
                estadoActual = "q17";
            }



        }

        public void ProcesarEstado3()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsDigito(caracterActual))
            {

                estadoActual = "q3";
            }
            else
            {
                estadoActual = "q15";
            }



        }

        private void ProcesarEstado4()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsLetraODigito(caracterActual) || UtilTexto.EsGuionBajo(caracterActual) || UtilTexto.EsSignoPesos(caracterActual))
            {
                estadoActual = "q4";
            }
            else
            {
                estadoActual = "q16";
            }
        }


        private void ProcesarEstado12()
        {
            categoria = "FIN ARCHIVO";
            FormarComponenteLexico();
            continuarAnalisis = false;
        }

        private void ProcesarEstado13()
        {
            CargarNuevaLiena();
            Resetear();
            
        }

        private void ProcesarEstado14()
        {
            DevolverPuntero();
            categoria = "ENTERO";
            FormarComponenteLexico();
            continuarAnalisis = false;
        } 
        private void ProcesarEstado15()
        {
            DevolverPuntero();
            categoria = "DECIMAL";
            FormarComponenteLexico();
            continuarAnalisis = false;
        }
        private void ProcesarEstado16()
        {
            DevolverPuntero();
            categoria = "IDENTIFICADOR";
            FormarComponenteLexico();
            continuarAnalisis = false;                    
        }

        private void ProcesarEstado17()
        {
            DevolverPuntero();
            categoria = "ERROR DECIMAL NO VÁLIDO";
            FormarComponenteLexico();
            continuarAnalisis = false;
        } 
        private void ProcesarEstado18()
        {
            categoria = "ERROR SÍMOBOLO NO VÁLIDO";
            FormarComponenteLexico();
            throw new Exception("Símbolo no reconocido dentro del lenguaje");
        }




        private void FormarComponenteLexico()
        {
            posicionIncial = puntero - lexema.Length;
            posicionFinal = puntero - 1;

            Console.WriteLine("categoria: " + categoria);
            Console.WriteLine("lexema: " + lexema);
            Console.WriteLine("Numero de linea: " + numeroLineaActual);
            Console.WriteLine("Posición Incial: " + posicionIncial);
            Console.WriteLine("Posición Final: " + posicionFinal);

        }



    }

}
