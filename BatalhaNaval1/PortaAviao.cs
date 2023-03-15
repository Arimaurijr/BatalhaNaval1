using System;
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
