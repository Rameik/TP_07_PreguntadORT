using Microsoft.AspNetCore.Mvc;
using TP_07_PreguntadORT.Models;

namespace TP_07_PreguntadORT.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Creditos()
    {
        return View();
    }

    public IActionResult Puntajes()
    {
        ViewBag.ListaPuntajes = BD.ObtenerPuntajes();
        return View();
    }

    public IActionResult Tutorial()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias = Juego.ObtenerCategorias();
        ViewBag.Dificultades = Juego.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        if(Juego.listaPreguntas.Count == 0){
            return RedirectToAction("ConfigurarJuego");
        }
        else{
            return RedirectToAction("Jugar");
        }
    }

    public IActionResult Jugar()
    {
        if(Juego.listaPreguntas.Count == 0){
            ViewBag.Usuario = Juego.ObtenerUsuario();
            ViewBag.Puntaje = Juego.ObtenerPuntaje();
            ViewBag.cantidadPreguntasCorrectas = Juego.ObtenerPreguntasCorrectas();
            BD.InsertarPuntajes(ViewBag.Usuario, ViewBag.Puntaje, ViewBag.cantidadPreguntasCorrectas);
            ViewBag.ListaPuntajes = BD.ObtenerPuntajes();
            return View("Fin");
        }
        else{
            ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
            ViewBag.Usuario = Juego.ObtenerUsuario();
            ViewBag.Puntaje = Juego.ObtenerPuntaje();
            ViewBag.CantidadPreguntasCorrectas = Juego.ObtenerPreguntasCorrectas();
            ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);
            return View();
        }
    }

    [HttpPost] 
    
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        object[] Correcta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        ViewBag.Respuesta = Correcta[0];
        ViewBag.RespuestaCorrecta = Correcta[1];
        ViewBag.Usuario = Juego.ObtenerUsuario();
        ViewBag.Puntaje = Juego.ObtenerPuntaje();
        return View("Respuesta");
    }
}
