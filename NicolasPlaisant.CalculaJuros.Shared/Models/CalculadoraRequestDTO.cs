using System;
using System.Collections.Generic;
using System.Text;

namespace NicolasPlaisant.CalculaJuros.Shared.Models
{
    public class CalculadoraRequestDTO
    {
        public decimal ValorInicial{ get; set; }
        public int Tempo { get; set; }
    }
}
