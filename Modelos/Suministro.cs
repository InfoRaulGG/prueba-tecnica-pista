namespace PistaServicios.Modelos
{
    public class Suministro
    {
        public required DateTime Fecha { get; set; }
        public required int NumeroSurtidor { get; set; }
        public Double? ImportePrefijado { get; set; }
        public required Double ImporteSurtido { get; set; }
    }
}
