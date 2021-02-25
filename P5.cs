// Kevin Wong-Hua
// P5.cs
// used for testing dataFilterBeacon object

//
// Testing used :
// Creating a dataFilterBeacon obj collection of random size from 3 - 11
// Initialize collection with random different types of beacons and dataFilters 
// objects are initialize with random integers(-15 - 50) and random sequences of random sizes (0 - 10) of the random integers (-15, 50)
// test getSignal() method
// test filter() and scramble() methods in the different large and small states
// test scramble(seq) with different inputs (random arrays)
// displays all outputs from filter() and scramble() to the screen

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _32_P3
{
    public class P5
    {
        static void Main(string[] args)
        {
            int size = (new Random()).Next(3, 11);
            dataFilterBeacon[] dfbList = new dataFilterBeacon[size];

            Console.WriteLine("*** dataFilterBeacon obj collection of size: " + size + " created ***");
            Console.WriteLine("*** initializing collection with dataFilter and beacon types ***");
            Console.WriteLine();

            initialize(dfbList);

            Console.WriteLine();
            Console.WriteLine("*** Testing getSignal() method ***");
            getSignal(dfbList);

            Console.WriteLine();
            Console.WriteLine("*** Testing filter() in large mode ***");
            filter(dfbList);

            Console.WriteLine();
            switchMode(dfbList);
            Console.WriteLine("*** Testing filter() in small mode ***");
            filter(dfbList);

            Console.WriteLine();
            Console.WriteLine("*** Testing scramble() method in large mode with random sequence *** ");
            switchMode(dfbList);

            scramble(dfbList);

            Console.WriteLine();
            Console.WriteLine("*** Testing scramble() method in small mode with random sequence *** ");
            switchMode(dfbList);

            scramble(dfbList);
        }
        static void scramble(dataFilterBeacon[] list){

            for (int i = 0; i < list.Length; i++)
            {
                int[] randSeq = randomSeq();
                Console.Write("element[" + i + "] scrambling with ");
                printMyArray(randSeq);
                Console.Write(" returns: ");
                printMyArray(list[i].scramble(randSeq));
                Console.WriteLine();
            }

        }
        static void switchMode(dataFilterBeacon[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i].switchMode();
            } 
        }
        static void filter(dataFilterBeacon[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                Console.Write("element[" + i + "] returns : ");
                printMyArray(list[i].filter());
                Console.WriteLine();
            }
        }
        static void getSignal(dataFilterBeacon[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write("element[" + i + "] returns : ");
                Console.Write(list[i].getSignal());
                Console.WriteLine();
            }
        }
        static void initialize(dataFilterBeacon[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                Console.Write("element[" + i + "]: ");
                list[i] = new dataFilterBeacon(giveMeADataFilter(), giveMeABeacon());
                Console.WriteLine();
            }

        }
        static void switchMode(dataFilter[] filterList)
        {
            for (int i = 0; i < filterList.Length; i++)
            {
                filterList[i].switchMode();
            }
        }
        static dataFilter giveMeADataFilter()
        {
            Random rnd = new Random();
            int choice = new Random().Next(1, 4);
            int value = randomInt();
            int[] randSeq = randomSeq();

            dataFilter tmp;

            if (choice == 1)
            {
                tmp = new dataFilter(randSeq, value);
                Console.Write("dataFilter ");
            }
            else if (choice == 2)
            {
                tmp = new dataMod(randSeq, value);
                Console.Write("dataMod ");
            }
            else
            {
                tmp = new dataCut(randSeq, value);
                Console.Write("dataCut ");
            }

            printMyArray(randSeq);
            Console.Write(" Value: " + value);
            Console.WriteLine();
            return tmp;

        }
        static beacon giveMeABeacon()
        {
            Random rnd = new Random();
            int choice = new Random().Next(1, 4);

            int[] randSeq = randomSeq();

            beacon tmp;

            if (choice == 1)
            {
                tmp = new beacon(randSeq);
                Console.Write("            beacon ");
            }
            else if (choice == 2)
            {
                tmp = new quirkyBeacon(randSeq);
                Console.Write("            quirkyBeacon ");
            }
            else
            {
                tmp = new strobeBeacon(randSeq);
                Console.Write("            strobeBeacon ");
            }

            printMyArray(randSeq);
            Console.WriteLine();
            return tmp;
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
            int rnd = new Random().Next(-15, 51);
            return rnd;
        }
        static void printMyArray(int[] list)
        {
            Console.Write("{");
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
            Console.Write("}");
        }
    }
}
