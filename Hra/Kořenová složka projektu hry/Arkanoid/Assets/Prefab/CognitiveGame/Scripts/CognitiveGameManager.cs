using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tobii.Gaming.Internal;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

/**
 * Trida vybira mezi Kognitivnimi minhrami a zajistuje predani veskerych potrebnych referenci prislousnym minihram
 */
public class CognitiveGameManager : MonoBehaviour
{
    public static int countOfLevel = 7;
     private int dificult = SettingManager.difficultyOfCogGame;
    private static int coutOfGame = 7;
    private bool isLeftTrue;
    private int rightAnswers = 1;
    private int countOfWrongAns = 0;
    private int countOFRightAns = 0;

    

    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI left;
    [SerializeField] private TextMeshProUGUI right;

    private Random rand = new Random();
    private gameManager1 gameManager;

    private ACogGame a1 = new Calc1();
    private ACogGame a2 = new Even1();
    private ACogGame a3 = new Sequence();
    private ACogGame a4 = new Equation();
    private ACogGame a5 = new Calc();
    private ACogGame a6 = new ColorTask();
    private ACogGame a7 = new DayMonthYear();


    private ACogGame[] field = new ACogGame[coutOfGame];
/**
 *Event funkce spustena pred vytvorenim instance. Funkce naplni pole miniher a nejakou vybere
 * 
 */
    void Start()
    {
        field[0] = new Calc1();
        field[1] = new Even1();
        field[2] = new Sequence();
        field[3] = new Equation();
        field[4] = new Calc();
        field[5] = new ColorTask();
        field[6] = new DayMonthYear();

        chooseGame();
    }

    // Update is called once per frame


    public void setGameManager(gameManager1 gm)
    {
        gameManager = gm;
    }

    public int getCountOfWrongAns()
    {
        return countOfWrongAns;
    }
    
    public int getCountOfRightAns()
    {
        return countOFRightAns;
    }
  /**
   *Vybira minihru na zaklade urovne obtiznosti
   * 
   */
    private void chooseGame()
    {
        ACogGame[] correct = chooseCorrectGame();
        int r = rand.Next(correct.Length);


        correct[r].setSuff(left, right, mainText, question);
        correct[r].createGame(dificult);


        isLeftTrue = correct[r].isLeftTrue();
    }

    /**
     * Vytvori pole plne jen miniher, ktere jsou definovane na dale obtiznosti
     */
    private ACogGame[] chooseCorrectGame()
    {
        ACogGame[] correct;
        int k = 0;
        for (int i = 0; i < coutOfGame; i++)
        {
            if (field[i].isLevel(dificult))
                k++;
        }

        correct = new ACogGame[k];
        k = 0;
        for (int i = 0; i < coutOfGame; i++)
        {
            if (field[i].isLevel(dificult))
            {
                correct[k] = field[i];
                k++;
            }
        }


        return correct;
    }
 /**
  *Funkce spustena tlacitkem. Zajistuje se kontrola spravnosti odovdedi
  * 
  */
    public void pressLeft()
    {
        if (isLeftTrue)
        {
            countOFRightAns++;
            rightAnswer();
        }
        else
        {
            countOfWrongAns++;
        }
    }

/**
 *Funkce spustena tlacitkem. Zajistuje se kontrola spravnosti odovdedi
 * 
 */
    public void pressRight()
    {
        if (!isLeftTrue)
        {
            countOFRightAns++;
            rightAnswer();
        }
        else
        {
            countOfWrongAns++;
        }
    }
    /**
     *Funkce pro spracnou odpovde, ktera zajisti dalsi funkce 
     * 
     */

    private void rightAnswer()
    {
        if (rightAnswers < SettingManager.countOfCogMiniGame)
        {
            rightAnswers++;
            chooseGame();
        }
        else
        {
            gameManager.disableCogGame(false);
        }
        
    }
}