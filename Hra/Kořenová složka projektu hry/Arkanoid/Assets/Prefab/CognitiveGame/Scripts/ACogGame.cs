using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
/**
 *Abstrakti trida slouzici k vytvareni kognitivnich miniher. Zajistuje Spolecnou funkcionalitu pro vsechny minihry.
 * 
 */
public abstract class ACogGame 
{
    protected String chyba = "Chyba";

    protected bool[] level = new bool[CognitiveGameManager.countOfLevel];

    protected String mainT = "Nevyplneno";
    protected String leftT = "Nevyplneno";
    protected String rightT = "Nevyplneno";


    protected TextMeshProUGUI left;
    protected TextMeshProUGUI right;
    protected TextMeshProUGUI mainText;
    protected TextMeshProUGUI question;
    protected bool leftTrue = true;
     /**
      *Funkce zjisti zdali konkretni minihra ma na dane obtiznosti definovanou minhru
      * 
      */
    
    public bool isLevel(int lev)
    {
        fillParam();
        return level[lev - 1];
    }
    
    
    /**
     * Trida ktera nuti potomky vyplnit veskere potrebne parametry
     */
    protected abstract void fillParam();
 /**
  *Funcke zajistuje vytvoreni konkretni minihry vyplnenim informaci o dane hre
  * 
  */
    public void createGame(int lev)
    {
        mainText.SetText(mainT);
        question.SetText(taskByDificulty(lev));
        left.SetText(leftT);
        right.SetText(rightT);
    }
 /**
  *Nastaveni a ulozeni konkretnich textovych polich urcenych k pozdejsimu vystupu
  * 
  */
    public void setSuff(TextMeshProUGUI left, TextMeshProUGUI right, TextMeshProUGUI mainText, TextMeshProUGUI question)
    {
        this.left = left;
        this.right = right;
        this.mainText = mainText;
        this.question = question;
        
        this.left.color=Color.black;
        this.right.color=Color.black;
        
        this.mainText.color=Color.white;
        this.question.color=Color.red;

    }
 
    
    /**
     * Funkce vytvari ulohu podle narocnosti
     */

    protected String taskByDificulty(int lev)
    {
        String answer = "Chyba";


        switch (lev)
        {
            case 1: return firstLevel();
            case 2: return secondLevel();
            case 3: return thirthLevel();
            case 4: return fourthLevel();
            case 5: return fifthLevel();
            case 6: return sixthLevel();
            case 7: return seventhLevel();
        }


        return chyba;
    }
    
    /**
     *Abstraktni funkce nutne od potomku k implementaci
     * 
     */

    protected abstract String firstLevel();


    protected abstract String secondLevel();


    protected abstract String thirthLevel();


    protected abstract String fourthLevel();


    protected abstract String fifthLevel();


    protected abstract String sixthLevel();


    protected abstract String seventhLevel();
   
     /**
      *Informace, zdali je leve tlacitko jako pravdive
      * 
      * 
      */
    public bool isLeftTrue()
    {
        return leftTrue;
    }
}