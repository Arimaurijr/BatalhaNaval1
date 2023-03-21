using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval1
{
    internal class Jogador
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        private string[] Colunas = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };

        private Tabuleiro tabuleiro;

        public void RecebeTabuleiro(Tabuleiro tabuleiro)
        {
            this.tabuleiro = tabuleiro;
            this.Vida = 3;
        }

        public int Atacar(int linha, int coluna)
        {
            int acerto;
            acerto = tabuleiro.MarcarNoTabuleiro(linha, coluna);

            return acerto;
        }
        public void DecrementarVida()
        {
            
            this.Vida -= 1;
        }

        public int CheckColumn (string a)
        {
            for(int i = 0; i < Colunas.Length; i++)
            {
                if (Colunas[i].Equals(a.ToUpper()))
                {
                    return i;
                }
            }
            return 100;
        }

        public int CheckLine(Jogador jog1, Jogador jog2)
        {
            int linha = 0;
            bool success = int.TryParse(Console.ReadLine(), out linha);
            while (success != true)
            {
                Console.Clear();
                tabuleiro.Exibicao();
                Console.WriteLine();
                Console.WriteLine("## Não Digite caracteres por favor. Digite um valor inteiro. ##");
                MensagemReturn1Line(jog1, jog2);
                success = int.TryParse(Console.ReadLine(), out linha);
            }
            return linha;
        }

        public void MensagemReturn1Line(Jogador jog1, Jogador jog2)
        {
            Console.WriteLine();
            Console.WriteLine($"Sua vez {jog1.Nome}");
            Console.WriteLine($"VIDA {jog1.Nome}: {jog1.Vida}");
            Console.WriteLine($"VIDA {jog2.Nome}: {jog2.Vida}");
            Console.Write("DIGITE A LINHA[0 - 19]: ");
        }

        public void MensagemReturn2Line(Jogador jog2, Jogador jog1)
        {
            Console.WriteLine();
            Console.WriteLine($"Sua vez {jog2.Nome}");
            Console.WriteLine($"VIDA {jog2.Nome}: {jog2.Vida}");
            Console.WriteLine($"VIDA {jog1.Nome}: {jog1.Vida}");
            Console.Write("DIGITE A LINHA[0 - 19]: ");
        }

        public void MensagemReturn1Column(Jogador jog1, Jogador jog2)
        {
            Console.WriteLine();
            Console.WriteLine($"Sua vez {jog1.Nome}");
            Console.WriteLine($"VIDA {jog1.Nome}: {jog1.Vida}");
            Console.WriteLine($"VIDA {jog2.Nome}: {jog2.Vida}");
        }

        public void MensagemReturn2Column(Jogador jog2, Jogador jog1)
        {
            Console.WriteLine();
            Console.WriteLine($"Sua vez {jog2.Nome}");
            Console.WriteLine($"VIDA {jog2.Nome}: {jog2.Vida}");
            Console.WriteLine($"VIDA {jog1.Nome}: {jog1.Vida}");
        }

    }
}
