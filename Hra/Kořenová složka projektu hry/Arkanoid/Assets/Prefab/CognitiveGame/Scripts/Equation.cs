using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = System.Random;
/**
 *  Trida dedi od ACogGame a zajistuje kognitivni minihru rovnice
 */
public class Equation : ACogGame
{
    
    /**
   * Vytvori otazku minihry.
   */

    protected override void fillParam()
    {
        for (int i = 0; i < CognitiveGameManager.countOfLevel; i++)
        {
            level[i] = false;
        }


        level[4] = true;
        level[5] = true;
        level[6] = true;

        mainT = "Kolik je x?";
             
    }


/**
*Funkce pro vytvoreni minihry dane narocnosti
*/

    protected override string firstLevel()
    {
        throw new System.NotImplementedException();
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string secondLevel()
    {
        throw new System.NotImplementedException();
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string thirthLevel()
    {
        throw new System.NotImplementedException();
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string fourthLevel()
    {
        throw new System.NotImplementedException();
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string fifthLevel()
    {
        return createEquationPlusMinus(20, 100);
     
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string sixthLevel()
    {
        Random rand = new Random();
        if (rand.Next(2) == 0)
        {
            return createEquationPlusMinus(20, 100);
        }
        return createEquationKrat(5, 10);
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string seventhLevel()
    {
        
        Random rand = new Random();
        if (rand.Next(2) == 0)
        {
            return createEquationPlusMinus(100, 1000);
        }
        return createEquationKrat(5, 20);
    }
       
    
/**
 * Vytvori rovnicicse scitanim a odcitanim
 */
    private String createEquationPlusMinus(int min, int max)
    {

        Random rand = new Random();

        int a = rand.Next(max - min) + min;

        int b = rand.Next(min);

        int c;

        char zn;

        if (rand.Next(2) == 0)
        {
            zn = '+';
            c = a + b;
        }
        else
        {
            zn = '-';
            c = a - b;
        }


        return createAnswer(a, b, c, zn, min, max);
    }
/**
 * Vytvori rovnici nasobenim
 */
    private String createEquationKrat(int min, int max)
    {

        Random rand = new Random();

        int a = rand.Next(max - min) + min+1;

        int b = rand.Next(min)+1;

        char zn = '*';
        int c = a * b;

        
        return createAnswer(a, b, c, zn, min, max);

    }
/**
 * Vytvori odpoved pro talcitka
 */
    private String createAnswer(int a, int b, int c, char zn, int min,int max)
    {
        Random rand = new Random();
        String answer;
        if (rand.Next(2) == 0)
        {
            answer = a + " " + zn + " x = " + c;

            if (rand.Next(2) == 0)
            {
                leftT = b + "";

                int f = rand.Next(min);
                while (f == b)
                {
                    f = rand.Next(min);
                }

                rightT = f + "";
                leftTrue = true;
            }
            else
            {
                rightT = b + "";

                int f = rand.Next(max);
                while (f == b)
                {
                    f = rand.Next(max);
                }

                leftT = f + "";
                leftTrue = false;

            }

        }
        else
        {

            answer = "x " + zn + " " + b + " = " + c;

            if (rand.Next(2) == 0)
            {
                leftT = a + "";

                int f = rand.Next(min);
                while (f == a)
                {
                    f = rand.Next(min);
                }

                rightT = f + "";
                leftTrue = true;
            }
            else
            {
                rightT = a + "";

                int f = rand.Next(max);
                while (f == a)
                {
                    f = rand.Next(max);
                }

                leftT = f + "";
                leftTrue = false;

            }

        }

        return answer;

    }
    
        
    



}
