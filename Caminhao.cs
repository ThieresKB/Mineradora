namespace ProvaMineradora
{
    public class Caminhao
    {
        public Caminhao() 
        {
            Motorista = new Motorista();
        }
        public string? Placa { get; set; }
        public string? Modelo { get; set; }
        public Motorista? Motorista { get; set; }
    }
}
