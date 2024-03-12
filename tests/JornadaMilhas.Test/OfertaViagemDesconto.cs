using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Theory]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, 20, 80)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 200, 100, 100)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 500, 50, 450)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 150, 151, 105)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 150, 150, 105)]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto(string origem, string destino, string dataIda, string dataVolta, double precoOriginal, double desconto, double precoComDesconto)
        {
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            oferta.Desconto = desconto;

            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }
    }
}
