//Kevin Wong-Hua
// strobeBeacon.cs
// used for p5

// strobeBeacon is-a beacon that alternates its signal response, 
// oscillating between negative and positive (or high and low). 
// strobeBeacons cannot be recharged. 
// 
// strobeBeacon will initially start at high value mode
// getSignal() will return either a high value or low value if on and charged otherwise returns 0
// I designed the high value to be the maximum value of the sequence and the low value be the minimum
// 
// charge()
// strobeBeacon does not support charging, so calling this method will do nothing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _32_P3
{
    public class strobeBeacon : beacon
    {
        int high =0;
        int low =0;
        bool choice = true;
        public strobeBeacon(int[] seq) : base(seq)
        {
            determineHigh();
            determineLow();
        }
        public override int getSignal() {
            if (on && charged)
            {
                charges++;
                if (charges == chargesBound)
                {
                    charged = false;
                    on = false;
                    return 0;
                }
                if (choice)
                {
                    choice = !choice;

                    return high;
                }
                choice = !choice;
                return low;
            }
            return 0;
        }
        public sealed override void charge()
        {

        }

        private void determineHigh()
        {
            if (sequence == null || sequence.Length == 0) { }

            else { high = sequence.Max(); }
        }
        private void determineLow()
        {
            if (sequence == null || sequence.Length == 0) { }

            else { low = sequence.Min(); }
        }
    }
}
// implementation:
// getSignal() will either give max or min value of sequence
//
// charge() overrided but does nothing and is sealed as strobeBeacon does not support charging
// sealed makes it future childs of strobeBeacon will not be able to inherit charge()