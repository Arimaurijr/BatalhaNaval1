﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval1
{
    internal class PortaAviao : Navio 
    {
        public PortaAviao()
        {
            this.Nome = "Porta avião";
            this.Tamanho = 4;
        }
        public PortaAviao(int tipo_de_jogador)
        {
            this.Nome = "Porta avião";
            this.Tamanho = 4;
            this.Vida = 4;

            if (tipo_de_jogador == 1)
            {
                this.Caracter = 'P';
            }
            else
            {
                this.Caracter = 'p';
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
