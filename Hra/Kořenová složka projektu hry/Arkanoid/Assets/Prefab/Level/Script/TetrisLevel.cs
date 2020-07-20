using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Trida sllouzi pro vytvoreni pole, ktere reprezentuje herni pole
 */
public class TetrisLevel : MonoBehaviour, ILevel
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

        
        /*
        instationField[3, 1] = EnumBrickType.white;
        instationField[3, 2] =EnumBrickType.white;
        instationField[2, 2] = EnumBrickType.white;
        //instationField[2, 2] = 4;
       
        instationField[3, 5] =  EnumBrickType.gold;
        instationField[3, 6] =  EnumBrickType.gold;
        instationField[2, 6] =  EnumBrickType.gold;
        instationField[2, 7] =  EnumBrickType.gold;
        
       
        */
      
      
      instationField[0, 0] = EnumBrickType.gold;
      instationField[1, 0] = EnumBrickType.gold;
      instationField[2, 0] = EnumBrickType.gold;
      instationField[0, 1] = EnumBrickType.gold;
      
      instationField[0, 2] = EnumBrickType.gray;
      instationField[0, 3] = EnumBrickType.gray;
      instationField[1, 2] =EnumBrickType.gray;
      instationField[1, 1] = EnumBrickType.gray;
      
      instationField[1, 3] = EnumBrickType.green;
      instationField[2, 3] = EnumBrickType.green;
      instationField[2, 2] = EnumBrickType.green;
      instationField[2, 1] = EnumBrickType.green;
      
      
      instationField[3, 0] = EnumBrickType.purple;
      instationField[3, 1] = EnumBrickType.purple;
      instationField[3, 2] = EnumBrickType.purple;
      instationField[3, 3] = EnumBrickType.purple;

      instationField[4, 0] = EnumBrickType.white;
      instationField[4, 1] = EnumBrickType.white;
      instationField[4, 2] = EnumBrickType.white;
      instationField[4, 3] =  EnumBrickType.white;

      instationField[0, 4] = EnumBrickType.red;
      instationField[1, 4] = EnumBrickType.red;
      instationField[2, 4] = EnumBrickType.red;
      instationField[1, 5] =  EnumBrickType.red;

      instationField[4, 5] = EnumBrickType.blue;
      instationField[3, 4] = EnumBrickType.blue;
      instationField[4, 6] = EnumBrickType.blue;
      instationField[4, 4] =  EnumBrickType.blue;



      instationField[3, 9] = EnumBrickType.gold;
      instationField[2, 9] = EnumBrickType.gold;
      instationField[3, 8] = EnumBrickType.gold;
      instationField[2, 8] = EnumBrickType.gold;





    }

    public EnumBrickType[,] getLevelField()
    {
        init();
        return instationField;
    }
}


