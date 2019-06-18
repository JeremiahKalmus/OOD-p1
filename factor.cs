// Author: Jeremiah Kalmus
// File: factor.cs
// Date: April 8th, 2019
// Version: 1.0.0

/*
 * I created an overloaded constructor and a no argument constructor to cover the cases when the 
 * user inputs a value to check if it is a multiple of the factor value and if they do not enter
 * a value. 
 * 
 * Counter and isActive are accessors since they only perform the task of displaying information
 * to the client.
 * 
 * Reset is a method since the client does not need to read or write to it and it needs to perform
 * reset values to their default state. The client does not need to know what it is resetting, only
 * that it has been done.
 * 
 * Factor_Comparison will take a value from the client to compare against the stored factor value. If
 * the object is still active it will run the comparison, otherwise, nothing will happen. If the value
 * entered is a multiple of the factor number and it is not equal to the previous value entered by the
 * client, the counter will increment. If the current value is equal to the previous one entered, the
 * object will become inactive.
 */

using System;
class factor
{
    private const int DEFAULTFACTOR = 4;
    private int factor_number;
    private bool active;
    private int multiple_counter;
    private int previous_input;
    
    public factor()
    {
        factor_number = DEFAULTFACTOR;
        active = true;
        multiple_counter = 0;
        previous_input = -1;
    }

    public factor(int user_input)
    {
        factor_number = user_input;
        active = true;
        multiple_counter = 0;
        previous_input = -1;
    }

    public int Counter
    {
        get
        {
            return multiple_counter;
        }
    }
    public bool isActive
    {
        get
        {
            return active;
        }
    }
    public void Factor_Comparison(int comparison_value)
    {
        if (active)
        {
            if ((comparison_value % factor_number == 0) && (previous_input != comparison_value))
            {
                multiple_counter++;
            }
            else if (previous_input == comparison_value)
            {
                active = false;
            }
            previous_input = comparison_value;
        }
    }
    public void Reset()
    {
        multiple_counter = 0;
        previous_input = -1;
        factor_number = -1;
        active = true;
    }
}

