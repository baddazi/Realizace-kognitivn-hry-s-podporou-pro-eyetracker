using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;
/**
 *Trida dedi od ACogGame a zajistuje pocitaci kognitivni minnihru, kde hrac musi tlacitkem urcit ANO/NE spravny vysledek. 
 * 
 */
public class Calc1 : ACogGame
{
    /**
  * Abstraktni Funkce ktera vytvari ukolovou otazku a odpovedi na tlacitkach
  */

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
    /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
    
    protected override String fourthLevel()
    {
        Random rand = new Random();
        int r = rand.Next(3);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(100,50 , 25);
                break;
            case 1: res =CreateMathDeleno(100, 10, 3);
                break;
            case 2: res =CreateMathKrat(10, 5, 3);
                break;
            
        }
        
        return res;
    }
    /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
    protected override string fifthLevel()
    {
        Random rand = new Random();
        int r = rand.Next(3);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(200,100 , 50);
                break;
            case 1: res =CreateMathDeleno(100, 20, 6);
                break;
            case 2: res =CreateMathKrat(15, 7, 5);
                break;
            
        }
        
        return res;
    }
    /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
    protected override string sixthLevel()
    {
        Random rand = new Random();
        int r = rand.Next(3);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(300,150 , 75);
                break;
            case 1: res =CreateMathDeleno(100, 30, 8);
                break;
            case 2: res =CreateMathKrat(20, 10, 7);
                break;
            
        }
        
        return res;
    }
    /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
    protected override string seventhLevel()
    {
        Random rand = new Random();
        int r = rand.Next(3);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(400,200 , 100);
                break;
            case 1: res =CreateMathDeleno(100, 40, 24);
                break;
            case 2: res =CreateMathKrat(30, 15, 12);
                break;
            
        }
        
        return res;
    }
    /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
    protected override String secondLevel()
    {
        return createMathPlusMinus(20, 10, 7);
    }

    /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
     protected override String firstLevel()
    {
        return createMathPlusMinus(10, 6, 3);
    }
     /**
*Funkce pro vytvoreni minihry dane narocnosti
* 
*/
     protected  override String thirthLevel()
    {
        return createMathPlusMinus(50, 20, 13);
    }

     /**
 *Vytvari minihru nasobeni
 * 
 */
    private String CreateMathKrat(int aValue, int bValue, int mistakeValue)
    {
        Random rand = new Random();

        int a = rand.Next(aValue)+1;
        
        

        int b = rand.Next(bValue)+1;

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
/**
 *Vytvari minihru deleno
 * 
 */
    private String CreateMathDeleno(int aValue, int bValue, int mistakeValue)
    {

        Random rand = new Random();

        int a = rand.Next(aValue)+1;

        int b = rand.Next(bValue)+1;

        int c;
        char sign = ':';

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

/**
 *Vytvari minihru plus a minus
 * 
 */
    private String createMathPlusMinus(int aValue, int bValue, int mistakeValue)
    {
        Random rand = new Random();

        int a = rand.Next(aValue)+1+bValue;
        
      

        int b = rand.Next(bValue)+1;
        
       

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
