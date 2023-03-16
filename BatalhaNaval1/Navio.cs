using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval1
{
    internal class Navio
    {

        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public int Vida { get; set; }
        public char Caracter { get; set; }

        public Jogador jogador { get; set; }

        public void ReceberJogador(Jogador jogador)
        {
            this.jogador = jogador;
        }

        public override string ToString()
        {
            return Nome + " foi destruído !";
        }
       
    }
}
