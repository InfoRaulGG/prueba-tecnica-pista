using PistaServicios.Enums;
using PistaServicios.Modelos;

namespace PistaServicios
{
    public class ControlPista
    {
        private static Pista _pista;

        public static void IniciarPista()
        {
           _pista = new Pista(10); // HACK: ejemplo hardcodeado con 10 surtidores
        }

        public static ICollection<ListaEstadoSurtidor> ObtenerEstadoSurtidores() => _pista.ObtenerEstadoSurtidores();
        public static ICollection<Suministro> ObtenerSuministros() => _pista.ObtenerSuministros();
        public static void TerminarSuministro(int numeroSurtidor, double importeSuministrado) => _pista.OperarSurtidor(OperacionSurtidor.ColgarManguera, numeroSurtidor, 0, importeSuministrado);
        public static void LiberarSurtidor(int numeroSurtidor) => _pista.OperarSurtidor(OperacionSurtidor.Liberar, numeroSurtidor);
        public static void PrefijarSurtidor(int numeroSurtidor, double cantidadPrefijada) => _pista.OperarSurtidor(OperacionSurtidor.Prefijar, numeroSurtidor, cantidadPrefijada);
        public static void BloquearSurtidor(int numeroSurtidor) => _pista.OperarSurtidor(OperacionSurtidor.Bloquear, numeroSurtidor);

    }
}
