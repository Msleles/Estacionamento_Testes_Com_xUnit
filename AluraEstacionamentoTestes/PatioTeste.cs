using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace AluraEstacionamentoTestes
{
    public class PatioTeste : IDisposable
    {

        private readonly Veiculo veiculo;
        private readonly Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            estacionamento = new Patio();
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }


        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange

            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Maycon Santos Leles";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "FOX";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act

            double faturamento = estacionamento.TotalFaturado();

            //Assert 
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("DANILO ROMAO", "ASD-1428", "BRANCO", "COROLA")]
        [InlineData("MAYCON LELES", "ABD-1325", "PRETO", "FUSCA")]
        [InlineData("DAIANE SENA", "BCG-1025", "PRTA", "HILUX")]
        [InlineData("BRUNO CARDOSO", "ATP-3696", "VERMELHO", "HB20")]
        [InlineData("DANIEL TIBA", "EUA-0001", "VERMELHO", "Model X - TESLA")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {

            //Arrange

            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Tipo = TipoVeiculo.Automovel;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);



        }

        [Theory]
        [InlineData("DANILO ROMAO", "ASD-1428", "BRANCO", "COROLA")]
        public void LocalizaVeiculoNoPatio(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            //Arrange

            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Tipo = TipoVeiculo.Automovel;
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            //ACT

            var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);

        }

        [Fact]
        public void AlterarDadosVeiculo()
        {

            //Arrange

            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Maycon  Leles";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "FOX";
            veiculo.Placa = "asd-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Maycon Leles";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "verde";
            veiculoAlterado.Modelo = "FOX";
            veiculoAlterado.Placa = "asd-3999";
            estacionamento.RegistrarEntradaVeiculo(veiculoAlterado);

            //ACT
            var alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }
}
