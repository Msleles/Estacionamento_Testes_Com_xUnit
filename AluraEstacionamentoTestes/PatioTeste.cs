using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace AluraEstacionamentoTestes
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange

            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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

            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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

            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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

    }
}
