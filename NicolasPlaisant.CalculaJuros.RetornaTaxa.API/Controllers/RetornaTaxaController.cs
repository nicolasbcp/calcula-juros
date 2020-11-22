using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;

namespace NicolasPlaisant.CalculaJuros.RetornaTaxa.API.Controllers
{
    #pragma warning disable CS1591
    [Route("api/calcula-juros/v1")]
    [ApiController]
    public class RetornaTaxaController : ControllerBase
    {
        // Apesar de não utilizada, deixei a implementação caso trabalhasse com outras taxas
        // ou maneiras de cálculo
        private readonly IComumService _service;

        public RetornaTaxaController(IComumService service) => _service = service;

        /// <summary>
        /// Busca taxa de juros fixada
        /// </summary>
        /// <returns>Retorna taxa de juros fixada</returns>
        /// <response code="200">Retorna taxa de juros fixada</response>
        [HttpGet]
        [Route("taxaJuros")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public double RecuperaTaxaJuros()
            => 0.01;
    }
}
