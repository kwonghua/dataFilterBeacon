// Kevin Wong-Hua
// p3.cs
// used for testing dataFilter, dataCut, dataMod objects

//
// Testing used :
// creating a Heterogeneous dataFilter obj collection of random size from 1 - 11
// randomly adding dataFilter, dataMod, and dataCut objects into the collection
// objects are initialize with random integers(-15 - 50) and random sequences of random sizes (0 - 10) of the random integers (-15, 50)
// test filter() and scramble() methods in the different large and small states
// test scramble(seq) with different inputs (random arrays, null, empty)
// displays all outputs from filter() and scramble() to the screen
// filters after invalid scramble calls should still display something as scramble with null and empty should not update the sequence

/**
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _32_P3
{
    public class P3
    {

       static void Main(string[] args)
        {

            int[] beaconSeq = { 60, 90 };
            int[] initial = { 0 };
            int[] filterSeq = { 16, 25, 30, 45, 60, 55, 78, 96 };

            beacon beaconTest = new beacon(beaconSeq);
            dataFilter filterTest = new dataFilter(initial, 37);
            dataFilterBeacon dfbTest = new dataFilterBeacon(filterTest, beaconTest);

            int[] expectedOutcome = { 78, 96 };
            dfbTest.switchMode();
            int[] largeOutCome = dfbTest.scramble(filterSeq);

            for (int i = 0; i < largeOutCome.Length; i++)
            {
                Console.Write(largeOutCome[i]);
                Console.Write(" ");
            }
         





            /**
            int size = (new Random()).Next(1,11);
            dataFilter[] filterList = new dataFilter[size];

            Console.WriteLine("*** Heterogeneous dataFilter obj collection of size: " + size + " created ***");
            Console.WriteLine("Creating random dataFilter, dataMod, and dataCut objects");
            Console.WriteLine("Filling objects with random values from 0 - 50 with random sequences of size 0 - 10");
            Console.WriteLine();

            initialize(filterList);

            Console.WriteLine("**************************************** Testing filter() method in large mode ***********************************************");
            Console.WriteLine();

            filter(filterList);

            switchMode(filterList);

            Console.WriteLine("**************************************** Testing filter() method in small mode****************************************");
            Console.WriteLine();

            filter(filterList);

            Console.WriteLine("**************************************** Testing scramble() method in large mode with random sequence **************************************** ");
            Console.WriteLine();
            switchMode(filterList);

            scramble(filterList);


            Console.WriteLine("****************************************  Testing scramble() method in small mode with random sequence ****************************************");
            Console.WriteLine();
            switchMode(filterList);

            scramble(filterList);

            Console.WriteLine("**************************************** Testing scramble() method with empty sequence ****************************************");
            Console.WriteLine();
            scrambleEmpty(filterList);

            Console.WriteLine("**************************************** Testing scramble() method with null sequence ****************************************");
            Console.WriteLine();
            scrambleEmpty(filterList);

            Console.WriteLine("**************************************** Testing filter() method after invalid scramble calls ****************************************");
            Console.WriteLine();
            filter(filterList);
   
        }
        static void scrambleNull(dataFilter[] filterList)
        {
            int[] seq = null;
            for (int i = 0; i < filterList.Length; i++)
            {

                if (filterList[i].GetType() == typeof(dataFilter))
                {
                    Console.Write("dataFilter ");
                }
                else if (filterList[i].GetType() == typeof(dataMod))
                {
                    Console.Write("dataMod ");
                }
                else
                {
                    Console.Write("dataCut ");
                }

                Console.Write(" obj scrambling with sequence");
                printMyArray(seq);
                Console.WriteLine();
                Console.WriteLine("returns");

                int[] result = filterList[i].scramble(seq);
                printMyArray(result);
                Console.WriteLine();
                Console.WriteLine();

            }
        }
        static void scrambleEmpty(dataFilter[] filterList)
        {
            int[] seq = new int[0];
            for (int i = 0; i < filterList.Length; i++)
            {

                if (filterList[i].GetType() == typeof(dataFilter))
                {
                    Console.Write("dataFilter ");
                }
                else if (filterList[i].GetType() == typeof(dataMod))
                {
                    Console.Write("dataMod ");
                }
                else
                {
                    Console.Write("dataCut ");
                }

                Console.Write(" obj scrambling with sequence");
                printMyArray(seq);
                Console.WriteLine();
                Console.WriteLine("returns");

                int[] result = filterList[i].scramble(seq);
                printMyArray(result);
                Console.WriteLine();
                Console.WriteLine();

            }
        }
        static void switchMode(dataFilter[] filterList)
        {
            for(int i = 0; i < filterList.Length; i++)
            {
                filterList[i].switchMode();
            }
        }

        static void scramble(dataFilter[] filterList)
        {
            for (int i = 0; i < filterList.Length; i++)
            {
                int[] randSeq = randomSeq();

                if (filterList[i].GetType() == typeof(dataFilter))
                {
                    Console.Write("dataFilter ");
                }
                else if (filterList[i].GetType() == typeof(dataMod))
                {
                    Console.Write("dataMod ");
                }
                else
                {
                    Console.Write("dataCut ");
                }

                Console.Write(" obj scrambling with sequence");
                printMyArray(randSeq);
                Console.WriteLine();
                Console.WriteLine("returns" );

                int[] result = filterList[i].scramble(randSeq);
                printMyArray(result);
                Console.WriteLine();
                Console.WriteLine();

            }
        }
        static void filter(dataFilter[] filterList)
        {
            for(int i = 0; i<filterList.Length; i++)
            {
                int[] result = filterList[i].filter();

                if(filterList[i].GetType() == typeof(dataFilter)){
                    Console.Write("dataFilter ");
                }
                else if (filterList[i].GetType() == typeof(dataMod))
                {
                    Console.Write("dataMod ");
                }
                else
                {
                    Console.Write("dataCut ");
                }

                Console.Write("obj filter returns ");
                printMyArray(result);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void initialize(dataFilter[] list)
        {
            Random rnd = new Random();
            int choice = new Random().Next(1, 4);

            for(int i = 0; i < list.Length; i++)
            {
                int value = randomInt();
                int[] randSeq = randomSeq();

                if(choice == 1)
                {
                    list[i] = new dataFilter(randSeq, value);
                    Console.WriteLine("dataFilter Obj created with value of " + value + " passed in");
                }
                else if (choice == 2)
                {
                    list[i] = new dataMod(randSeq, value);
                    Console.WriteLine("dataMod Obj created with value of " + value + " passed in");
                }
                else
                {
                    list[i] = new dataCut(randSeq, value);
                    Console.WriteLine("dataCut Obj created with value of " + value + " passed in");
                }


               printMyArray(randSeq);
               Console.WriteLine();
               Console.WriteLine();

               choice = new Random().Next(1, 4);
            }
        }
        static int[] randomSeq()
        {
            int size = (new Random()).Next(11);
            int[] list = new int[size];
            for (int i = 0; i < size; i++)
            {
                list[i] = randomInt();
            }
            return list;
        }

        static int randomInt()
        {
            int rnd = new Random().Next(-15,51);
            return rnd;
        }

        static void printMyArray(int[] list)
        {
            Console.Write("[");
            if (list == null)
            { }
            else
            {
                for (int i = 0; i < list.Length; i++)
                {
                    Console.Write(list[i]);
                    if (i != list.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
            }
            Console.Write("]");
        }
    }
}
**/