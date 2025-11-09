using CampusNet.Models;

namespace CampusNet.Views
{
    public class GraphView
    {
        public void MostrarListaAdyacencia(Dictionary<string, List<string>> lista)
        {
            Console.WriteLine("\n=== LISTA DE ADYACENCIA ===");
            foreach (var kv in lista)
            {
                string conexiones = kv.Value.Count > 0 ? string.Join(", ", kv.Value) : "Sin conexiones";
                Console.WriteLine($"{kv.Key} → {conexiones}");
            }
        }

        public void MostrarRecorrido(string tipo, List<string> recorrido)
        {
            Console.WriteLine($"\n=== RECORRIDO {tipo} ===");
            Console.WriteLine(string.Join(" → ", recorrido));
            Console.WriteLine($"Total alcanzados: {recorrido.Count}");
        }

        public void MostrarUsuarios(string titulo, List<Vertex> usuarios)
        {
            Console.WriteLine($"\n=== {titulo} ===");
            if (usuarios.Count == 0)
                Console.WriteLine("Ninguno encontrado.");
            else
                foreach (var u in usuarios)
                    Console.WriteLine(u);
        }
    }
}
