using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;

namespace NicolasPlaisant.CalculaJuros.Domain.Core.Services
{
    public class ComumService : IComumService
    {
        private double juros = 0.01;

        public ComumService() { }

        public double TaxaJuros()
        {
            return juros;
        }
    }
}
