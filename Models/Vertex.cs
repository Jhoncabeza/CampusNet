namespace CampusNet.Models
{
    // Clase que representa un usuario (vértice del grafo)
    public class Vertex
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public Vertex(string id, string nombre, string rol)
        {
            Id = id;
            Nombre = nombre;
            Rol = rol;
        }

        public override string ToString()
        {
            return $"{Id} - {Nombre} ({Rol})";
        }
    }
}
