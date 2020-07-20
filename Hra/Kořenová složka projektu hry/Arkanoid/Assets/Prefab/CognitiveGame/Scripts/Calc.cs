using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

/**
 *Trida dedi od ACogGame a zajistuje pocitaci kognitivni minnihru, kde hrac musi tlacitkem urcit spravny vysledek. 
 * 
 */
public class Calc  : ACogGame
{ 
/**
 * Abstraktni Funkce ktera vytvari ukolovou otazku
 */

    protected override void fillParam()
    {
        for (int i = 0; i < CognitiveGameManager.countOfLevel; i++)
        {
            level[i] = true;

        }

        mainT = "Jaký je výsledek?";
        
    }
 /**
  *Trida pro vytvoreni minihry dane narocnosti
  * 
  */
    protected override String fourthLevel()
    {
        Random rand = new Random();
        int r = rand.Next(2);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(100,50 , 25);
                break;
            case 1: res =CreateMathKrat(10, 5, 3);
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
        int r = rand.Next(2);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(200,100 , 50);
                break;
            case 1: res =CreateMathKrat(15, 7, 5);
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
        int r = rand.Next(2);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(300,150 , 75);
                break;
            case 1: res =CreateMathKrat(20, 10, 7);
                break;
            
        }
        
        return res;
    }
    /**
     *Funkcepro vytvoreni minihry dane narocnosti
     * 
     */
    protected override string seventhLevel()
    {
        Random rand = new Random();
        int r = rand.Next(2);
        String res = "";
        switch (r)
        {
            case 0: res =createMathPlusMinus(400,200 , 100);
                break;
            case 1: res =CreateMathKrat(30, 15, 12);
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


        int mistake = rand.Next(mistakeValue) + 1;
       

        if (rand.Next(2) == 0)
        {
            
            leftT = c+"";
            rightT = c+mistake+"";
            
            leftTrue = true;
            
           
        }
        else
        {
            rightT = c+"";
            leftT = c+mistake+"";
            
            leftTrue = false;
        }


        return a + " " + sign+" " + b + " = ?";
    }

    
    /**
     *Vytvari scitaci a odcitaci minihru
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
        int mistake = rand.Next(mistakeValue) + 1;

        if (rand.Next(2) == 0)
        {
            
            leftT = c+"";
            rightT = c+mistake+"";
            
            leftTrue = true;
           
        }
        else
        {
           

            rightT = c+"";
            leftT = c+mistake+"";
            
            leftTrue = false;
        }


        return a + " " + sign+" " + b + " = ?";
    }
}
