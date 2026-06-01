using LocadoraVeiculos.Domain.Entities;

namespace LocadoraVeiculos.Domain.Tests.Entities;

public class VeiculoTests
{
    [Fact]
    public void Deve_Criar_Veiculo_Valido()
    {
        // Arrange & Act
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Assert
        Assert.Equal("ABC1234", veiculo.Placa);
        Assert.Equal("Corolla", veiculo.Modelo);
        Assert.Equal(150, veiculo.ValorDaDiaria);
        Assert.True(veiculo.Disponivel);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Placa_For_Vazia()
    {
        Assert.Throws<ArgumentException>(() =>
            new Veiculo(
                "",
                "Corolla",
                150));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Modelo_For_Vazio()
    {
        Assert.Throws<ArgumentException>(() =>
            new Veiculo(
                "ABC1234",
                "",
                150));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Valor_Da_Diaria_For_Menor_Ou_Igual_A_Zero()
    {
        Assert.Throws<ArgumentException>(() =>
            new Veiculo(
                "ABC1234",
                "Corolla",
                0));
    }

    [Fact]
    public void Deve_Tornar_Veiculo_Indisponivel()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Act
        veiculo.TornarIndisponivel();

        // Assert
        Assert.False(veiculo.Disponivel);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Tornar_Indisponivel_Um_Veiculo_Ja_Indisponivel()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        veiculo.TornarIndisponivel();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            veiculo.TornarIndisponivel());
    }

    [Fact]
    public void Deve_Tornar_Veiculo_Disponivel()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        veiculo.TornarIndisponivel();

        // Act
        veiculo.TornarDisponivel();

        // Assert
        Assert.True(veiculo.Disponivel);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Tornar_Disponivel_Um_Veiculo_Ja_Disponivel()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            veiculo.TornarDisponivel());
    }

    [Fact]
    public void Deve_Alterar_Valor_Da_Diaria()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Act
        veiculo.AlterarValorDaDiaria(200);

        // Assert
        Assert.Equal(200, veiculo.ValorDaDiaria);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Alterar_Valor_Da_Diaria_Com_Valor_Invalido()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            veiculo.AlterarValorDaDiaria(0));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Alterar_Para_O_Mesmo_Valor_Da_Diaria()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            veiculo.AlterarValorDaDiaria(150));
    }

    [Fact]
    public void Deve_Indicar_Que_Veiculo_Pode_Ser_Locado()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        // Act & Assert
        Assert.True(veiculo.PodeSerLocado());
    }

    [Fact]
    public void Deve_Indicar_Que_Veiculo_Nao_Pode_Ser_Locado()
    {
        // Arrange
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        veiculo.TornarIndisponivel();

        // Act & Assert
        Assert.False(veiculo.PodeSerLocado());
    }
}