using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    public abstract class Auto
    {
        public double VelikostNadrze { get; protected set; }
        public double StavNadrze { get; set; }
        public TypPaliva Palivo { get; set; }

        public Auto(double velikostNadrze, TypPaliva palivo, double stavNadrze = 0)
        {
            VelikostNadrze = velikostNadrze;
           
            Palivo = palivo;

            if (stavNadrze > velikostNadrze)
            {
                throw new ArgumentException("stav nadrze nemoze byt vacsi nez velikost nadrze");
            }
            StavNadrze = stavNadrze;

        }

        public void Natankuj(TypPaliva typ, double mnozstvi)
        {
            if (typ != Palivo)
            {
                throw new ArgumentException("Nesprávný typ paliva");

            }
            else if (mnozstvi + StavNadrze > VelikostNadrze)
            {
                throw new ArgumentException("Preplnena nadrz");
            }
            else
            {
                StavNadrze = StavNadrze + mnozstvi;
            }
        }
    }

    public enum TypPaliva
    {
        Benzin,
        Nafta
    }
}
