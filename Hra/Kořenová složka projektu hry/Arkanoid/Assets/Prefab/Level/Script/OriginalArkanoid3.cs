using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class OriginalArkanoid3 : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];

    public void init()
    {
        bool pom = false;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                instationField[i, j] = EnumBrickType.empty;

                if(j==1)
                    instationField[i, j] = EnumBrickType.gold; 
                
                if(i==4 && j>1)
                    instationField[i, j] = EnumBrickType.gold; 

            }
        }
        
        instationField[1, 1] = EnumBrickType.empty; 
        instationField[2, 1] = EnumBrickType.empty; 
        
        instationField[0, 6] = EnumBrickType.randomBonus;
        instationField[0, 7] = EnumBrickType.randomBonus;
        instationField[1, 6] = EnumBrickType.gray;
        instationField[1, 7] = EnumBrickType.gray;
        instationField[2, 6] = EnumBrickType.gray;
        instationField[2, 7] = EnumBrickType.gray;
        instationField[3, 6] = EnumBrickType.randomBonus;
        instationField[3, 7] = EnumBrickType.randomBonus;
        
        
       
        instationField[1, 5] = EnumBrickType.randomBonus;
       
        instationField[2, 5] = EnumBrickType.randomBonus;
        
        instationField[1, 8] = EnumBrickType.randomBonus;
     
        instationField[2, 8] = EnumBrickType.randomBonus;
      
        
        
        
    }
    
    


    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}