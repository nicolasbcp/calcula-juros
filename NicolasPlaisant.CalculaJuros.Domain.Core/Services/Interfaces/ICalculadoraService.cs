using NicolasPlaisant.CalculaJuros.Shared.Models;

namespace NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces
{
    public interface ICalculadoraService
    {
        string CalculaJuros(CalculadoraRequestDTO request);
    }
}
