using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class Easylevel6  : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];

    public void init()
    {
        int pom = 0;
        for (int i = 0; i < 5; i++)
        {
        
            for (int j = 0; j < 11; j++)
            {
                instationField[i, j] = EnumBrickType.empty;

                if ( (j>=1 && j<=9))
                {
                    if(i==0 || (j==1) || (j==9))
                        instationField[i, j] = EnumBrickType.gold;
                    else
                        instationField[i, j] = EnumBrickType.randomBonus;
                
                    
                    
                }
               
            }
        }

       
    }


    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}