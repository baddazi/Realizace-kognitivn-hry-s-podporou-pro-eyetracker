using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
/**
 * Trida uchovava veskere uzivatelske nastaveni.
 */
public class SettingManager : MonoBehaviour
{
    public static int maximumOFLevel = 18;
    public static int levelToPlay = 4;

    public static int speedOfBall = 5;
    public static int speedOfPlatform = 5;

    public static bool enableCogGame = true;
    public static int difficultyOfCogGame = 2;
    public static int countOfCogMiniGame = 3;

    public static int percentOfBonus = 75;
    public static int countOfLive = 3;
    public static bool infinityLive = false;


    public static int percentOfBrick = 70;

    public static int typeOFInput = 0;

    public static bool isMindWaveConnect = false;
    public static bool trackMindActivity = false;

    public static void addLevel()
    {
        levelToPlay++;
        if (levelToPlay - 1 == maximumOFLevel)
            levelToPlay = 0;
    }

    public static void settDifficultyOFGame(int dif)
    {
        switch (dif)
        {
            case 1:
                speedOfBall = 2;
                speedOfPlatform = 5;
                break;
            case 2:
                speedOfBall = 3;
                speedOfPlatform = 5;
                break;

            case 3:
                speedOfBall = 4;
                speedOfPlatform = 5;
                break;

            case 4:
                speedOfBall = 5;
                speedOfPlatform = 5;
                break;

            case 5:
                speedOfBall = 6;
                speedOfPlatform = 6;
                break;

            case 6:
                speedOfBall = 7;
                speedOfPlatform = 7;
                break;

            case 7:
                speedOfBall = 8;
                speedOfPlatform = 8;
                break;

            case 8:
                speedOfBall = 9;
                speedOfPlatform = 9;
                break;

            case 9:
                speedOfBall = 10;
                speedOfPlatform = 10;
                break;

            case 10:
                speedOfBall = 11;
                speedOfPlatform = 11;
                break;
        }
    }

    public static int getDifficultyOFGame(int SpeedofBall)
    {
        switch (SpeedofBall-1)
        {
            case 1:
                return 1;
            case 2:
                return 2;

            case 3:
                return 3;

            case 4:
                return 4;

            case 5:
                return 5;

            case 6:
                return 6;

            case 7:
                return 7;

            case 8:
                return 8;

            case 9:
                return 9;

            case 10:
                return 10;
        }

        return 1;
    }
}