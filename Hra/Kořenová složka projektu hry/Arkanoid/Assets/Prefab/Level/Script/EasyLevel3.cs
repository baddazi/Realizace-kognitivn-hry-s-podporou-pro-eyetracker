using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class EasyLevel3 : MonoBehaviour, ILevel
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

                if ((i >=1&&i<4) && (j>=3 && j<=7))
                {
                    if(i==2)
                        instationField[i, j] = EnumBrickType.gray;
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