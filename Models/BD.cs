using System.Data.SqlClient;
using Dapper;
using TP_07_PreguntadORT.Models;

namespace TP_07_PreguntadORT.Models;

public static class BD
{
    private static string connectionString = @"Server = localhost; DataBase = BD_PreguntadORT; Trusted_Connection = True;";

    public static List<Categoria> ObtenerCategorias()
    {
        using(SqlConnection db = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Categorias";
            return db.Query<Categoria>(sql).ToList();
        }
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        using(SqlConnection db = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Dificultades";
            return db.Query<Dificultad>(sql).ToList();
        }
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        using(SqlConnection db = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad AND IdCategoria = @pCategoria";
            if(dificultad == -1){
                sql = sql.Replace("IdDificultad = @pDificultad AND", "");
            }
            if(categoria == -1){
                sql = sql.Replace(" AND IdCategoria = @pCategoria", "");
                sql = sql.Replace(" WHERE  IdCategoria = @pCategoria", "");
            }
            return db.Query<Pregunta>(sql, new{pDificultad = dificultad, pCategoria = categoria}).ToList();
        }
    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        List<Respuesta> listaRespuestas = new List<Respuesta>();

        using(SqlConnection db = new SqlConnection(connectionString))
        {
            foreach (var item in preguntas)
            {
                string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pPregunta";
                listaRespuestas.AddRange(db.Query<Respuesta>(sql, new{pPregunta = item.IdPregunta}).ToList());
            }
        }

        return listaRespuestas;
    }

    public static void InsertarPuntajes(string username, int puntaje, int cantcorrectas){
        string sql = "INSERT INTO Puntajes(Username, FechaHora, Puntaje, CantCorrectas) VALUES(@pUsername, @pFechaHora, @pPuntaje, @pCantCorrectas)";
        
        using(SqlConnection db = new SqlConnection(connectionString))
        {
            db.Execute(sql, new{pUsername = username, pFechaHora = DateTime.Now, pPuntaje = puntaje, pCantCorrectas = cantcorrectas});
        }
    }

    public static List<puntaje> ObtenerPuntajes(){
        using(SqlConnection db = new SqlConnection(connectionString))
        {
            string sql = "SELECT Top 10 * FROM Puntajes order by Puntaje desc";
            return db.Query<puntaje>(sql).ToList();
        }
    }
}