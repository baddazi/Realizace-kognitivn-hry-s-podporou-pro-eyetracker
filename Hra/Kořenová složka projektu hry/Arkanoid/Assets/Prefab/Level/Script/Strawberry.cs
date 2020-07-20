using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class Strawberry : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];
    public void init()
    {
      
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                instationField[i, j] = EnumBrickType.white;
            }
        }

        instationField[2, 0] = EnumBrickType.red;
        instationField[1, 1] = EnumBrickType.red;
        instationField[1, 2] = EnumBrickType.red;
        instationField[1, 3] = EnumBrickType.red;
        instationField[2, 4] = EnumBrickType.red;

        instationField[2, 1] = EnumBrickType.red;
        instationField[2, 2] = EnumBrickType.red;
        instationField[2, 3] = EnumBrickType.red;
        
        instationField[3, 1] = EnumBrickType.red;
        instationField[3, 2] =  EnumBrickType.red;
        instationField[3, 3] = EnumBrickType.red;
        instationField[4, 2] = EnumBrickType.red;
        
        
        instationField[0, 1] = EnumBrickType.green;
        instationField[0, 2] = EnumBrickType.green;
        instationField[0, 3] = EnumBrickType.green;
        
        
        instationField[0, 5] = EnumBrickType.gold;
        instationField[1, 5] = EnumBrickType.gold;
        instationField[2, 5] = EnumBrickType.gold;
        instationField[3, 5] = EnumBrickType.gold;
        instationField[4, 5] = EnumBrickType.gold;
        
        
        instationField[2, 6] = EnumBrickType.purple;
        instationField[1, 7] = EnumBrickType.purple;
        instationField[1, 8] = EnumBrickType.purple;
        instationField[1, 9] = EnumBrickType.purple;
        instationField[2, 10] = EnumBrickType.purple;

        instationField[2, 7] = EnumBrickType.purple;
        instationField[2, 8] = EnumBrickType.purple;
        instationField[2, 9] = EnumBrickType.purple;
        
        instationField[3, 7] = EnumBrickType.purple;
        instationField[3, 8] = EnumBrickType.purple;
        instationField[3, 9] = EnumBrickType.purple;
        instationField[4, 8] = EnumBrickType.purple;
        
        
        instationField[0, 7] = EnumBrickType.green;
        instationField[0, 8] = EnumBrickType.green;
        instationField[0, 9] =EnumBrickType.green;
        
     
        
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}


