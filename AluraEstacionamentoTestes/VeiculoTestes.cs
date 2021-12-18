using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AluraEstacionamentoTestes
{
    public class VeiculoTestes : IDisposable
    {


        private readonly Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste; //

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }



        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }


        [Fact]
        [Trait("Funcionalidade","Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip ="Teste ainda não implementado! Ignorar")]
        public void ValidaNomeProprietario()
        {

        }


        [Fact]
        public void DadosVeiculo()
        {
            // Arrange
           // var carro = new Veiculo();
            veiculo.Proprietario = "Carlos";
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";
            veiculo.Tipo = TipoVeiculo.Automovel;

            // ACT
            string dados = veiculo.ToString();

            // Assert
            Assert.Contains("Ficha do Veiculo:", dados);
            

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }

}
