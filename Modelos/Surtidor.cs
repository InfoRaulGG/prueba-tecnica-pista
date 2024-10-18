using PistaServicios.Enums;

namespace PistaServicios.Modelos
{

    public class Surtidor
    {
        public int NumeroSurtidor { get; set; }
        public double CantidadPrefijada { get; set; }
        public EstadoSurtidores Estado { get; set; }

        public Surtidor(int numeroSurtidor)
        {
            NumeroSurtidor = numeroSurtidor;
            Estado = EstadoSurtidores.Bloqueado;
            CantidadPrefijada = 0;
        }


        public event EventHandler<Suministro> SuministroCompletado;

        protected virtual void OnSuministroCompletado(Suministro e)
        {
            SuministroCompletado?.Invoke(this, e);
        }

        public void LiberarSurtidor(double cantidadPrefijada = 0)
        {
            Estado = EstadoSurtidores.Libre;
            CantidadPrefijada = cantidadPrefijada;
        }

        public void BloquearSurtidor()
        {
            Estado = EstadoSurtidores.Bloqueado;
            CantidadPrefijada = 0;
        }

        public void RealizarSuministro(double importeSuministrado)
        {
            if (Estado == EstadoSurtidores.Libre)
            {
                OnSuministroCompletado(new Suministro
                {
                    ImporteSurtido = importeSuministrado,
                    Fecha = DateTime.Now,
                    ImportePrefijado = CantidadPrefijada,
                    NumeroSurtidor = NumeroSurtidor
                });

                BloquearSurtidor();
            }
        }
    }
}
