using Microsoft.AspNetCore.Mvc;
using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;

namespace NicolasPlaisant.CalculaJuros.RetornaTaxa.API.Controllers
{
    [Route("api/calcula-juros/v1")]
    [ApiController]
    public class RetornaTaxaController : ControllerBase
    {
        // Apesar de não utilizada, deixei a implementação caso trabalhasse com outras taxas
        // ou maneiras de cálculo
        private readonly IComumService _service;

        public RetornaTaxaController(IComumService service) => _service = service;

        [HttpGet]
        [Route("taxaJuros")]
        public double RecuperaTaxaJuros()
            => 0.01;
    }
}
