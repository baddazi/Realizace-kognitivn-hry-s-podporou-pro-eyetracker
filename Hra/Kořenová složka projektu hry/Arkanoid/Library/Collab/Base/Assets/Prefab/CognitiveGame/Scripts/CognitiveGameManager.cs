using System.Collections;
using System.Collections.Generic;

using TMPro;
using Tobii.Gaming.Internal;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CognitiveGameManager : MonoBehaviour
{
    public static int countOfLevel = 7;
   
   
    

    [SerializeField] private int dificult = 1;
    private static int  coutOfGame = 9;
    private bool isLeftTrue;
    private int rightAnswers = 0;

    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI left;
    [SerializeField] private TextMeshProUGUI right;


  

    private ACogGame a1 = new Calc1();
    private ACogGame a2 = new Even1();
    private ACogGame a3 = new Sequence();
    private ACogGame a4 = new Equation();
    private ACogGame a5 = new Calc();
    private ACogGame a6 = new ColorTask();
    private ACogGame a7 = new DayMonthYear();
  

    private ACogGame[] field = new ACogGame[coutOfGame];

    void Start()
    {
        
       
        field[0] = a7;
       
        /* field[1] = game2.GetComponent<ICogGame>();
         field[2] = game3.GetComponent<ICogGame>();
         field[3] = game4.GetComponent<ICogGame>();
         field[4] = game5.GetComponent<ICogGame>();
        field[5] = game6.GetComponent<ICogGame>();
         field[6] = game7.GetComponent<ICogGame>();
         field[7] = game8.GetComponent<ICogGame>();
        field[8] = game9.GetComponent<ICogGame>();*/
         
        
        chooseGame();
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void chooseGame()
    {

       // ICogGame[] correct = chooseCorrectGame();
       // int r = new Random().Next(correct.Length);

       ACogGame[] correct = new ACogGame[1];
       correct[0] = field[0];
       int r = 0;
       correct[0].isLevel(2);
       
      
        correct[r].setSuff(left,right,mainText,question);
        correct[r].createGame(dificult);
        
            
        isLeftTrue=correct[r].isLeftTrue();
        
    }

    private ACogGame[] chooseCorrectGame()
    {
        ACogGame [] correct;
        int k=0;
        for (int i = 0; i < coutOfGame; i++)
        {

            if (field[i].isLevel(dificult))
                k++;
        }

        correct = new ACogGame[k];
        for (int i = 0; i < coutOfGame; i++)
        {

            if (field[i].isLevel(dificult))
                correct[k] = field[i];
        }


        return correct;
    }

    public void pressLeft()
         {

             if (isLeftTrue)
             {
                 print("True");
                 rightAnswer();
             }
             else
             {
                 print("Wrong");
             }
         }
    
    public void pressRight()
    {
        if (!isLeftTrue)
        {
            print("True");
            rightAnswer();
        }
        else
        {
            print("Wrong");
        }
    }

    private void rightAnswer()
    {

        if (rightAnswers < 10)
        {
            rightAnswers++;
            chooseGame();

        }
        
    }


}




