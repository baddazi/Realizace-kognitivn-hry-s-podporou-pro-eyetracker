using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.UI;


/**
 * Trida obstarava ukazatele soustredeni a relaxace ve hre.
 *
 * @autor David Zaruba
 */
public class ChangeBar : MonoBehaviour
{
    [SerializeField] private Image leftEmpty;
    [SerializeField] private Image rightEmpty;
    [SerializeField] private Image leftMeditation;
    [SerializeField] private Image rightAttention;
    private float visibility = 0.5f;

    private RectTransform le;
    private RectTransform lm;
    private RectTransform re;
    private RectTransform rm;

    [SerializeField] private GameObject panel;


  /**
   * Event funkce, ktere je volana pri vytvareni instance. Zde se prirazuji jednotlive reference na ukazatele pro pozdejsi vyuziti.
   */
    void Start()
    {
        le = leftEmpty.GetComponent<RectTransform>();
        lm = leftMeditation.GetComponent<RectTransform>();

        re = rightEmpty.GetComponent<RectTransform>();
        rm = rightAttention.GetComponent<RectTransform>();

        if (SettingManager.isMindWaveConnect && SettingManager.trackMindActivity)
        {
            barLevel();
        }
        else
        {
            hide();
        }
    }

   /**
    *Event funkce volana v kazdem frame. Zde se upravy podle hodnot soustredeni a relaxace konkretni ukazatel.
    * 
    */
    void Update()
    {
        if (SettingManager.isMindWaveConnect && SettingManager.trackMindActivity)
        {
            barLevel();
        }
        else
        {
            hide();
        }
    }

    /**
     *
     * Zajisti zmenu ukazatelu
     */
    public void barLevel()
    {
        if(!panel.activeSelf)
        panel.SetActive(true);

        lm.sizeDelta = new Vector2(lm.sizeDelta.x, le.sizeDelta.y * InputManager1.instance.attention / 100);
        rm.sizeDelta = new Vector2(rm.sizeDelta.x, re.sizeDelta.y * InputManager1.instance.meditation / 100);
    }

/**
 *Funkce zajisit zkryti ukazarelu pokud je Neurosky MindWave odpojena
 * 
 */
    public void hide()
    {
        if(panel.activeSelf)
        panel.SetActive(false);
    }
}