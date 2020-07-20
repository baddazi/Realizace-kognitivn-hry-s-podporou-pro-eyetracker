using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class FlowerLevel : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];
    public void init()
    {
      
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                instationField[i, j] = EnumBrickType.empty;
            }
        }

        instationField[1, 5] = EnumBrickType.white;
        instationField[2, 5] = EnumBrickType.gold;
        instationField[3, 5] = EnumBrickType.white;
        instationField[2, 4] = EnumBrickType.white;
        instationField[2, 6] = EnumBrickType.white;

        instationField[0, 5] = EnumBrickType.white;
        instationField[1, 4] = EnumBrickType.white;
        instationField[0, 3] = EnumBrickType.white;
        instationField[1, 6] = EnumBrickType.white;
        instationField[0, 7] = EnumBrickType.white;
        
        //instationField[2, 1] = 4;
        instationField[2, 2] = EnumBrickType.white;
        instationField[2, 3] = EnumBrickType.white;
        
        instationField[2, 7] = EnumBrickType.white;
        instationField[2, 8] = EnumBrickType.white;
       // instationField[2, 9] = 4;
        
        instationField[3, 4] = EnumBrickType.white;
        instationField[3, 6] = EnumBrickType.white;
        instationField[4, 3] = EnumBrickType.white;
        instationField[4, 7] =EnumBrickType.white;
        instationField[4, 5] = EnumBrickType.white;
        
        
      
     
        
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}
