namespace CampusNet.Models
{
    // Clase principal del modelo que gestiona el grafo
    public class Graph
    {
        // Lista de usuarios (vértices)
        public Dictionary<string, Vertex> Vertices { get; private set; } = new();

        // Lista de adyacencia: quién sigue a quién
        public Dictionary<string, List<string>> AdjacencyList { get; private set; } = new();

        // Agregar usuario
        public void AddVertex(Vertex v)
        {
            if (!Vertices.ContainsKey(v.Id))
            {
                Vertices[v.Id] = v;
                AdjacencyList[v.Id] = new List<string>();
            }
        }

        // Eliminar usuario y sus relaciones
        public void RemoveVertex(string id)
        {
            if (Vertices.ContainsKey(id))
            {
                Vertices.Remove(id);
                AdjacencyList.Remove(id);

                // Eliminarlo de las listas de otros
                foreach (var list in AdjacencyList.Values)
                    list.Remove(id);
            }
        }

        // Agregar relación (A → B)
        public void AddEdge(string origen, string destino)
        {
            if (Vertices.ContainsKey(origen) && Vertices.ContainsKey(destino))
            {
                if (!AdjacencyList[origen].Contains(destino))
                    AdjacencyList[origen].Add(destino);
            }
        }

        // Eliminar relación
        public void RemoveEdge(string origen, string destino)
        {
            if (AdjacencyList.ContainsKey(origen))
                AdjacencyList[origen].Remove(destino);
        }

        // Actualizar datos de usuario
        public void UpdateVertex(string id, string nuevoNombre, string nuevoRol)
        {
            if (Vertices.ContainsKey(id))
            {
                Vertices[id].Nombre = nuevoNombre;
                Vertices[id].Rol = nuevoRol;
            }
        }

        // Obtener usuarios sin seguidores (grado de entrada 0)
        public List<Vertex> GetUsuariosSinSeguidores()
        {
            var conSeguidores = new HashSet<string>(AdjacencyList.Values.SelectMany(v => v));
            return Vertices.Values.Where(v => !conSeguidores.Contains(v.Id)).ToList();
        }

        // Obtener usuarios más influyentes (grado de entrada mayor)
        public List<Vertex> GetUsuariosInfluyentes()
        {
            var entradas = Vertices.Keys.ToDictionary(k => k, k => 0);
            foreach (var lista in AdjacencyList.Values)
                foreach (var destino in lista)
                    entradas[destino]++;

            int max = entradas.Values.Max();
            return Vertices.Values.Where(v => entradas[v.Id] == max).ToList();
        }

        // Usuarios más activos (grado de salida mayor)
        public List<Vertex> GetUsuariosMasActivos()
        {
            int max = AdjacencyList.Values.Max(l => l.Count);
            return Vertices.Values.Where(v => AdjacencyList[v.Id].Count == max).ToList();
        }

        // BFS
        public List<string> BFS(string inicio)
        {
            var visitados = new List<string>();
            var cola = new Queue<string>();
            cola.Enqueue(inicio);

            while (cola.Count > 0)
            {
                var actual = cola.Dequeue();
                if (!visitados.Contains(actual))
                {
                    visitados.Add(actual);
                    foreach (var vecino in AdjacencyList[actual])
                        cola.Enqueue(vecino);
                }
            }
            return visitados;
        }

        // DFS con detección de ciclos
        public List<string> DFS()
        {
            var visitados = new HashSet<string>();
            var resultado = new List<string>();

            foreach (var v in Vertices.Keys)
                DFSRecursivo(v, visitados, resultado, new HashSet<string>());

            return resultado;
        }

        private void DFSRecursivo(string actual, HashSet<string> visitados, List<string> resultado, HashSet<string> pila)
        {
            if (pila.Contains(actual))
                Console.WriteLine($"Ciclo detectado en: {actual}");
            if (visitados.Contains(actual)) return;

            visitados.Add(actual);
            pila.Add(actual);
            resultado.Add(actual);

            foreach (var vecino in AdjacencyList[actual])
                DFSRecursivo(vecino, visitados, resultado, pila);

            pila.Remove(actual);
        }

        // Verificar si un usuario A puede llegar a B mediante BFS
        public bool PuedeLlegar(string origen, string destino)
        {
            var visitados = BFS(origen);
            return visitados.Contains(destino);
        }
    }
}
