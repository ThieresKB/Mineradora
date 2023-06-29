
using ProvaMineradora;

var Mineradora = new Mineradora();
while (true)
{
    Mineradora.Menu();
    int opcao = Mineradora.getOpcao();
    Mineradora.setOpcao(opcao);
    Console.Clear();
}

