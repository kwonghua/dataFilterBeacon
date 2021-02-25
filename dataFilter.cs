// Kevin Wong-Hua
// dataFilter.cs

// Class/public Invariant
//
// dataFilter is an object that will encapsulate a non-negative prime number with a int array sequence
// dataFilter is intially set to 'Large' mode
// if the given number is not a prime number, it will be updated to the nearest greatest prime number 
// if given a negative number it will be updated to a default value
//
// filter() 
// 1) returns ‘p’ if the internal sequence is null
// 2) Otherwise, returns,
//    1) when in ‘large’ mode, all integers larger than p
//    2) when in ‘small’ mode, all integers smaller than p
// 
// scramble(seq)
// 1) updates the encapsulated sequence with seq, if not null or empty
// 2) returns a reordered integer sequence, as follows
//    1) When in ‘large’ mode, views a sequence of n integers as n/2 pairs
//       For each pair, exchanges the values, if necessary to have the larger value first
//    2) When in ‘small’ mode, views a sequence of n integers as n/2 pairs
//        For each pair, exchanges the values, if necessary to have the smaller value first
//
// post: state will be changed
// switchMode()
// switches from large to small or small to large mode


using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace _32_P3
{

    public class dataFilter : IDataFilter
    {
        protected int p;
        protected int[] sequence; 
        protected bool mode;
        protected const int defaultPrimeNum = 43;


        public dataFilter(int[] seq, int n) {
            if(n < 0)
            {
                p = defaultPrimeNum;
            }
            else if (!isPrime(n))
            {
                p = nextPrime(n);
            } else {
                p = n;
            }

            if (seq == null || seq.Length == 0)
            {
                sequence = null;

            } else {
                sequence = seq;
            }
            mode = true;

        }

        public virtual int[] filter()
        {
            if (sequence == null || sequence.Length == 0)
            {
                int[] pNum = { p };
                return pNum;
            }

            if (mode)
            {
                return filterLarge();
            }

            return filterSmall();
        }

        public virtual int[] scramble(int[] seq)
        {
            if (seq == null || seq.Length == 0)
            {
                return null;
            }

            sequence = seq;
            if (mode)
            {
                return scrambleLarge();
            }
            return scrambleSmall();
        }

        //post: state will be changed
        public bool switchMode() {
            mode = !mode;
            return mode;
        }    

        public bool isLarge()
        {
            return mode;
        }
        protected bool isPrime(int n)
        {
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 ||
                    n % (i + 2) == 0)
                    return false;

            return true;
        }
        protected int nextPrime(int num)
        {
            int prime = num;
            bool found = false;

            while (!found)
            {
                prime++;

                if (isPrime(prime))
                    found = true;
            }

            return prime;
        }


        private int[] filterLarge()
        {
            ArrayList arList = new ArrayList();
            for(int i =0; i<sequence.Length; i++)
            {
                if( p < sequence[i])
                {
                    arList.Add(sequence[i]);
                }
            }
            int[] list = (int[])arList.ToArray(typeof(int));
            return list;
        }

        private int[] filterSmall()
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

        protected int[] scrambleLarge()
        {
            int[] scrambled = sequence;

            int j = sequence.Length-1;
            int tmp;
            for (int i = 0; i < sequence.Length / 2; i++)
            {
                if(scrambled[i] < scrambled[j])
                {
                    tmp = scrambled[i];
                    scrambled[i] = scrambled[j];
                    scrambled[j] = tmp;
                }
                j--;
            }

            return scrambled;
        }

        protected int[] scrambleSmall()
        {
            int[] scrambled = sequence;
            int j = sequence.Length - 1;
            int tmp;
            for (int i = 0; i < sequence.Length / 2; i++)
            {
                if (scrambled[i] > scrambled[j])
                {
                    tmp = scrambled[i];
                    scrambled[i] = scrambled[j];
                    scrambled[j] = tmp;
                }
                j--;
            }
            return scrambled;
        }
    }
}
//  Implementation Invariant
//
// If user passes in empty or null array, the encapsulated array will be null
// When attempting to use filter() with an null array it should return the encapsulated prime number in a array
// Clients may not pass in a negative number for the encapsulated prime number as prime numbers can't be negative
// If number passed in is not a prime number, the encapsulated 'p' will be updated to the next greatest prime number
//
// when scrambling:
// attempting to  call scramble with a null or empty array it will return null
// pairs are determined by: first element of the array will be paired with the last, 2nd will be paired with the 2nd to last, etc
// in the case of odd numbers, the middle element will be ignored as it has no pair.
//
// Clients can manually call switchModes() to switch object mode from large to small
