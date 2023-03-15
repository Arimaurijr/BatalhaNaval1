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

        public override string ToString()
        {
            return base.ToString();
        }
      
            
    }
}
