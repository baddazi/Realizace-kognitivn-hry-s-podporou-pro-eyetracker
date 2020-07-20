using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;
using Random = System.Random;

public class brickBonus : MonoBehaviour
{
    
    /**
     *Trida se stara o cihlicky, ktere jsou schopne obsahovat bonus
     *
     * @autor David Zaruba
     * 
     */
    private bool isBonus = false;

    [SerializeField] private GameObject bonus;
    private GameObject bonusManager;
    private int [] positionFiled = new int[2];
    
   
    public int[] PositionFiled
    {
        get => positionFiled;
        set => positionFiled = value;
    }

    public GameObject Bonus
    {
        get => bonus;
        set => bonus = value;
    }

  
    public void setBonus()
    {
        isBonus = true;
    }

    public GameObject BonusManager
    {
        get => bonusManager;
        set => bonusManager = value;
    }
    
    /**
 *  Funkce spustena pri kolizi. Zajisti zniceni dane cihlicky, predani informace o svem zniceni a pokud obsahuje bonus, tak vytvori instaci bonusu.  
  * 
  */
    void OnCollisionEnter2D(Collision2D col)
    {
        BonusManager.GetComponent<BonusManager>().brickDestroyed(positionFiled);
        if (isBonus)
        {
            var instance = Instantiate<GameObject>(bonus);

            Random rand = new Random();
            int temp1 = rand.Next(3);

            switch (temp1)
            {
                case 0:
                    instance.GetComponent<Bonus>().typeOfBonus(EnumBonusType.Red);
                    break;
                case 1:
                    instance.GetComponent<Bonus>().typeOfBonus(EnumBonusType.Blue);
                    break;
                case 2:
                    instance.GetComponent<Bonus>().typeOfBonus(EnumBonusType.Green);
                    break;
            }
            instance.GetComponent<Bonus>().BonusManger = BonusManager;
            UnityEngine.Vector3 temp = transform.position;
            Destroy(gameObject);

            instance.gameObject.transform.position = temp;
        }
        else
            Destroy(gameObject);
    }
}