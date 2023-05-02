<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv5
{
    // derived class Nakladni from base class Auto
    public class Nakladni : Auto
    {
        // properties
        public double MaxNaklad { get; private set; }  // maximum cargo capacity of the truck
        public double PrepravovanyNaklad { get; set; }  // amount of cargo currently being transported by the truck

        // constructor
        public Nakladni(double velikostNadrze, TypPaliva palivo, double maxNaklad, double stavNadrze = 0) : base(velikostNadrze, palivo, stavNadrze)
        {
            // initialize properties
            MaxNaklad = maxNaklad;
            PrepravovanyNaklad = 0;
        }

        // method to set the amount of cargo being transported by the truck
        public void NastavPrepravovanyNaklad(double mnozstvi)
        {
            // check if the specified amount of cargo exceeds the maximum capacity of the truck
            if (mnozstvi > MaxNaklad)
            {
                throw new ArgumentException($"Toto vozidlo moze prepravit max. {MaxNaklad} kg");
            }

            // add the specified amount of cargo to the current cargo being transported by the truck
            PrepravovanyNaklad += mnozstvi;
        }

        // override ToString() method to return a string representation of the object
        public override string ToString()
        {
            return $"Nakladni: Palivo={Palivo}, StavNadrze={StavNadrze}, PrepravovanyNaklad={PrepravovanyNaklad}";
        }
    }
}


>>>>>>> 84489ebf86e044165eb0b646d0428de7c99a1740
