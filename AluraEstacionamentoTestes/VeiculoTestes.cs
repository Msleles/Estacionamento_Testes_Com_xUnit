using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace AluraEstacionamentoTestes
{
    public class VeiculoTestes
    {
        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
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
            var veiculo = new Veiculo();
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
            var carro = new Veiculo();
            carro.Proprietario = "Carlos";
            carro.Placa = "ZAP-7419";
            carro.Cor = "Verde";
            carro.Modelo = "Variante";
            carro.Tipo = TipoVeiculo.Automovel;

            // ACT
            string dados = carro.ToString();

            // Assert
            Assert.Contains("Ficha do Veiculo:", dados);
            

        }

    }

}
