// Author: Jeremiah Kalmus
// File: p1.cs
// Date: April 8th, 2019
// Version: 1.0.0

/* 
 * DESIGN CHOICES/ASSUMPTIONS:
 * I wanted to test random values to show that the factor class will work with variable information.
 * Also, I am not sure what values the client would input.
 * 
 * I assumed that the client would only use non-negative integers since this adds a layer of
 * complexity that is not needed. Especially since most people's first reactions are to think
 * of positive integers to test.
 * 
 * The random numbers generated for the factor numbers I limitted to values between 2 and 20.
 * Values 0 and 1 are not that useful since zero is a multiple of every number and every number
 * is a multiple of 1. No greater than 30 since it would make creating random values to 
 * test for multiples larger and this is unneccessary for testing.
 * 
 * For test input values, I used random numbers between 0 and 200. Test values do not need to be
 * larger than 200 since this gives an adequate range for sample values to test from.
 * 
 * I chose to display when a factor object has become inactive and display it to the screen because
 * I imagine that the user would like to be notified when the object has become inactive. 
 * 
 * I decided to add an accessor for the client to check whether or not an object is active or not.
 * This will allow the client to easily check to if they need to use reset without exposing private
 * data members.
 * ------------------------------------------------------------------------------------------------------
 * 
 * This driver class is to test the functionality of the factor.cs class 
 * and to make sure that it is working completely. 
 * 
 * Main will allocate an
 * array to hold 20 factor objects and it will call helper functions that
 * will test the factor objects that will be stored in the array. 
 * 
 * The array will be filled
 * in the Initialize_Objects function and will load the first 5 objects of the
 * array with factor values predetermined by the no argument constructor. The remaining
 * 15 objects will be initialized and given a value to be its factor value from a random number
 * generator. 
 * 
 * Test_Factor_Comparison will test every object in the array and pass in 10 values to
 * each object that will be compared to its stored factor value. The counter is displayed
 * to prove that it works in the appropriate situations. The first 5 values will be 
 * random and the last 5 values will be a random value but all the same value to show that
 * the count will refrain from incrementing when the objects are inactive.
 * 
 * Test_Reset will prove that the reset functionality works. It will take an example object, 
 * the 5th object in the array, and display its count and active status to then be reset. The
 * assumption here is that if reset works for the 5th object extensively, then it will work for
 * all other objects. The count and active status of the 5th object will then be displayed to prove it 
 * was reset. For extensive testing, the 5th object will be given a new factor number and be given multiples
 * of the factor. The last 5 values will all be the same value so the function will become inactive
 * and to again prove that the count will not increment when the object is inactive. The 5th object
 * will be reset again and the result of the reset will be shown.
 * 
 * In the Test_Reset function, the functionality of isActive will be tested by displaying true or
 * false whether the object is still active.
*/
using System;
class p1
{
    const int TESTOBJECTAMOUNT = 20;
    const int TESTEACHOBJECTAMOUNT = 5;
    const int DEFAULTFACTOR = 4;
    const int DUPLICATETESTVALUE = 16;
    static Random rand = new Random();
    static void Initialize_Objects(factor[] object_array)
    {
        Console.WriteLine("Initializing an array of 20 factor objects");
        Console.WriteLine();
        uint random;
        for (int i = 0; i < TESTOBJECTAMOUNT; i++)
        {
            random = (uint) rand.Next(2, 30);
            if (i <= 4)
            {
                object_array[i] = new factor();
                Console.WriteLine("Factor value of object " + (i+1) + " is: "
                    + DEFAULTFACTOR);
            }
            else
            {
                object_array[i] = new factor((int)random);
                Console.WriteLine("Factor value of object " + (i+1) + " is: " + random);
            }
        }
        Console.WriteLine();
    }
    static void Test_Factor_Comparison(factor[] object_array)
    {
        Console.WriteLine("Testing the comparison functionality and the object counter.");
        Console.WriteLine("Giving each object 5 random values to evaluate");
        Console.WriteLine();
        int random;
        for (int i = 0;i < TESTOBJECTAMOUNT; i++)
        {
            for (int j = 0; j < TESTEACHOBJECTAMOUNT; j++)
            {
                random = rand.Next(0, 200);
                if (!object_array[i].isActive)
                {
                    Console.WriteLine("This object is no longer active! " +
                        "Reset if you wish to test more values with this factor object.");
                }
                Console.WriteLine("Value inserted to compare with " +
                    "factor of object " + (i+1) + ": " + random);
                object_array[i].Factor_Comparison(random);
                Console.WriteLine("Multiple Count: " + object_array[i].Counter);
            }
            for (int j = 0; j < TESTEACHOBJECTAMOUNT; j++)
            {
                if (!object_array[i].isActive)
                {
                    Console.WriteLine("This object is no longer active! " +
                        "Reset if you wish to test more values with this factor object.");
                }
                Console.WriteLine("Value inserted to compare with " +
                    "factor of object " + (i + 1) + ": " + (DUPLICATETESTVALUE * i));
                object_array[i].Factor_Comparison((DUPLICATETESTVALUE * i));
                Console.WriteLine("Multiple Count: " + object_array[i].Counter);
            }
            Console.WriteLine();
        }
    }
    static void Test_Reset(factor[] object_array)
    {
        Console.WriteLine("Testing the reset and isActive functionality.");
        Console.WriteLine();
        Console.WriteLine("Object " + (DEFAULTFACTOR + 1) + " counter: " 
            + object_array[DEFAULTFACTOR].Counter);
        Console.WriteLine("Is the object still active?: " + object_array[DEFAULTFACTOR].isActive);
        Console.WriteLine("Resetting the object to its default state.");
        object_array[DEFAULTFACTOR].Reset();
        Console.WriteLine();
        Console.WriteLine("Giving object " + (DEFAULTFACTOR + 1) + " a new factor of: "
            + TESTOBJECTAMOUNT);
        Console.WriteLine("Object number " + (DEFAULTFACTOR + 1) + " counter: ");
        Console.WriteLine("Object " + (DEFAULTFACTOR + 1) + " counter: " 
            + object_array[DEFAULTFACTOR].Counter);
        Console.WriteLine("Is the object still active?: " + object_array[DEFAULTFACTOR].isActive);
        Console.WriteLine();

        for (int i = 0;i < TESTEACHOBJECTAMOUNT;i++)
        {
            object_array[DEFAULTFACTOR].Factor_Comparison(TESTOBJECTAMOUNT * i);
            Console.WriteLine("Value inserted to compare with " +
                 "factor of object " + (DEFAULTFACTOR + 1) + ": " + (TESTOBJECTAMOUNT * i));
            object_array[i].Factor_Comparison((DEFAULTFACTOR * i));
            Console.WriteLine("Object " + (DEFAULTFACTOR + 1) + " counter: " 
                + object_array[DEFAULTFACTOR].Counter);
            Console.WriteLine("Is the object still active?: " + object_array[DEFAULTFACTOR].isActive);
        }
        for (int i = 0;i < TESTEACHOBJECTAMOUNT; i++)
        {
            if (!object_array[DEFAULTFACTOR].isActive)
            {
                Console.WriteLine("This object is no longer active! " +
                    "Reset if you wish to test more values with this factor object.");
            }
            object_array[DEFAULTFACTOR].Factor_Comparison(DEFAULTFACTOR);
            Console.WriteLine("Value inserted to compare with " +
                     "factor of object " + (DEFAULTFACTOR + 1) + ": " + (TESTOBJECTAMOUNT));
            Console.WriteLine("Object " + (DEFAULTFACTOR + 1) + " counter: " 
                + object_array[DEFAULTFACTOR].Counter);
            Console.WriteLine("Is the object still active?: " + object_array[DEFAULTFACTOR].isActive);
        }
        Console.WriteLine();
        Console.WriteLine("Resetting the object to its default state.");
        object_array[DEFAULTFACTOR].Reset();
        Console.WriteLine("Object number " + (DEFAULTFACTOR + 1) + " counter: ");
        Console.WriteLine("Multiple Count: " + object_array[DEFAULTFACTOR].Counter);
        Console.WriteLine("Is the object still active?: " + object_array[DEFAULTFACTOR].isActive);
        Console.WriteLine();

    }
    static void Main(string[] args)
    {
        factor[] object_array = new factor[TESTOBJECTAMOUNT];
        Initialize_Objects(object_array);
        Test_Factor_Comparison(object_array);
        Test_Reset(object_array);
        Console.WriteLine("Press enter to end program...");
        Console.ReadLine();
    }
}


