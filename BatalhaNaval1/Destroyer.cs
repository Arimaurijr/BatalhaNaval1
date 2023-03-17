using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval1
{
    internal class Destroyer : Navio
    {
        public Destroyer()
        {
            this.Nome = "Destroyer";
            this.Tamanho = 3;
        }

        public Destroyer(int tipo_de_jogador)
        {
            this.Nome = "Destroyer";
            this.Tamanho = 3;

            if (tipo_de_jogador == 1)
            {
                this.Caracter = 'D';
            }
            else
            {
                this.Caracter = 'd';
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
                this.jogador.DecrementarVida();
            }
        }
    }
}
