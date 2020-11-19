using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;
using NicolasPlaisant.CalculaJuros.Shared.Models;
using System;

namespace NicolasPlaisant.CalculaJuros.Domain.Core.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        private readonly IComumService _comumService;

        public CalculadoraService(IComumService comumService)
        {
            _comumService = comumService;
        }

        public string CalculaJuros(CalculadoraRequestDTO request)
        {
            var valorJuros = _comumService.TaxaJuros();

            var primeiraParte = 1 + valorJuros;
            var segundaParte = Math.Pow(primeiraParte, request.Tempo);

            decimal valorFinal = request.ValorInicial * Convert.ToDecimal(segundaParte);

            return string.Format("{0:0.00}", valorFinal);
        }
    }
}
