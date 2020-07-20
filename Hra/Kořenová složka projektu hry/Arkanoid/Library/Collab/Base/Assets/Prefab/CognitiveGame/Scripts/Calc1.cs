using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class Calc1 : ACogGame
{
    // Start is called before the first frame update

    protected override void fillParam()
    {
        for (int i = 0; i < CognitiveGameManager.countOfLevel; i++)
        {
            level[i] = true;

        }

        mainT = "Je příklad správně?";
        leftT = "Ano";
        rightT = "Ne";

       
        
    }
    
    protected override String fourthLevel()
    {
        Random rand = new Random();
        int r = rand.Next(3);
        String res = "ChybaFourth";
        switch (r)
        {
            case 0: res =createMathPlusMinus(251,126 , 63);
                break;
            case 1: res =CreateMathDeleno(31, 11, 3);
                break;
            case 2: res =CreateMathKrat(10, 5, 3);
                break;
            
        }
        
        return res;
    }

    protected override string fifthLevel()
    {
        throw new NotImplementedException();
    }

    protected override string sixthLevel()
    {
        throw new NotImplementedException();
    }

    protected override string seventhLevel()
    {
        throw new NotImplementedException();
    }

    protected override String secondLevel()
    {
        return createMathPlusMinus(51, 26, 13);
    }


     protected override String firstLevel()
    {
        return createMathPlusMinus(11, 6, 3);
    }

     protected  override String thirthLevel()
    {
        return createMathPlusMinus(101, 51, 25);
    }

    private String CreateMathKrat(int aValue, int bValue, int mistakeValue)
    {
        Random rand = new Random();

        int a = rand.Next(aValue);

        int b = rand.Next(bValue);

        int c;
        char sign;


        c = a * b;
        sign = '*';


        int d = 0;

        if (rand.Next(2) == 0)
        {
            d = c;
            leftTrue = true;
        }
        else
        {
            int mistake = rand.Next(mistakeValue) + 1;

            d = c + mistake;
            leftTrue = false;
        }


        return a + " " + sign + " " + b + " = " + d;
    }

    private String CreateMathDeleno(int aValue, int bValue, int mistakeValue)
    {

        Random rand = new Random();

        int a = rand.Next(aValue);

        int b = rand.Next(bValue);

        int c;
        char sign = '/';

        int d = 0;
        if (a % b == 0)
        {
            d = a / b;
            
            leftTrue = true;

        }
        else
        {
            c = a / b;
            d = c + rand.Next(mistakeValue) + 1;
            leftTrue = false;

        }


        return a + " " + sign + " " + b + " = " + d;
        
    }


    private String createMathPlusMinus(int aValue, int bValue, int mistakeValue)
    {
        Random rand = new Random();

        int a = rand.Next(aValue);

        int b = rand.Next(bValue);

        int c;
        char sign;
        if (rand.Next(2) == 0)
        {
            c = a + b;
            sign = '+';
        }
        else
        {
            c = a - b;
            sign = '-';
        }


        int d = 0;

        if (rand.Next(2) == 0)
        {
            d = c;
            leftTrue = true;
        }
        else
        {
            int mistake = rand.Next(mistakeValue) + 1;

            d = c + mistake;
            leftTrue = false;
        }


        return a + " " + sign + " " + b + " = " + d;
    }
}
