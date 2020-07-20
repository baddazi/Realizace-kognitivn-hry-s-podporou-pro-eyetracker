using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class ZCUFAVLevel : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];

    public void init()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (j == 0)
                    instationField[i, j] = EnumBrickType.white;
            
                    else
                        instationField[i, j] = EnumBrickType.empty;
            }    
        }

        EnumBrickType type = EnumBrickType.randomBonus;
        
        instationField[0, 0] = type;
        instationField[1, 0] = type;
        instationField[2, 0] = type;
        instationField[3, 0] = type;
        instationField[4, 0] = type;
        instationField[0, 1] = type;
        instationField[2, 1] = type;
        instationField[0, 2] = type;
        instationField[2, 2] = type;
        
        instationField[4, 4] = type;
        instationField[1, 4] = type;
        instationField[2, 4] = type;
        instationField[3, 4] = type;
        instationField[0, 5] = type;
        instationField[2, 5] = type;
        instationField[4, 6] = type;
        instationField[1, 6] = type;
        instationField[2, 6] = type;
        instationField[3, 6] = type;
        
        instationField[0, 8] = type;
        instationField[1, 8] = type;
        instationField[2, 8] = type;
        instationField[3, 8] = type;
        instationField[4, 9] = type;
        instationField[0, 10] =type;
        instationField[1, 10] = type;
        instationField[2, 10] = type;
        instationField[3, 10] = type;
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}