using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class OriginalArkanoid1 : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];

    public void init()
    {
        int pos = -1;
        for (int i = 0; i < 5; i++)
        {
            
            if(i%2==0)
                pos = pos + 3;
            else
                pos= pos + 2;
            for (int j = 0; j < 11; j++)
            {
                instationField[i, j] = EnumBrickType.empty;
                  
                
                if (j <= pos && i!=4)
                    instationField[i, j] = EnumBrickType.randomBonus;

                
              
                if(i==4 && j<10)
                    instationField[i, j] = EnumBrickType.gray;

            }
        }
    }
    
    

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}