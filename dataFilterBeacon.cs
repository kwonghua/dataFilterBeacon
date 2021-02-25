// Kevin Wong-Hua
// dataFilterBeacon.cs
// used for p5
//
// dataFilterBeacon has a beacon and dataFilter encapsulated
// user can expect this object to interact like a dataFilter and beacon object combined
// a dataFilterBeacon can be on or off, charged or not, and in 'small' or 'large' mode
// 
// dataFilterBeacon can be constructed with a int sequence array and some number n used for dataFilter
// both the encapuslated beacon and dataFilter will contain the same sequence
// and in that case base beacon and base dataFilter will be used
// if either a dataFilter or beacon type is passed in as null, dataFilterBeacon will never be deactivated
// supports passing in of IDataFilter and IBeacon childs as they can stand in for beacon and dataFilter
//
// Caliing any 'action' methods such as filter(), scramble(seq), and getSignal() will reduce a charge
// upon using all charges, dataFilterBeacon will be turned off and need to be charged again
//
// filter()
// will only return valid response if active (on and charged) and not deactivated otherwise will return null
// behaves based on the type of dataFilter 
// for example base dataFilter expected results is:
// if the encapsulated sequence in dataFilter is null it will return the encapsulated dataFilter "p" num + the signal from beacon
// otherwise returns a sequence based on the dataFilter filter() method seq with signal value added to it 
// 
// for example in base class: 
//    1) when in ‘large’ mode, all integers larger than p, and then signal value will be added to it
//    2) when in ‘small’ mode, all integers smaller than p, and then signal value will be added to it
//
// likewise for a dataMod class we may expect all values to be decremented or incremented AND the value of signal added to every element returned.
//
// and the signal will depend on the type of beacon, for example in my base beacon user can expect the average value of the beacon sequence
// and for a strobeBeacon they will expect a high or low number, etc..
//
// switchMode()
// switches from large to small or small to large mode
//
// getSignal()
// returns the signal value from beacon if is active (on and charged)
// otherwise will return 0
//
// scramble(seq)
// behaves based on the type of dataFilter
// will replace the dataFilter sequence if seq is not null or empty AND if is active (on and charged)
// otherwise will return null
// and returns a reordered integer sequence from dataFilter scramble comparing with the beacon signal number
//     1) in 'large' mode returns the reordered sequence of all integers larger than the signal
//     2) in 'small' mode returns the reordered sequence of all integers smaller than the signal
// For example it will compare the signal number to the result from dataFilter.scramble() array
// the type of dataFilter may affect the outcome
// for example dataCut will remove previous scramble values, dataMod will turn prime numbers into "2"
// and type of beacon may also affect the outcome
//
// For example, dataFilter in large mode scramble call with { 16, 25, 30, 45, 60, 55, 78, 96 }
// We would expect dataFilter.scramble() to return a list like this { 96, 78, 55, 60, 45, 30, 25, 16 }
// dataFilterBeacon will compare that array with its signal number
// 
// isActive()
// returns if state is active
// if deactivated will return false
//
// charge()
// charges the beacon if not deactivated
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _32_P3
{
    public class dataFilterBeacon : IBeacon, IDataFilter
    {
        dataFilter dataFilter;
        beacon beacon;
        bool deactivated = false;

        public dataFilterBeacon(int[] seq, int n)
        {
            if(seq == null || seq.Length == 0)
            {
                deactivated = true;
            }

            beacon = new beacon(seq);
            dataFilter = new dataFilter(seq, n);
        }
        public dataFilterBeacon(dataFilter fil, beacon bea) { 
            if(fil == null || bea == null)
            {
                deactivated = true;
            }
            beacon = bea;
            dataFilter = fil;
        }
        // post: state may be changed
        public bool switchMode()
        {
            if(!deactivated)
                return dataFilter.switchMode();
            return false;
        }
        // post: state may be changed
        public int getSignal()
        {
            if (!deactivated)
            {
                return beacon.getSignal();
            }
            return 0;
        }
        // post: state may be changed
        public int[] filter()
        {
            if (!deactivated && beacon.isActive())
            {
                int[] tmp = dataFilter.filter();
                int mySignal = beacon.getSignal();

                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] += mySignal;
                }
                return tmp;
            }
            return null;
        }
        // post: state may be changed
        public int[] scramble(int[] ar)
        {
            if(!deactivated && beacon.isActive() && ar != null && ar.Length != 0)
            {
                int[] tmp;
                int mySignal = beacon.getSignal();
                if (dataFilter.isLarge())
                {
                    tmp = largeScramble(dataFilter.scramble(ar), mySignal);
                }
                else
                {
                    tmp = smallScramble(dataFilter.scramble(ar),mySignal);
                }
                return tmp;
            }
            return null;
        }
        public bool isActive() { 
            if(!deactivated)
                return beacon.isActive();
            return false;
        }
        // post: state may be changed
        public bool switchPower()
        {
            if(!deactivated)
                return beacon.switchPower();
            return false;
        }
        // post: state may be changed
        public void charge()
        {
            if(!deactivated)
                beacon.charge();
        }

        private int[] largeScramble(int[] sequence, int p)
        {
            ArrayList arList = new ArrayList();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (p < sequence[i])
                {
                    arList.Add(sequence[i]);
                }
            }
            int[] list = (int[])arList.ToArray(typeof(int));
            return list;
        }

        private int[] smallScramble(int[] sequence,int p)
        {
            ArrayList arList = new ArrayList();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (p > sequence[i])
                {
                    arList.Add(sequence[i]);
                }
            }
            int[] list = (int[])arList.ToArray(typeof(int));
            return list;
        }
    }
}
// Implementation:
// state is maintained through the beacon object and dataFilter and deactivated
// every 'action' method needs beacon to be active and dataFilterBeacon to not be deactivated
//
// deactivated is internal state that is triggered only if passing in bad values such as null dataFilter or beacon type, null or empty arrays to the constructor
// should check if deactivated first in case of beacon or dataFilter being null and trying to call the encapsulated object methods
// if beacon is off and not charged, 'action' methods should not return valid results should either be zeroed out or return null
//
// for filter(), I decided to have a very simple interaction between dataFilter and beacon
// I have thought of doing a case by case interaction: 
// for example 
// dataMod class:
//    1) when in 'large' mode, all integers are added + signal value to it
//    2) when in 'small' mode, all integers are subtracted - signal value to it
// dataCut class:
//    1) when in 'large' mode, the largest number in sequence is removed and the new largest will have signal value added to it
//    2) when in 'small' mode, the smallest number in sequence is removed and the new smallest will have signal value subtracted to it
//
// However this implementation above using case by case is not very maintainable because if a new dataFilter type is added
// we would need to add a new case every time, and each depending on the implementation of filter() method in the dataFilter type
// will change the outcome already, same idea for scramble() method
// can make methods virtual open for extension
// 
// type of beacon may affect the object
// for example strobeBeacon may provide a low or high signal value which switches every 'action' or filter(), scramlbe(), and getSignal() call 
// and quirkyBeacon may only be turned on or off a limited amount of times before it will not turn back on and basically be deactivated
// 
// since any child can stand for parent object such as beacon or dataFilter this class will satisfy all cross products combinations 