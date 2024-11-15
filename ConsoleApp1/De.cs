using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class De
    {
        char[] lettres;
        char lettre;

        public De(char[] lettres, char lettre)
        {
            if(lettres.Length == 6)
            {
                this.lettres = lettres;
            }
            this.lettre = lettre;
        }
        public void Lance(Random r)
        {

        }
    }
}
