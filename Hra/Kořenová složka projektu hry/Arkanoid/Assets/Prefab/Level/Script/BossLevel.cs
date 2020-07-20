
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class BossLevel : MonoBehaviour, ILevel
{
    private EnumBrickType[,] instationField = new EnumBrickType[5, 11];

    public void init()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if(j==0 || j==1 || j==2)
                     instationField[i, j] = EnumBrickType.blue;
                
                if(j==2)
                    if(i==1 || i==3)
                        instationField[i, j] = EnumBrickType.white;
                
                
                if(j==3 || j==4)
                    instationField[i, j] = EnumBrickType.white;
                
                if(j==5 || j==6 || j==7)
                    instationField[i, j] = EnumBrickType.blue;
                
                if(j==8 || j==9 || j==10)
                    instationField[i, j] = EnumBrickType.white;
            }
        }

        
        instationField[1, 1] = EnumBrickType.empty;
        instationField[3, 1] = EnumBrickType.empty;
        
        instationField[1, 3] = EnumBrickType.empty;
        instationField[2, 3] = EnumBrickType.empty;
        instationField[3, 3] = EnumBrickType.empty;
        
        instationField[3, 5] = EnumBrickType.empty;
        
        instationField[1, 6] = EnumBrickType.empty;
        instationField[3, 6] = EnumBrickType.empty;
        
        instationField[1, 7] = EnumBrickType.empty;

        instationField[1, 7] = EnumBrickType.empty;
        
        instationField[3, 8] = EnumBrickType.empty;
        
        instationField[1, 9] = EnumBrickType.empty;
        instationField[3, 9] = EnumBrickType.empty;
        
        instationField[1, 10] = EnumBrickType.empty;
      
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}