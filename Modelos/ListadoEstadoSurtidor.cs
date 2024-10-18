namespace PistaServicios.Modelos
{
    public class ListaEstadoSurtidor
    {
        public int NumeroSurtidor { get; set; }
        public string Estado { get; set; }

        public ListaEstadoSurtidor(int numeroSurtidor, string estado)
        {
            NumeroSurtidor = numeroSurtidor;
            Estado = estado;
        }
    }
}
