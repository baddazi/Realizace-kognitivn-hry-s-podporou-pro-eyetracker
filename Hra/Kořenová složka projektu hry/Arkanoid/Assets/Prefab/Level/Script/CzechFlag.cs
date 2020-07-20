using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class CzechFlag : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];

    public void init()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (i < 3)
                    instationField[i, j] = EnumBrickType.white;

                if ((i == 2 && j % 2 == 0) || i >= 3)
                    instationField[i, j] = EnumBrickType.red;

                int pos = i * 2 + 1;
                if (i < 3 && j <= pos)
                    instationField[i, j] = EnumBrickType.blue;

                if(i==3 && j<=3)
                    instationField[i, j] = EnumBrickType.blue;
                
                if(i==4 && j<=1)
                    instationField[i, j] = EnumBrickType.blue;

        }
        }
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}