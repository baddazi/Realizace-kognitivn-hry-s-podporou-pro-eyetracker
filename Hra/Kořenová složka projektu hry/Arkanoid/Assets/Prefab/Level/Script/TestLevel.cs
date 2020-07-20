using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class TestLevel : MonoBehaviour, ILevel
{
    // Start is called before the first frame update
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


        instationField[3, 2] = EnumBrickType.randomBonus;
        instationField[3, 3] = EnumBrickType.randomBonus;
        instationField[3, 4] = EnumBrickType.randomBonus;
        instationField[3, 5] = EnumBrickType.randomBonus;
        instationField[3, 6] = EnumBrickType.randomBonus;
        instationField[3, 7] = EnumBrickType.randomBonus;
        instationField[3, 8] = EnumBrickType.gold;
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;

    }
}
