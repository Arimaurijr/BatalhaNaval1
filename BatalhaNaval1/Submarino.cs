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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
