using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    public class Nakladni : Auto
    {
        public double MaxNaklad { get; private set; }
        public double PrepravovanyNaklad { get; private set; }

        public Nakladni(double velikostNadrze, TypPaliva palivo, double maxNaklad,double stavNadrze=0) :base(velikostNadrze, palivo, stavNadrze)
        {
            MaxNaklad = maxNaklad;
            PrepravovanyNaklad = 0;
        }
        public void NastavPrepravovanyNaklad(double mnozstvi)

        {
            if (mnozstvi > MaxNaklad)
            {
                throw new ArgumentException($"Toto vozidlo moze prepravit max. {MaxNaklad} kg");
            }
            PrepravovanyNaklad += mnozstvi;
            
        }

    }
}
