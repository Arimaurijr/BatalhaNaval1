using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval1
{
    internal class Submarino : Navio
    {
        public Submarino()
        {
            this.Nome = "Submarino";
            this.Tamanho = 2;
        }
        public Submarino(int tipo_de_jogador)
        {
            this.Nome = "Submarino";
            this.Tamanho = 2;
            this.Vida = 2;

            if (tipo_de_jogador == 1)
            {
                this.Caracter = 'S';
            }
            else
            {
                this.Caracter = 's';
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void DecrementarVida()
        {
            this.Vida -= 1;

            if (this.Vida == 0)
            {
                Console.WriteLine(base.ToString());
                this.jogador.DecrementarVida();
            }
        }
    }
}
