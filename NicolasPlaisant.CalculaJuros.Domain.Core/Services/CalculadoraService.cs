using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;
using NicolasPlaisant.CalculaJuros.Shared.Models;
using RestSharp;
using System;

namespace NicolasPlaisant.CalculaJuros.Domain.Core.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        // Opção caso fosse possível usar uma Service em comum, para evitar consumo de API da mesma solução
        private readonly IComumService _comumService;

        public CalculadoraService(IComumService comumService)
        {
            // Opção caso fosse possível usar uma Service em comum, para evitar consumo de API da mesma solução
            _comumService = comumService;
        }

        /// <summary>
        /// Método funcional como requisitado na prova
        /// Recebe dois parâmetros: objeto com informações da requisição e URL da API consumida
        /// </summary>
        /// <param name="request"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public string CalculaJuros(CalculadoraRequestDTO request)
        {
            try
            {
                string baseUrl = Environment.GetEnvironmentVariable("RetornaTaxaApi");

                if (string.IsNullOrEmpty(baseUrl))
                    baseUrl = "https://localhost:44326/api/calcula-juros/v1/taxaJuros";

                ValidacoesIniciais(request);

                var client = new RestClient(baseUrl);
                var response = client.Execute(new RestRequest());

                // Uma vez que o valor dos juros é fixado, não há problema em trabalhar com a divisão abaixo
                double valorJuros = Convert.ToDouble(response.Content) / 100;

                var primeiraParte = 1 + valorJuros;

                // Uso da biblioteca Math para trabalhar com potência
                var segundaParte = Math.Pow(primeiraParte, request.Tempo);

                decimal valorFinal = request.ValorInicial * Convert.ToDecimal(segundaParte);

                // Formatação do retorno com duas casas decimais
                return string.Format("{0:0.00}", valorFinal);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro inesperado, seguem informações:\n", e);
            }
        }

        /// <summary>
        /// OPÇÃO NÃO UTILIZADA
        /// Coloquei caso optasse por não consumir uma própria API da mesma solução
        /// Optando por trabalhar com uma service comum das APIs
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CalculaJurosViaService(CalculadoraRequestDTO request)
        {
            var valorJuros = _comumService.TaxaJuros();

            var primeiraParte = 1 + valorJuros;
            var segundaParte = Math.Pow(primeiraParte, request.Tempo);

            decimal valorFinal = request.ValorInicial * Convert.ToDecimal(segundaParte);

            return string.Format("{0:0.00}", valorFinal);
        }

        public void ValidacoesIniciais(CalculadoraRequestDTO request)
        {
            if (request == null)
                throw new Exception("O corpo da requisição é de preenchimento obrigatório.");

            if (request.Tempo < 1)
                throw new Exception("Tempo inválido. Preencha o campo com a quantidade de meses.");
        }
    }
}
