// Kevin Wong-Hua
// beacon.cs

// Define a second class hierarchy of beacons, where each beacon object:
// May be on or off
// May be charged or not
// Emits a signal, if on and charged, which reduces its charge
// Accepts an integer sequence to vary its signal
// 
// To construct a beacon, a integer sequence will need to be provided with its size
// upon constructon a beacon will be on and charged
// a beacon may call getSignal() a limited number of times before it will turn off and run out of charge
// the number of charges is based on the const int chargesBound
//
// getSignal() will return a integer number based on the sequence
// I decided to make getSignal return the average value of the given integer list
// getSignal will only return the correct integer if it is on and charged otherwise will return 0
// 
// switchPower() will switch the beacon on or off only when charged
// returns current state after calling switchPower()
// will not affect the charge state
// 
// charge() will fully charge the beacon
//
// isActive() returns if it is charged and on
//

using System;
using System.Collections.Generic;
using System.Text;

namespace _32_P3
{ 
    public class beacon : IBeacon
    {
        protected int[] sequence;
        protected bool on;
        protected bool charged;
        protected int signal;
        protected int charges;
        protected const int chargesBound = 5;
        public beacon(int[] seq)
        {
            if(seq == null || seq.Length == 0)
            {
                signal = 0;
            }
            else
            {
                sequence = seq;
                signal = determineSignal();
            }
            on = true;
            charged = true;
        }
        // post: state may be changed
        public virtual int getSignal()
        {
            if(isActive())
            {
                if(charges == chargesBound)
                {
                    charged = false;
                    on = false;
                    return 0;
                }
                charges++;
                return signal;
            }
            return 0;
        }
        // post: state will be changed
        public virtual bool switchPower()
        {
            if(charged)
                on = !on;
            return on;
        }
        // post: state may be changed
        public virtual void charge()
        {
            charged = true;
            charges = 0;
        }

        //pre: sequence must not be null or empty
        protected virtual int determineSignal()
        {
            int tmp = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                tmp += sequence[i];
            }
            return tmp / sequence.Length;
        }

        public bool isActive()
        {
            if(charges == chargesBound)
            {
                charged = false;
                on = false;
            }
            return charged && on;
        }
    }
}
// Implementation:
// every 'action' call such as getSignal() will drain a charge
// for each beacon the number of actions before it drains all charges is constant
// an alternative is to have a variable charge capacity based on something such as the passed in sequence
// 
// getSignal() returns the signal if on and charged otherwise will return 0 
//
// decided to make the signal based on the passed in sequence, the signal will be the average of the values
//
// the beacon can be turned off and on anytime it is charged using switchPower()
// doesn't make sense if its out of batteries and can still turn on
// 
// User can also charge beacon whenever they want with charge()
// when charging, it will fully charge it
//
// User can check if beacon is active (charged and on) using isActive()
//
// error checking:
// if given sequence is null or empty, signal is 0 and other than that beacon will behave as a beacon but essentially zeroed out
// check if charges is at the bounds when using isActive() because 
// without the bounds checking here charges can == chargesBound and may return misleading information that it is active
// client may expect next getSignal() call to be valid
