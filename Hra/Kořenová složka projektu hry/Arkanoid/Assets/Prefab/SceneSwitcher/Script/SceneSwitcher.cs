using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Trida slouzi pro prepinani scen v unity
 */
public class SceneSwitcher : MonoBehaviour
{
    public void nextLevelScene()
    {
       SettingManager.addLevel();
        SceneManager.LoadScene("Levels");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void toLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void toSettingMenu()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void toQuickGame()
    {
        SceneManager.LoadScene("QuickGame");
    }
    
    public void toSurvivor()
    {
        SceneManager.LoadScene("Survivor");
    }

    public void toLevel1()

    {
        SettingManager.levelToPlay = 0;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel2()

    {
        SettingManager.levelToPlay = 1;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel3()
    {
        SettingManager.levelToPlay = 2;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel4()
    {
        SettingManager.levelToPlay = 3;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel5()
    {
        SettingManager.levelToPlay = 4;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel6()
    {
        SettingManager.levelToPlay = 5;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel7()
    {
        SettingManager.levelToPlay = 6;
        SceneManager.LoadScene("Levels");
    }

    public void toLevel8()
    {
        SettingManager.levelToPlay = 7;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel9()
    {
        SettingManager.levelToPlay = 8;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel10()
    {
        SettingManager.levelToPlay = 9;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel11()
    {
        SettingManager.levelToPlay = 10;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel12()
    {
        SettingManager.levelToPlay = 11;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel13()
    {
        SettingManager.levelToPlay = 12;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel14()
    {
        SettingManager.levelToPlay = 13;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel15()
    {
        SettingManager.levelToPlay = 14;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel16()
    {
        SettingManager.levelToPlay = 15;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel17()
    {
        SettingManager.levelToPlay = 16;
        SceneManager.LoadScene("Levels");
    }
    
    public void toLevel18()
    {
        SettingManager.levelToPlay = 17;
        SceneManager.LoadScene("Levels");
    }
    public void toTutorials()
    {
        SceneManager.LoadScene("Tutorials");
    }
    public void toTutorialMainMenu()
    {
        SceneManager.LoadScene("TutorialMainMenu");
    }
    
    public void toTutoriaSetting()
    {
        SceneManager.LoadScene("TutorialSetting");
    }
    public void toUIOfGame()
    {
        SceneManager.LoadScene("TutiralUIOfGame");
    }
    
    public void toTutorialCogMiniGame()
    {
        SceneManager.LoadScene("TutorialCogMiniGame");
    }
    
    public void toTutorialTypeOfBrickBonus()
    {
        SceneManager.LoadScene("TutiralTypeOfBrickBonus");
    }
    
    public void toTutorialPrincipeOfGame()
    {
        SceneManager.LoadScene("TutorialPrincipeOfGame");
    }

    public void shutDownGame()
    {
        Application.Quit();
    }
    
   


    
}