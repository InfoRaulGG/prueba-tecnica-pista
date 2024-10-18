using PistaServicios.Enums;

namespace PistaServicios.Modelos
{
    public class Pista
    {
        private ICollection<Surtidor> _surtidores { get; set; }
        private ICollection<Suministro> _suministros { get; set; }

        public Pista(int numSurtidores)
        {
            _surtidores = new List<Surtidor>();
            _suministros = new List<Suministro>();

            for (int i = 0; i < numSurtidores; i++)
            {   
                var surtidor = new Surtidor(i + 1);
                surtidor.SuministroCompletado += RegistrarSuministro;
                _surtidores.Add(surtidor);
            }
        }
        public void OperarSurtidor(OperacionSurtidor operacionSurtidor, int numeroSurtidor, double cantidadPrefijada = 0, double cantidadSuministrada = 0)
        {
            var surtidorElegido = _surtidores.FirstOrDefault(x => x.NumeroSurtidor == numeroSurtidor);
            if (surtidorElegido == null)
            {
                throw new Exception("Surtidor no existe");
            }

            switch (operacionSurtidor)
            {
                case OperacionSurtidor.Bloquear:
                    surtidorElegido.BloquearSurtidor();
                    break;
                case OperacionSurtidor.Prefijar:
                    surtidorElegido.LiberarSurtidor(cantidadPrefijada);
                    break;
                case OperacionSurtidor.Liberar:
                    surtidorElegido.LiberarSurtidor();
                    break;
                case OperacionSurtidor.ColgarManguera:
                    surtidorElegido.RealizarSuministro(cantidadSuministrada);
                    break;
                default: throw new Exception("Debes seleccionar una acción");
            }
        }

        public ICollection<ListaEstadoSurtidor> ObtenerEstadoSurtidores()
        {
            return _surtidores.Select(x =>
            {
                return new ListaEstadoSurtidor(x.NumeroSurtidor, x.Estado.ToString());
            })
            .ToList();
        }

        public ICollection<Suministro> ObtenerSuministros() => _suministros.OrderByDescending(x => x.ImporteSurtido).ThenByDescending(x => x.Fecha).ToList();

        public void RegistrarSuministro(object sender, Suministro e)
        {
            if (e != null)
            {
                _suministros.Add(e);
            }
        }
    }
}


