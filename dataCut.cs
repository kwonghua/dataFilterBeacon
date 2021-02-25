// Kevin Wong-Hua
// dataCut.cs

// Class/public Invariant
//
// dataCut is an dataFilter and operates as one such that it will encapsulate a non-negative prime number with a int array sequence
// dataCut is intially set to 'Large' mode
// if the given number is not a prime number, it will be updated to the nearest greatest prime number 
// if given a negative number it will be updated to a default value
//
// filter() 
// 1) returns ‘p’ if the internal sequence is null
// 2) Otherwise, returns,
//    1) when in ‘large’ mode, removes the largest number from sequence
//    2) when in ‘small’ mode, removes the smallest number from sequence
//    3) in the case of duplicates, the first occurrence will be removed
//
// scramble(seq)
// 1) updates the encapsulated sequence with seq, if not null or empty
// 2) removes all numbers that occurred in the previous scramble request before scrambling
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
using System.Collections;
using System.Linq;

namespace _32_P3
{
    // each dataCut object is-a dataFilter and thus operates like an dataFilter object, except that:
    // filter() removes the maximum number when in ‘large’ mode; otherwise, removes the minimum
    // scramble(seq) removes any number that occurred in the previous scramble request before scrambling
    public class dataCut : dataFilter
    {

        int[] prevScramble;


        public dataCut(int[] seq, int n) : base(seq, n)
        {
            prevScramble = null;

        }

        public override int[] filter()
        {
            if (sequence == null)
            {
                int[] pNum = { checked((int)p) };
                return pNum;
            }

            if (mode)
            {
                return removeMax();
            }

            return removeMin();
        }

        public override int[] scramble(int[] seq)
        {
            if(seq == null || seq.Length == 0)
            {
                return null;
            }
            if(prevScramble == null || prevScramble.Length == 0)
            {
                sequence = seq;
            }
            else
            {
                ArrayList arList = new ArrayList();
                for (int i = 0; i < seq.Length; i++)
                {
                    for(int j=0; j<prevScramble.Length;j++)
                    {
                        if(seq[i] != prevScramble[j] && j== prevScramble.Length-1)
                        {
                            arList.Add(seq[i]);
                        }

                        if(seq[i] == prevScramble[j])
                        {
                            break;
                        }
                    }
                }
                int[] list = (int[])arList.ToArray(typeof(int));
                sequence = list;
            }

            prevScramble = seq;
            if (mode)
            {
                return scrambleLarge();
            }
            return scrambleSmall();
        }

        private int[] removeMax()
        {
            int maxValue = sequence.Max();
            int maxIndex = sequence.ToList().IndexOf(maxValue);

            int[] newArray = new int[sequence.Length - 1];
            int j = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (i != maxIndex)
                {
                    newArray[j] = sequence[i];
                    j++;
                }
            }
            return newArray;
        }

        private int[] removeMin()
        {
            int maxValue = sequence.Min();
            int maxIndex = sequence.ToList().IndexOf(maxValue);

            int[] newArray = new int[sequence.Length - 1];
            int j = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (i != maxIndex)
                {
                    newArray[j] = sequence[i];
                    j++;
                }
            }
            return newArray;
        }
    }
}
//  Implementation Invariant
//
// If user passes in empty or null array, the encapsulated array will be null
// When attempting to use filter() with an null array it should return the encapsulated prime number in a array
// Clients may not pass in a negative number for the encapsulated prime number as prime numbers can't be negative
// If number passed in is not a prime number, the encapsulated 'p' will be updated to the next greatest prime number
// When using filter and removing a maximum or minimum, the first occurrence will be removed 
//
// when scrambling:
// attempting to  call scramble with a null or empty array it will return null
// pairs are determined by: first element of the array will be paired with the last, 2nd will be paired with the 2nd to last, etc
// in the case of odd numbers, the middle element will be ignored as it has no pair.
// if a prevScramble sequence exists calling scramble(seq) will remove all duplicates from the prevScramble before scrambling 
// prevScramble is initially null
// 
// Clients can manually call switchModes() to switch object mode from large to small
