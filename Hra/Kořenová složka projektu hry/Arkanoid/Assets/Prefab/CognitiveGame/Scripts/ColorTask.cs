using System;

using UnityEngine;
using static UnityEngine.Color;
using Random = System.Random;

/**
 *Trida dedi od ACogGame a zajistuje vytvoreni kognitivni minhry pro barvu textu
 * 
 */
public class ColorTask : ACogGame
{



    /**
     *Vytvari ukolovou otazku a definjuje na jakych urovnich je minihra definovana
     * 
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

        mainT = "Jakou barvou je níže napsaný text?";
    }
    /**
 *Funkce pro vytvoreni minihry dane narocnosti
 * 
 */
    protected override string firstLevel()
    {
        throw new System.NotImplementedException();
    }
    /**
 *Funkce pro vytvoreni minihry dane narocnosti
 * 
 */
    protected override string secondLevel()
    {
        throw new System.NotImplementedException();
    }
    /**
 *Funkce pro vytvoreni minihry dane narocnosti
 * 
 */
    protected override string thirthLevel()
    {
        throw new System.NotImplementedException();
    }
    /**
 *Funkce pro vytvoreni minihry dane narocnosti
 * 
 */
    protected override string fourthLevel()
    {
        throw new System.NotImplementedException();
    }

    protected override string fifthLevel()
    {
        return easyerVersion();
    }
    /**
 *Funkce pro vytvoreni minihry dane narocnosti
 * 
 */
    protected override string sixthLevel()
    {
        return easyerVersion();
    }
    /**
 *Funkce pro vytvoreni minihry dane narocnosti
 * 
 */
    protected override string seventhLevel()
    {
        return harrderVersion();
    }
 /**
  *
  * Funkce vytvari narocnejsi verzi teto minihry
  */

    private String harrderVersion()
    {
        
        Random rand = new Random();

        int usedColor = rand.Next(7);

        int textColor = rand.Next(7);

        while (textColor == usedColor)
            textColor = rand.Next(7);
            
        

        createColor(usedColor, textColor);
      

        return getNameOfCollor(getCollor(textColor));

    }

/**
 *
 * Funkce vytvari jednodusz verzi teto minihry
 */
    private String easyerVersion()
    {

        Random rand = new Random();
      
       
        createColor(rand.Next(7), -1);
        return "Text";

    }

    
    /**
 *
 * Funkce vytvari  konkretni ukol s barvami
 */

private void createColor(int usedColor, int textColor)
    {
       

        Random rand = new Random();
       

        if (textColor == -1)
        {
            textColor=rand.Next(7);
            while (textColor == usedColor)
            {
                textColor=rand.Next(7);
            }
        }
        
        Color rightColor = getCollor(usedColor);


        if (rand.Next(2) == 0)
        {
            rightT = getNameOfCollor(rightColor);

            int p = rand.Next(7);
            while (p == usedColor|| p==textColor)
            {
                p = rand.Next(7);
            }

            right.color = getCollor(p);

           
            Random rn = new Random();

            left.color = getCollor(textColor);

            int q = rn.Next(7);
            while (q == usedColor ||q == textColor)
            {
                q = rn.Next(7);
            }

            leftT = getNameOfCollor(getCollor(q));
            leftTrue = false;

        }
        else
        {
           
            leftT = getNameOfCollor(rightColor);

            int p = rand.Next(7);
            while (p == usedColor  || p==textColor)
            {
                p = rand.Next(7);
            }

         
            left.color = getCollor(p);

            right.color = getCollor(textColor);

            Random rn = new Random();

            int q = rn.Next(7);
            while (q == usedColor || q == textColor)
            {
                q = rn.Next(7);
            }

            rightT = getNameOfCollor(getCollor(q));
            leftTrue = true;
        }

        question.color = rightColor;
        
    }

   /**
    *Funkce pro zjisteni nazvu barvy
    * 
    */
    private String getNameOfCollor(Color color)
    {


        if (color.Equals(Color.red))
            return "Červená";
        
        if (color.Equals(new Color(0.6078f,0.2941f,0f)))
            return "Hnědá";
        
        if (color.Equals(new Color(1,0.4117f,0.7058f)))
            return "Růžová";
        
        if (color.Equals(Color.black))
            return "Černá";
        
        if (color.Equals(Color.green))
            return "Zelená";
        
        if (color.Equals(Color.white))
            return "Bílá";
        
        if (color.Equals(Color.yellow))
            return "Žlutá";

        return "";

    }
    /**
       *Funkce pro ziskani konretni barby
       * 
       */
    private Color getCollor(int tp)
    {
        
        switch (tp)
        {
            case 0:  return red;
               
            case 1:  return new Color(0.6078f,0.2941f,0f);
               
            case 2:  return new Color(1,0.4117f,0.7058f);
               
            case 3:  return black;
               
            case 4:  return green;
                
            case 5:  return white;
                
            case 6:  return yellow;
                
            
        }

        return red;

    }
}
