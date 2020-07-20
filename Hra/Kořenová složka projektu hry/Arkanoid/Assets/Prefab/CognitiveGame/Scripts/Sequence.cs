using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Schema;
using UnityEngine;
using Random = System.Random;
/**
 Trida dedi od ACogGame a zajistuje kognitivni minihru posloupnosti.
*/
public class Sequence : ACogGame
{

   
   /**
 * Abstraktni Funkce ktera vytvari ukolovou otazku a odpovedi na tlacitkach
 */

    protected override void fillParam()
    {
        for (int i = 0; i < CognitiveGameManager.countOfLevel; i++)
        {
            level[i] = false;
        }

        level[2] = true;
        level[3] = true;
        level[4] = true;
        level[5] = true;

        mainT = "Jsou čísla vzestupně?";
        leftT = "Ano";
        rightT = "Ne";
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
        return createSequenction(3, 1, 30);
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string fourthLevel()
    {
        return createSequenction(4, 1, 30);
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string fifthLevel()
    {
        return createSequenction(5, 20, 80);
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string sixthLevel()
    {
        return createSequenction(5, 50, 100);
    }
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
    protected override string seventhLevel()
    {
        return createSequenction(5, 70, 200);
    }
/**
*Funkce vytvari posloupnost 
*/
    private String createSequenction(int count, int min, int max)
    {
        int[] seq = new int[count];

        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            seq[i] = rand.Next(max-min) + min;
        }

        Array.Sort(seq);

       

        if (rand.Next(2) == 0)
        {
            
            seq = makeWrong(seq);
            while (!isWrong(seq))
                seq = makeWrong(seq);
            leftTrue = false;
            
        }
        else
        {
            leftTrue = true;
        }

        String answer = "";
        for (int i = 0; i < count; i++)
        {

            if (i != count - 1)
                answer = answer+seq[i] + " ";
            else
                answer = answer+seq[i];

        }
        return answer;
    }
 /**
  *Vytvari posloupnost s chybou
  * 
  */
    private int[] makeWrong(int[] seq)
    {
        int count = seq.Length;
        count = count / 2;

        Random rand = new Random();

        int c = rand.Next(count) + 1;

        int[] position = new int[c*2];
       

        for (int i = 0; i < position.Length; i++)
        {
            position[i] = -1;
        }

        for (int i = 0; i < position.Length; i++)
        {
            int pom = rand.Next(c*2);
            if (checkArrayPosition(position, pom))
                i--;
            else
            {
                position[i] = pom;
            }
        }

        for (int i = 0; i < position.Length-1; i++)
        {
            int pom = 0;
            pom = seq[position[i]];
            seq[position[i]] = seq[position[i + 1]];
            seq[position[i + 1]] = pom;
            

        }

        return seq;

    }

 /**
  *Funkce kontroluje, zdali vygenerovane cislo jiz v posloupnosti neni
  * 
  */
    private bool checkArrayPosition(int[] array,int index)
    {
        
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == index)
                return true;
        }

        return false;
    }
    
    /**
     * Zjistuje, zdalji je posloupnost spante
     */

    private bool isWrong(int[] array)
    {
        
        for (int i = 0; i < array.Length-1; i++)
        {
            if (array[i]>array[i+1])
                return true;
        }

        return false;
        
    }
}