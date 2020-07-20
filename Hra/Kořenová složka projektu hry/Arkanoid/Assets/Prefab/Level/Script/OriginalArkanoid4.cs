using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class OriginalArkanoid4 : MonoBehaviour, ILevel
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

                if (i == 0)
                {
                    if (j % 2 == 0)
                        instationField[i, j] = EnumBrickType.randomBonus;
                }
                if (i == 1)
                {
                    if (j % 2 == 0)
                        instationField[i, j] = EnumBrickType.gray;
                }

                if (i== 2)
                {
                    if (j % 2 != 0)
                        instationField[i, j] = EnumBrickType.randomBonus;
                }
                if (i == 3)
                {
                    if (j % 2 != 0)
                        instationField[i, j] = EnumBrickType.gray;
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