using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class arkanoidLevel : MonoBehaviour, ILevel
{
    private  EnumBrickType[,] instationField= new EnumBrickType[5, 11];
    public void init()
    {
      
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if(i==0 || j==0 || j== 10)
                    instationField[i, j] = EnumBrickType.gray;
                else
                instationField[i, j] = EnumBrickType.empty;
            }
        }

        instationField[4, 4] = EnumBrickType.gray;
        instationField[4, 5] =  EnumBrickType.gray;
        instationField[4, 6] = EnumBrickType.gray;
        instationField[4, 3] = EnumBrickType.red;
        instationField[4, 7] = EnumBrickType.red;

        instationField[2, 5] =  EnumBrickType.white;
        
        
        
     
        
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}