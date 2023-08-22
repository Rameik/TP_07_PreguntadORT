using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_07_PreguntadORT.Models
{
    public static class Juego
    {
        private static string? Username {get; set;}
        private static int puntajeActual {get; set;}
        private static int cantidadPreguntasCorrectas {get; set;}
        public static List<Pregunta>? listaPreguntas {get; set;}
        private static List<Respuesta>? listaRespuestas {get; set;}

        public static string ObtenerUsuario(){
            return Username;
        }

        public static int ObtenerPuntaje(){
            return puntajeActual;
        }

        public static int ObtenerPreguntasCorrectas(){
            return cantidadPreguntasCorrectas;
        }

        public static void InicializarJuego(){
            Username = "";
            puntajeActual = 0;
            cantidadPreguntasCorrectas = 0;

            listaPreguntas = new List<Pregunta>();
            listaRespuestas = new List<Respuesta>();
        }

        public static List<Categoria> ObtenerCategorias(){
            return BD.ObtenerCategorias();
        }
        public static List<Dificultad> ObtenerDificultades(){
            return BD.ObtenerDificultades();
        }

        public static void CargarPartida(string username, int dificultad, int categoria){
            Username = username;
            listaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
            listaRespuestas = BD.ObtenerRespuestas(listaPreguntas);
        }

        public static Pregunta ObtenerProximaPregunta(){
            Random rnd = new Random();
            int numRandom = rnd.Next(0, listaPreguntas.Count);

            return listaPreguntas[numRandom];
        }

        public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){
            List<Respuesta> lista = new List<Respuesta>();
            foreach (var item in listaRespuestas)
            {
                if(item.IdPregunta == idPregunta){
                    lista.Add(item);
                }
            }

            return lista; 
        }

        public static object[] VerificarRespuesta(int idPregunta, int idRespuesta){
            object[] correcto = new object[2];

            bool algo = false;

            foreach (var item in listaRespuestas)
            {
                if(item.IdPregunta == idPregunta && item.IdRespuesta == idRespuesta && item.Correcta == true){
                    puntajeActual += 5;
                    cantidadPreguntasCorrectas ++;
                    algo = true;
                    correcto[0] = true;
                }
                if(item.IdPregunta == idPregunta && item.Correcta == true){
                    correcto[1] = item;
                }
            }
            
            for (int j = 0; j < listaPreguntas.Count; j++) 
            {
                if (listaPreguntas[j].IdPregunta == idPregunta)
                {
                    listaPreguntas.RemoveAt(j);
                    j--;
                }
            }

            return correcto;
        }
    }
}