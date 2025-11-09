using CampusNet.Models;
using CampusNet.Views;

namespace CampusNet.Controllers
{
    public class GraphController
    {
        private readonly Graph grafo;
        private readonly GraphView vista;

        public GraphController()
        {
            grafo = new Graph();
            vista = new GraphView();
        }

        public void Ejecutar()
        {
            Console.WriteLine("=== CAMPUSNET - GRAFO DIRIGIDO ===");

            // Crear usuarios
            grafo.AddVertex(new Vertex("1", "Ana", "Estudiante"));
            grafo.AddVertex(new Vertex("2", "Luis", "Profesor"));
            grafo.AddVertex(new Vertex("3", "María", "Egresada"));
            grafo.AddVertex(new Vertex("4", "Pedro", "Estudiante"));
            grafo.AddVertex(new Vertex("5", "Sofía", "Profesor"));
            grafo.AddVertex(new Vertex("6", "Carlos", "Estudiante"));
            grafo.AddVertex(new Vertex("7", "Elena", "Egresada"));
            grafo.AddVertex(new Vertex("8", "Raúl", "Profesor"));
            grafo.AddVertex(new Vertex("9", "Marta", "Estudiante"));
            grafo.AddVertex(new Vertex("10", "Juan", "Egresado"));
            grafo.AddVertex(new Vertex("11", "Patricia", "Estudiante"));
            grafo.AddVertex(new Vertex("12", "Diego", "Profesor"));

            // Relaciones (18+)
            grafo.AddEdge("1", "2");
            grafo.AddEdge("1", "3");
            grafo.AddEdge("1", "4");
            grafo.AddEdge("2", "5");
            grafo.AddEdge("2", "6");
            grafo.AddEdge("2", "3");
            grafo.AddEdge("3", "1");
            grafo.AddEdge("3", "4");
            grafo.AddEdge("3", "5");
            grafo.AddEdge("4", "3");
            grafo.AddEdge("5", "6");
            grafo.AddEdge("5", "7");
            grafo.AddEdge("5", "8");
            grafo.AddEdge("5", "9");
            grafo.AddEdge("6", "10");
            grafo.AddEdge("7", "2");
            grafo.AddEdge("8", "5");
            grafo.AddEdge("9", "12");
            grafo.AddEdge("10", "1"); // Crea ciclo 1→2→3→1

            vista.MostrarListaAdyacencia(grafo.AdjacencyList);

            // Recorridos
            vista.MostrarRecorrido("BFS desde Ana", grafo.BFS("1"));
            vista.MostrarRecorrido("BFS desde Luis", grafo.BFS("2"));
            vista.MostrarRecorrido("BFS desde Sofía", grafo.BFS("5"));

            vista.MostrarRecorrido("DFS completo", grafo.DFS());

            // Consultas
            vista.MostrarUsuarios("Usuarios sin seguidores", grafo.GetUsuariosSinSeguidores());
            vista.MostrarUsuarios("Usuarios más influyentes", grafo.GetUsuariosInfluyentes());
            vista.MostrarUsuarios("Usuarios más activos", grafo.GetUsuariosMasActivos());

            Console.WriteLine("\n¿Puede llegar Ana -> Marta? " +
                (grafo.PuedeLlegar("1", "9") ? "Sí" : "No"));

            // Ejemplo CRUD
            grafo.AddVertex(new Vertex("13", "Lucía", "Estudiante"));
            grafo.AddEdge("13", "1");
            grafo.UpdateVertex("13", "Lucía Torres", "Egresada");
            grafo.RemoveEdge("13", "1");
            grafo.RemoveVertex("13");

            Console.WriteLine("\nOperaciones CRUD completadas correctamente.");
        }
    }
}
