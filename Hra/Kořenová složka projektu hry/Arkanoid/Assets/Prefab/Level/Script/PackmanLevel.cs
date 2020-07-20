using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class PackmanLevel : MonoBehaviour, ILevel
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

       instationField[0, 2] = EnumBrickType.green;
        
        instationField[1, 1] =  EnumBrickType.green;
        instationField[1, 2] =  EnumBrickType.green;
       instationField[1, 3] = EnumBrickType.green;
        
        //instationField[2, 0] = 8;
        instationField[2, 1] =  EnumBrickType.green;
        instationField[2, 2] =  EnumBrickType.green;
       
        instationField[3, 1] = EnumBrickType.green;
        instationField[3, 2] = EnumBrickType.green;
        instationField[3, 3] = EnumBrickType.green;
        
       instationField[4, 2] =  EnumBrickType.green;
        
        instationField[2, 5] = EnumBrickType.purple;
        instationField[2, 7] = EnumBrickType.purple;
        instationField[2, 9] = EnumBrickType.purple;
        
        
        
     
        
    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}
