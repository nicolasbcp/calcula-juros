using System.ComponentModel.DataAnnotations;

namespace NicolasPlaisant.CalculaJuros.Shared.Models
{
    public class CalculadoraRequestDTO
    {
        [Required]
        public decimal ValorInicial{ get; set; }
        [Required]
        public int Tempo { get; set; }
    }
}
