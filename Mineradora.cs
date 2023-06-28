using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProvaMineradora
{
    public class Mineradora
    {
        private List<Caminhao> _caminhoesEmotoristas = new List<Caminhao>();
        private List<Mina> _mina = new List<Mina>();  

        public void Menu()
        {
            Console.Write(
                "==========Menu==========\n" +
                "1 - Cadastrar caminhões e Motoristas \n" +
                "2 - Cadastrar Mina \n" +
                "3 - Cadastrar Caminhões na mina\n" +    
                "4 - Mostrar informações da mineradora\n\n" +
                "5 - Finalizar programa\n\n" +
                ".: "
            );
        }
        public int getOpcao()
        {
            start:
            string opcao = Console.ReadLine();
            try
            {
                return int.Parse(opcao);
            }
            catch( FormatException ex )
            {
                Console.Clear();
                Menu();
                Console.Write( "Digite um numero: " );
                goto start; 
            }
            return 0;

        }
        public void setOpcao(int opcao)
        {
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    cadastrarMotoristaECaminhao();
                    break;
                case 2:
                    cadastrarMina();
                    break;
                case 3:
                    cadastrarCaminhoes();
                    break;
                case 4:
                    ListarTudo();
                    break;
                case 5:
                    end();
                    break;
                default:
                    Console.WriteLine("Opção desconhecida!");
                    break;
            };
        }
        private void cadastrarMina()
        {
            //var mina = new Mina();
            Console.Write("Qual a Area da mina (m²)? ");
            decimal area = decimal.Parse(Console.ReadLine());
            Console.Write("Descreva sobre: ");
            string desc = Console.ReadLine();
            _mina.Add(new Mina(area, desc));
            prossiga();
        }
        private void cadastrarMotoristaECaminhao()
        {
            var caminhao = new Caminhao();
            var motorista = new Motorista();
            Console.Write("Qual o nuero da placa? ");
            caminhao.Placa = Console.ReadLine();
            Console.Write("Qual o modelo do caminhão? ");
            caminhao.Modelo = Console.ReadLine();
            Console.Write("Qual o nome do motorista? ");
            motorista.Nome = Console.ReadLine();
            Console.Write("Qual o cpf do motorista? ");
            motorista.CPF = Console.ReadLine();
            caminhao.Motorista = motorista;
            _caminhoesEmotoristas.Add(caminhao);
            prossiga();
        }
        private void cadastrarCaminhoes()
        {
            Console.WriteLine("======== Lista de Minas ==========");
            int index = 0;
            if (_mina.Count > 0)
            {
                foreach(var mina in _mina)
                {
                    Console.WriteLine($"| {index++} | {mina.Area} m² | {mina.Descricao} |");
                }

                Console.WriteLine("Qual o numero da mina você escolhe: ");
                int minaEsc = int.Parse(Console.ReadLine());

                index = 0;
                Console.WriteLine("======== Lista de Caminhões ==========");
                if (_caminhoesEmotoristas.Count > 0)
                {
                    foreach (var moto in _caminhoesEmotoristas)
                    {
                        Console.WriteLine($"| {index++} | {moto.Placa} | {moto.Motorista.Nome} |");

                    }
                    Console.WriteLine("Qual o numero do caminhao você escolhe: ");
                    int motoEsc = int.Parse(Console.ReadLine());

                    _mina[minaEsc].Caminhoes.Add(_caminhoesEmotoristas[motoEsc]);
                }
                else
                {
                    Console.WriteLine("Não há caminhoes cadastrados");
                }
            }
            else
            {
                Console.WriteLine("Não há minas cadastradas");
            }
            prossiga();
        }
        private void ListarTudo()
        {
            int index = 0;
            Console.WriteLine("======== Lista de Minas ==========");
            if (_mina.Count > 0)
            {
                for (int x = 0; x <= _mina.Count; x++)
                {
                    Console.WriteLine($"| {index++} | {_mina[x].Area} m² | {_mina[x].Descricao} |");

                    for (int y = 0; y <= _caminhoesEmotoristas.Count; y++)
                    {
                        Console.WriteLine($"|   | {_mina[x].Caminhoes[y].Placa} m² | {_mina[x].Caminhoes[y].Modelo} | {_mina[x].Caminhoes[y].Motorista.Nome} | {_mina[x].Caminhoes[y].Motorista.CPF} |");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há minas cadastradas");
            }
            prossiga();
        }
        private void prossiga()
        {
            Console.Write("Aperte qualquer tecla...");
            Console.ReadLine();
            Console.Clear() ;
        }
        private void end()
        {
            Console.WriteLine("Encerrando o programa...");
            Environment.Exit(0);
        } 
    }
}
