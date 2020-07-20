using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *Trida slouzi pro sedive cihlicky se tremi zivoty
 *
 * @autor David Zaruba
 *
 * 
 */
public class brickGray : MonoBehaviour
{
    private int life = 2;

    [SerializeField] Sprite demage;
    [SerializeField] Sprite smallDemage;

    private GameObject BonusManager;

    private int[] positionField = new int[2];


    public int[] PositionField
    {
        get => positionField;
        set => positionField = value;
    }

    public GameObject BonusManager1
    {
        get => BonusManager;
        set => BonusManager = value;
    }

    /**
     *
     *Funkce je spoustena pri kolizi. Ubere jeden zivot cihlicce a pokud je 0 zivotu, zajisti jeji zniceni, a take o zniceni informuje. 
     * 
     */
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (life == 0)
        {
            BonusManager.GetComponent<BonusManager>().brickDestroyed(positionField);
            Destroy(gameObject);
            
        }
        else
        {
            if (life == 2)
                GetComponent<SpriteRenderer>().sprite = smallDemage;
            else
                GetComponent<SpriteRenderer>().sprite = demage;
        }

        life--;
    }
}