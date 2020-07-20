using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/**
 * Trida slouzi pro proojeni nastaveni a Setting Manageru. Trida ma nastarosti obousmernou spravnost dat.
 */
public class UIValueChanger : MonoBehaviour
{
    [SerializeField] private Toggle toMouseInput;
    [SerializeField] private Toggle toKeyInput;
    [SerializeField] private Toggle toEyeInput;

    [SerializeField] private TextMeshProUGUI countOfLive;
    [SerializeField] private Slider liveSlider;

    [SerializeField] private Toggle infinitxToggle;


    [SerializeField] private TextMeshProUGUI PercentBonusText;
    [SerializeField] private Slider PercentBonusSlider;

    [SerializeField] private TextMeshProUGUI DiffGameText;
    [SerializeField] private Slider DiffGameSlider;


    [SerializeField] private TextMeshProUGUI DiffGameCogMiniText;
    [SerializeField] private Slider DiffGameCogMIniSlider;


    [SerializeField] private Toggle cogMiniToggle;

    [SerializeField] private TextMeshProUGUI PercentBrickText;
    [SerializeField] private Slider PercentBrickSlider;

    [SerializeField] private TextMeshProUGUI countOfLiveSurv;
    [SerializeField] private Slider liveSliderSurv;


    [SerializeField] private TextMeshProUGUI countOfCogMiniGameText;
    [SerializeField] private Slider countOfCogSlider;

    private bool temp1 = false;
    private bool temp2 = false;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch (SettingManager.typeOFInput)
        {
            case 0:
                toMouseInput.isOn = true;
                break;
            case 1:
                toKeyInput.isOn = true;
                break;
            case 2:
                toEyeInput.isOn = true;
                break;
        }


        if (!SettingManager.infinityLive)
            temp1 = true;

        if (!SettingManager.enableCogGame)
            temp2 = true;

        countOfCogSlider.value = SettingManager.countOfCogMiniGame;
        countOfCogMiniGameText.SetText(SettingManager.countOfCogMiniGame+"");

        infinitxToggle.isOn = SettingManager.infinityLive;
        cogMiniToggle.isOn = SettingManager.enableCogGame;


        liveSlider.value = SettingManager.countOfLive;
        countOfLive.SetText(SettingManager.countOfLive + "");

        liveSliderSurv.value = SettingManager.countOfLive;
        countOfLiveSurv.SetText(SettingManager.countOfLive + "");


        DiffGameText.SetText(SettingManager.getDifficultyOFGame(SettingManager.speedOfBall) + "");
        DiffGameSlider.value = SettingManager.getDifficultyOFGame(SettingManager.speedOfBall);

        DiffGameCogMiniText.SetText(SettingManager.difficultyOfCogGame + "");
        DiffGameCogMIniSlider.value = SettingManager.difficultyOfCogGame;

        PercentBonusText.SetText(SettingManager.percentOfBonus + "%");
        PercentBonusSlider.value = SettingManager.percentOfBonus;

        PercentBrickText.SetText(SettingManager.percentOfBrick + "%");
        PercentBrickSlider.value = SettingManager.percentOfBrick;

        if (infinitxToggle.isOn)
            liveSlider.interactable = false;

        if (!cogMiniToggle.isOn)
        {
            countOfCogSlider.interactable = false;
            DiffGameCogMIniSlider.interactable = false;
        }
    }

    public void setCountOfLive()
    {
        SettingManager.countOfLive = Convert.ToInt32(liveSlider.value);
        countOfLive.SetText(SettingManager.countOfLive + "");
        //  SettingManager.countOfLive = Convert.ToInt32(liveSliderSurv.value);
        countOfLiveSurv.SetText(SettingManager.countOfLive + "");
        liveSliderSurv.value = liveSlider.value;
    }

    public void setCountOfCogMiniGame()
    {

        SettingManager.countOfCogMiniGame =Convert.ToInt32(countOfCogSlider.value);
        countOfCogMiniGameText.SetText(SettingManager.countOfCogMiniGame+"");

    }


public void changeInfinityLive()
    {
        if (temp1)
        {
            temp1 = false;
            return;
            ;
        }


        if (infinitxToggle.isOn)
        {
            liveSlider.interactable = false;
        }
        else
        {
            liveSlider.interactable = true;
        }

        SettingManager.infinityLive = !SettingManager.infinityLive;
    }

    public void toMouse()
    {
        SettingManager.typeOFInput = 0;
    }

    public void toKey()
    {
        SettingManager.typeOFInput = 1;
    }

    public void toEye()
    {
        SettingManager.typeOFInput = 2;
    }

    public void setPercentOFBonus()
    {
        SettingManager.percentOfBonus = Convert.ToInt32(PercentBonusSlider.value);
        PercentBonusText.SetText(SettingManager.percentOfBonus + "%");
    }

    public void setDifficultyOFGame()
    {
        SettingManager.settDifficultyOFGame(Convert.ToInt32(DiffGameSlider.value));
        DiffGameText.SetText(SettingManager.getDifficultyOFGame(SettingManager.speedOfBall) + "");
    }

    public void changeActivationCogMiniGame()
    {
        if (temp2)
        {
            temp2 = false;
            return;
            ;
        }

        if (!cogMiniToggle.isOn)
        {
            DiffGameCogMIniSlider.interactable = false;
            countOfCogSlider.interactable = false;
        }
        else
        {
            DiffGameCogMIniSlider.interactable = true;
            countOfCogSlider.interactable = true;
        }

        SettingManager.enableCogGame = !SettingManager.enableCogGame;
    }

    public void setDifficultyOFCogMiniGame()
    {
        SettingManager.difficultyOfCogGame = Convert.ToInt32(DiffGameCogMIniSlider.value);
        DiffGameCogMiniText.SetText(SettingManager.difficultyOfCogGame + "");
    }

    public void setPercentOFBrick()
    {
        SettingManager.percentOfBrick = Convert.ToInt32(PercentBrickSlider.value);
        PercentBrickText.SetText(SettingManager.percentOfBrick + "%");
    }

    public void setCountOfLiveSurv()
    {
        SettingManager.countOfLive = Convert.ToInt32(liveSliderSurv.value);
        countOfLiveSurv.SetText(SettingManager.countOfLive + "");


        // SettingManager.countOfLive = Convert.ToInt32(liveSlider.value);
        countOfLive.SetText(SettingManager.countOfLive + "");
        liveSlider.value = liveSliderSurv.value;
    }
    
    
}

// Update is called once per frame