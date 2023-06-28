
using ProvaMineradora;

while (true)
{
    var Mineradora = new Mineradora();
    Mineradora.Menu();
    int opcao = Mineradora.getOpcao();
    Mineradora.setOpcao(opcao);
    Console.Clear();
}

