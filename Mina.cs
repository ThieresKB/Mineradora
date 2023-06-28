using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaMineradora
{
    public class Mina
    {
        public Mina(decimal area, string descricao) 
        {
            Area = area;
            Descricao = descricao;
        }
        public decimal? Area { get; set; }
        public string? Descricao { get; set; }
        public List<Caminhao>? Caminhoes { get; set; }
    }
}
