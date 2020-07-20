using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
/**
 *  Trida dedi od ACogGame a zajistuje kognitivni minihru sudosti
 */
public class Even1 : ACogGame
{
  
    protected override void fillParam()
    {
        for (int i = 0; i < CognitiveGameManager.countOfLevel; i++)
        {
            level[i] = false;
        }
        level[0] = true;
        level[1] = true;
        level[2] = true;
        level[3] = true;

        mainT = "Je číslo sudé?";
        leftT = "Ano";
        rightT = "Ne";
    }

    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override string fifthLevel()
    {
        throw new NotImplementedException();
    }
    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override string sixthLevel()
    {
        throw new NotImplementedException();
    }
    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override string seventhLevel()
    {
        throw new NotImplementedException();
    }
    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override string firstLevel()
    {
        return createEvenSituation(10, 1);
    }
    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override String secondLevel()
    {
        return createEvenSituation(20, 10);
    }
    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override String thirthLevel()
    {
        return createEvenSituation(100, 50);
    }
    /**
   *Funkce pro vytvoreni minihry dane narocnosti
   */

    protected override String fourthLevel()
    {
        return createEvenSituation(1000, 100);
    }
    /**
   *Funkce pro vytvoreni minihry sudeho cisla
   */

    private String createEvenSituation(int max, int min)
    {
        Random rand = new Random();

        int tempMax = max - min;

        int ansr = rand.Next(tempMax) + min;


        if (ansr % 2 == 0)
            leftTrue = true;
        else
        {
            leftTrue = false;
        }


        return "" + ansr;
    }
}