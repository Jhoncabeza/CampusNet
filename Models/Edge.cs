namespace CampusNet.Models
{
    // Clase que representa una relación de seguimiento dirigida (A → B)
    public class Edge
    {
        public string Origen { get; set; }
        public string Destino { get; set; }

        public Edge(string origen, string destino)
        {
            Origen = origen;
            Destino = destino;
        }
    }
}
