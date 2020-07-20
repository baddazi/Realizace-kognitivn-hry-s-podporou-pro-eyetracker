using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class OriginalArkanoid2 : MonoBehaviour, ILevel
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
                if (i >= 2 && j < 7)
                    instationField[i, j] = EnumBrickType.randomBonus;
                if (i == 4 || j == 0 || j == 10)
                    instationField[i, j] = EnumBrickType.gold;

                if (i == 4 && j >= 7)
                    instationField[i, j] = EnumBrickType.randomBonus;
            }
        }
        
        instationField[4, 10] = EnumBrickType.gold;
    }


    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}