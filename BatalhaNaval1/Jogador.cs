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

        public int CheckLine()
        {
            int linha = 0;
            bool success = int.TryParse(Console.ReadLine(), out linha);
            while (success != true)
            {
                Console.WriteLine("Não Digite caracteres por favor. Digite um valor inteiro: ");
                success = int.TryParse(Console.ReadLine(), out linha);
            }
            return linha;
        }

    }
}
