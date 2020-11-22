using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;
using NicolasPlaisant.CalculaJuros.Shared.Models;

namespace NicolasPlaisant.CalculaJuros.Calculadora.API.Controllers
{
    [Route("api/calcula-juros/v1")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly ICalculadoraService _service;

        public CalculadoraController(ICalculadoraService service) => _service = service;

        /// <summary>
        /// Calcula a taxa de juros composta sob o valor informado
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna o valor calculado</returns>
        /// <response code="200">Retorna o valor calculado</response>
        /// <response code="400">Campos obrigatórios não informados, favor preencher</response>
        [HttpPost]
        [Route("calculajuros")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string CalcularJuros([FromBody] CalculadoraRequestDTO request)
            => _service.CalculaJuros(request);

        /// <summary>
        /// Retorna URL do projeto no Github
        /// </summary>
        /// <param name="request"></param>
        /// <returns>URL do projeto</returns>
        /// <response code="200">Retorna URL do projeto no Github</response>
        [HttpGet]
        [Route("showmethecode")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string ShowMeTheCode()
            => "https://github.com/nicolasbcp/calcula-juros";
    }
}
