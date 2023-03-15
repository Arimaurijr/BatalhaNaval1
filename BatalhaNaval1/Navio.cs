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

        public override string ToString()
        {
            return Nome + " foi destruído !";
        }
        public void DecrementarVida()
        {
            this.Vida -= 1;
        }
    }
}
