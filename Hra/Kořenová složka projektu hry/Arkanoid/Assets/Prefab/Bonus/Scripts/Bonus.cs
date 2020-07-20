
using UnityEngine;
/**
 *
 * Trida se stara o pohyb a vytvoreni konkretniho bonusu
 */

public class Bonus : MonoBehaviour
{
 
    [SerializeField] private Sprite greenBonus;
    [SerializeField] private Sprite blueBonus;
    [SerializeField] private Sprite redBonus;
    [SerializeField] private GameObject bonusManger;
    private EnumBonusType bonusType;

    /**
     *
     * Event funkce spoustena pri vytvareni instance. Zde se pouze nastavuje collider pro pozdejsi vyuziti.
     */
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
    /**
     *Nastavuje vzhled bonusu na cerveny
     * 
     */

    private void setRed()
    {
        GetComponent<SpriteRenderer>().sprite = redBonus;
    }

    
    
    /**
     *Nastavuje vzhled bonusu na  modry
     * 
     */
    private void setBlue()
    {
        GetComponent<SpriteRenderer>().sprite = blueBonus;
    }

    
    /**
     *Nastavuje vzhled bonusu na zeleny
     * 
     */
    private void setGreen()
    {
        GetComponent<SpriteRenderer>().sprite = greenBonus;
    }

    /**
     *Nastavení konretniho bonusu podle typu v parametru
     * 
     */
    public void typeOfBonus(EnumBonusType type)
    {
        bonusType = type;
        switch (type)
        {
            case EnumBonusType.Green:
                setGreen();
                break;
            case EnumBonusType.Red:
                setRed();
                break;
            case EnumBonusType.Blue:
                setBlue();
                break;
        }
    }

    public GameObject BonusManger
    {
        get => bonusManger;
        set => bonusManger = value;
    }

    /**
     *Event funkce spustena kazdy frame, ktera zajistuje pohyb bonusu smerm dolu.
     * 
     */
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, 0);
    }

    
    /**
     *
     * Funkce spustena pri kolizi. Pokud narazi do platformy, preda informaci pro aktivovani bonusu
     */

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Platform")
        {
            BonusManager br = bonusManger.GetComponent<BonusManager>();
            br.setBonus(bonusType);
            Destroy(gameObject);
        }
    }
}