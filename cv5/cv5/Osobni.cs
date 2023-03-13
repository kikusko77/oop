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

        // konštruktor triedy s argumentami pre veľkosť nádrže, typ paliva, maximálny počet osôb a stav nádrže
        public Osobni(double velikostNadrze, TypPaliva palivo, int maxOsob, double stavNadrze = 0) : base(velikostNadrze, palivo, stavNadrze)
        {
            // nastavenie hodnoty vlastnosti "MaxOsob" na hodnotu parametra "maxOsob"
            MaxOsob = maxOsob;
            // nastavenie hodnoty vlastnosti "PrepravovaneOsoby" na hodnotu 0
            PrepravovaneOsoby = 0;
        }

        // metóda na nastavenie počtu prepravovaných osôb
        public void NastavPrepravovaneOsoby(int pocet)
        {
            // ak zadaný počet osôb je väčší ako maximálny počet osôb
            if (pocet > MaxOsob)
            {
                // vyvolanie výnimky s hláškou, že toto auto neodvezie viac ako hodnotu vlastnosti "MaxOsob"
                throw new ArgumentException($"Toto auto neodvezie viac ako {MaxOsob} osob");
            }
            // nastavenie hodnoty prepravovaneOsoby na hodnotu parametra "pocet"
            PrepravovaneOsoby = pocet;
        }

        // prepísanie metódy "ToString()" triedy "Auto"
        public override string ToString()
        {
            // vrátenie reťazca s informáciami o triede "Osobni" a jej vlastnostiach
            return $"Osobni: Palivo={Palivo}, StavNadrze={StavNadrze}, PrepravovaneOsoby={PrepravovaneOsoby}";
        }
    }

}
