using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    public class Osobni : Auto
    {
        public int PrepravovaneOsoby { get;private set; }
        public int MaxOsob { get;private set; }

        public Osobni(double velikostNadrze, TypPaliva palivo, int maxOsob,double stavNadrze=0) : base(velikostNadrze, palivo,stavNadrze)
        {
            MaxOsob = maxOsob;
            PrepravovaneOsoby = 0;
        }
        public void NastavPrepravovaneOsoby(int pocet)
        {
            if(pocet > MaxOsob)
            {
                throw new ArgumentException($"Toto auto neodvezie viac ako {MaxOsob} osob");

            }
            PrepravovaneOsoby = pocet;
        }
    }
}
