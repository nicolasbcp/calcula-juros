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
        /// Recebe um objeto que contém valor inicial e tempo como parâmetro
        /// Chama a service de cálculo e retorna o valor
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("calculadora")]
        public string Post([FromBody] CalculadoraRequestDTO request)
            => _service.CalculaJuros(request);
    }
}
