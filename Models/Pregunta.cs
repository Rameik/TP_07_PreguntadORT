using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_07_PreguntadORT.Models
{
   public class Pregunta
   {
        public int IdPregunta{get; set;}
        public int IdCategoria {get; set;}
        public int IdDificultad {get; set;}
        public string? Enunciado {get; set;}
        public string? Foto {get; set;}
   }
}