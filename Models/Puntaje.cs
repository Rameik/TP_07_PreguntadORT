using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_07_PreguntadORT.Models
{
    public class puntaje{
        public int IdUsuario {get; set;}
        public string Username {get; set;}
        public DateTime FechaHora {get;set;}
        public int Puntaje {get;set;}
        public int CantCorrectas {get;set;}
    }
}