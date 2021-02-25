// Kevin Wong-Hua
// dataMod.cs

// Class/public Invariant
//
// dataMod is an dataFilter and operates as one such that it will encapsulate a non-negative prime number with a int array sequence
// dataMod is intially set to 'Large' mode
// if the given number is not a prime number, it will be updated to the nearest greatest prime number 
// if given a negative number it will be updated to a default value
//
// filter() 
// 1) returns ‘p’ if the internal sequence is null
// 2) Otherwise, returns,
//    1) when in ‘large’ mode, all integers will be incremented
//    2) when in ‘small’ mode, all integers will be decremented
// 
// scramble(seq)
// 1) updates the encapsulated sequence with seq, if not null or empty
// 2) replaces all prime numbers with '2'
// 3) returns a reordered integer sequence, as follows
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
using System.Text;

namespace _32_P3
{
    public class dataMod : dataFilter
    {
        const int replacePrimeWith = 2;


        
        public dataMod(int[] seq, int n) : base( seq, n)
        {

        }


        public override int[] filter()
        {

            if (sequence == null || sequence.Length == 0)
            {
                int[] pNum = { p };
                return pNum;
            }

            if (mode)
                return incrementSeq();

            return decrementSeq();
        }

        public override int[] scramble(int[] seq)
        {

            if (seq == null || seq.Length == 0)
            {
                return null;
            }
            sequence = seq;
                
            replacePrimeNumbers();

            if (mode)
            {
                return scrambleLarge();
            }
            return scrambleSmall();
        }


        private int[] incrementSeq()
        {
            for(int i = 0; i < sequence.Length; i++)
            {
                sequence[i]++;
            }
            return sequence;
        }

        private int[] decrementSeq()
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i]--;
            }
            return sequence;
        }

        private void replacePrimeNumbers()
        {
            for(int i = 0; i < sequence.Length; i++)
            {
                if (isPrime(sequence[i]))
                {
                    sequence[i] = replacePrimeWith;
                }
            }
        }
    }
}
//  Implementation Invariant
//
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
// prime numbers are swapped with the default value int replacePrimeWith = 2
//
// Clients can manually call switchModes() to switch object mode from large to small
