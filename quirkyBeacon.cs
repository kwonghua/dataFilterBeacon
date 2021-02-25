// Kevin Wong-Hua
// quirkyBeacon.cs
// used for p5

// quirkyBeacon is-a beacon that emits signals from which a discernible pattern is not evident. 
// quirkyBeacons can be turned off and on only a limited number of times(variable across type but stable for an individual object). 

using System;
using System.Collections.Generic;
using System.Text;

namespace _32_P3
{
    public class quirkyBeacon : beacon
    {
        private int limit;
        private int switchCounter = 0;
        private const int chosenConst = 7;
        public quirkyBeacon(int[] seq) : base(seq)
        {
            if(seq != null)
                limit = seq.Length / 2;
        }


        public override bool switchPower()
        {
            if (switchCounter != limit)
            {
                switchCounter++;
                base.switchPower();
            }
            return on;
        }

        protected override int determineSignal()
        {
            return (base.determineSignal()) % chosenConst;
        }
    }
}
// implementation:
// quirkyBeacon only allowed to turn off and on a limited amount of times, 
// I decided to make this limit be the half the size of the passed in sequence rounded down as its an int
// 
// quirkyBeacon will give a quirky or unexpected signal, i decided to just make it a the base signal modulus by a constant, chosenConst
// An alternative is to make it seem more 'random' but I think doing something simple as using modulus it makes it unexpected as well
//
// switchCounter only counting whenever switchPower() is called
// 