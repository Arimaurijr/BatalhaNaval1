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

    }
}
