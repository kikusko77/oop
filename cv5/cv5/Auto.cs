using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    // Deklarace abstraktní třídy Auto
    public abstract class Auto
    {
        // Vytvoření instance třídy AutoRadio jako privátního atributu třídy Auto
        private AutoRadio autoradio = new AutoRadio();

        // Definice vlastnosti VelikostNadrze jako veřejné, pouze pro čtení
        public double VelikostNadrze { get; protected set; }

        // Definice vlastnosti StavNadrze jako veřejné, pro čtení a zápis
        public double StavNadrze { get; set; }

        // Definice vlastnosti Palivo jako veřejné, pro čtení a zápis
        public TypPaliva Palivo { get; set; }

        // Konstruktor třídy Auto
        public Auto(double velikostNadrze, TypPaliva palivo, double stavNadrze = 0)
        {
            VelikostNadrze = velikostNadrze;   // Nastavení vlastnosti VelikostNadrze podle předaného parametru

            Palivo = palivo;   // Nastavení vlastnosti Palivo podle předaného parametru

            // Kontrola, zda není stav nádrže větší než velikost nádrže
            if (stavNadrze > velikostNadrze)
            {
                throw new ArgumentException("stav nadrze nemoze byt vacsi nez velikost nadrze");
            }
            StavNadrze = stavNadrze;   // Nastavení vlastnosti StavNadrze podle předaného parametru
        }

        // Metoda pro natankování vozidla
        public void Natankuj(TypPaliva typ, double mnozstvi)
        {
            // Kontrola, zda odpovídá typ paliva s typem vozidla
            if (typ != Palivo)
            {
                throw new ArgumentException("Nesprávný typ paliva");
            }
            // Kontrola, zda by nádrž nepřetekla
            else if (mnozstvi + StavNadrze > VelikostNadrze)
            {
                throw new ArgumentException("Preplnena nadrz");
            }
            else
            {
                StavNadrze = StavNadrze + mnozstvi;   // Přičtení množství paliva k aktuálnímu stavu nádrže
            }
        }

        // Výčet typů paliv
        public enum TypPaliva
        {
            Benzin,
            Nafta
        }
        public double DajFrekvenciu()
        {
            return autoradio.Kmitocet;
        }
        public bool ZapnuteRadio()
        {
            return autoradio.Zapnute;
        }
        public void ZapniRadio(bool onOff)
        {
            autoradio.Zapnute = onOff;
        }
        public void nastavRadio(int cislo, double kmitocet)
        {
            autoradio.NastavPredvolbu(cislo, kmitocet);
        }

        public void preladNaPredvolbu(int cislo)
        {
            autoradio.PreladPredvolbu(cislo);
        }

        public void RetuneByHand(double kmitocet)
        {
            autoradio.Kmitocet = kmitocet;
        }
        public override string ToString()
        {
            return String.Format("Status of tank is {0} out of {1}. Type of fuel {2}. {3}. ", StavNadrze, VelikostNadrze, Palivo, autoradio.ToString());
        }
    }

    
    
}
