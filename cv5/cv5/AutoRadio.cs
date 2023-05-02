<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    internal class AutoRadio
    {
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    internal class AutoRadio
    {
        private Dictionary<int, double> preset = new Dictionary<int, double>();

        // Aktualny kmitocet
        public double Kmitocet { get; set; }

        // Stav zapnutia radia (true = zapnute, false = vypnute)
        public bool Zapnute { get; set; }

        // Konstruktor pre nastavenie defaultneho kmitoctu a nastavenie radia na vypnute
        public AutoRadio(double kmitocet = 107.00)
        {
            Kmitocet = kmitocet;
            Zapnute = false;
        }

        // Metoda na nastavenie predvolby
        public void NastavPredvolbu(int cislo, double kmitocet)
        {
            // Ak predvolba s danym cislom neexistuje, tak ju pridaj
            if (!preset.ContainsKey(cislo))
            {
                this.preset.Add(cislo, kmitocet);
            }
            // Ak uz predvolba s danym cislom existuje, tak ju aktualizuj
            else
            {
                this.preset.Remove(cislo);
                this.preset.Add(cislo, kmitocet);
            }
        }

        // Metoda na preladenie na predvolbu
        public void PreladPredvolbu(int cislo)
        {
            // Skus najst predvolbu v dictionary podla zadaneho cisla
            if (preset.TryGetValue(cislo, out double value))
            {
                // Ak bola najdena, tak nastav kmitocet na hodnotu predvolby
                this.Kmitocet = value;
            }
            // Ak nebola najdena, tak vyhod vynimku s oznamom, ze predvolba neexistuje
            else
            {
                throw new Exception("Not in preset");
            }
        }

        // Prekryta metoda ToString() pre zobrazenie informacii o stave radia
        public override string ToString()
        {
            if (Zapnute == false)
            {
                return "Radio je off";
            }
            else
            {
                return String.Format("Kmitocet je {0, 0:N2}", Kmitocet);
            }
        }
    }

}
>>>>>>> 84489ebf86e044165eb0b646d0428de7c99a1740
