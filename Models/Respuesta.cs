using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_07_PreguntadORT.Models
{
    public class Respuesta
    {
        public int IdRespuesta {get; set;}
        public int IdPregunta {get; set;}
        public int Opcion {get; set;}
        public string? Contenido {get; set;}
        public bool Correcta {get; set;}
        public string? Foto {get; set;}
    }
}