using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *
 * Interace pro vytvarele urovni ve hre
 */
public interface ILevel 
{
    // Start is called before the first frame update
    EnumBrickType[,] getLevelField();
}
