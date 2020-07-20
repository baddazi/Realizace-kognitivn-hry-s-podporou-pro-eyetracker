using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Tobii.Gaming;

/**
 *Trida slouzi pro aktivaci tlacika pri koukna nebo najeti kurzoru na tlacikto, 
 *
 *
 * @autor David Zaruba
 */

public class EyeButton : MonoBehaviour
{
    [SerializeField] private float changeTime;
    [SerializeField] private Gradient colorGradient;
    [SerializeField] private UnityEvent action;


    private Image image;
    private RectTransform rectTransform;

    private float t;

    private float x = 3.451f;
    private float y = 1.346f;

    /**
     *Event function spoustena pri vytvareni instance. Tato funkce si pouze uklada potrebne komponenty k dalsimu vyuzizi
     * 
     */
    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
 /**
  *Event funkce spoustena v kazdem frammu. Kontroluje, zdali se uzivatel diva a pokud ano, tak odpocitava cas koukan a meni barvu tlacikta.
  * 
  */
    void Update()
    {

     
        
        Vector2 vec = new Vector2(InputManager1.instance.positionX, InputManager1.instance.positionY);


        if (isScreenPointInside(vec))
        {
            t += Time.unscaledDeltaTime / changeTime;
            if (t >= 1)
            {
                action.Invoke();
                t = 0;
               
            }
        }
        else
        {
            t -= Time.unscaledDeltaTime / changeTime;
        }

        image.color = colorGradient.Evaluate(t);
        t = Mathf.Clamp01(t);
    }
 /**
  *Funkce zjistuje, jestli se uzivatel diva na tlacitko
  * 
  */

    bool isScreenPointInside(Vector2 point)
    {
        Vector2 size = getSize();

      
        float maxX = rectTransform.position.x + size.x * .5f;
        float minX = rectTransform.position.x - size.x * .5f;

        float maxY = rectTransform.position.y + size.y * .5f;
        float minY = rectTransform.position.y - size.y * .5f;

        return maxX > point.x && minX < point.x && maxY > point.y && minY < point.y;
    }
 /**
  *Vraci velikost tlacitka
  * 
  */
 
    Vector2 getSize()
    {
        return new Vector2(x, y);
    }
}