using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

/**
 *Trida obsahuje hlavni logiku hry
 *
 * @autor David Zaruba
 * 
 */
public class gameManager1 : MonoBehaviour
{
    /*
     * Reference na objetky, ktere jsou pouzivane ve tride
     * 
     */
    [SerializeField] private GameObject platform;

    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject brickGreen;

    [SerializeField] private GameObject brickBlue;

    [SerializeField] private GameObject brickGold;

    [SerializeField] private GameObject brickGray;

    [SerializeField] private GameObject brickPurple;

    [SerializeField] private GameObject brickRed;

    [SerializeField] private GameObject brickWhite;

    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject bonus;

    [SerializeField] private GameObject BonusManager;

    [SerializeField] private int percentOfbonus = 40;

    [SerializeField] private int countOfLive = 4;

    [SerializeField] private GameObject LiveManager;

    [SerializeField] private GameObject LivePicture;

    [SerializeField] private GameObject prefBall;

    [SerializeField] private int percentOfbrick = 30;

    [SerializeField] private bool randomMap = false;

    [SerializeField] private bool replenishmentOfMap = false;

    [SerializeField] private Canvas pauseMenu;

    [SerializeField] private Canvas winnerOverMenu;

    [SerializeField] private GameObject winnerOver;

    [SerializeField] private GameObject time;

    [SerializeField] private GameObject pauseB;

    [SerializeField] private GameObject CountDownText;

    [SerializeField] private int speedOfBall = 5;

    [SerializeField] private int speedOfPlatform = 5;

    [SerializeField] private Canvas CognitveMinigame;

    /**
     * Textove pole pro vypis vystupnich dat
     */
    [SerializeField] private TextMeshProUGUI colectData;
    [SerializeField] private TextMeshProUGUI colectData2;
    [SerializeField] private TextMeshProUGUI colectData3;

   /**
    * Objekty s urovnemi hry
    */
    [SerializeField] private GameObject Level1;
    [SerializeField] private GameObject Level2;
    [SerializeField] private GameObject Level3;
    [SerializeField] private GameObject Level4;
    [SerializeField] private GameObject Level5;
    [SerializeField] private GameObject Level6;
    [SerializeField] private GameObject Level7;
    [SerializeField] private GameObject Level8;
    [SerializeField] private GameObject Level9;
    [SerializeField] private GameObject Level10;
    [SerializeField] private GameObject Level11;
    [SerializeField] private GameObject Level12;
    [SerializeField] private GameObject Level13;
    [SerializeField] private GameObject Level14;
    [SerializeField] private GameObject Level15;
    [SerializeField] private GameObject Level16;
    [SerializeField] private GameObject Level17;
    [SerializeField] private GameObject Level18;

  /**
   * Textove pole pro vypis casu a vytiztvi nebo porazky
   */
    private TextMeshProUGUI timeText;
    private TextMeshProUGUI winnerOverText;


    private Random rand = new Random();

    private int tempTime;

    private bool isPaused = false;
    private bool isCountDown = true;

    private float timeInterval = 1f;
    private int percentOfReplishment = 30;
    private EnumBrickType[,] instationField;

    private const float WidthSpace = 0.1517f;
    private const float WidthBrick = 1.278f;
    private const float MinWidth = -7.939f;

    private const float HeightSpace = 0.2095f;
    private const float HeightBrick = 0.4828f;
    private const float MaxHeight = 1.5f;

    private const string konecHry = "Konec hry";
    private const string vyhra = "Výhra";


    private int startTime = 0;
    private int lastTime;
    private int pauseTime;
    private int countDownTime;
    private bool displayTime = false;
    private bool isEnableCogGame = true;
    private int cogMiniGameTime = 0;
    private String cogMiniGameTimeToDisplay = "";
    private int countOFDeath = 0;

    private int countOfAttentionNumber = 0;
    private int sumOfAttention = 0;
    private int minAttention = 100;
    private int maxAttention = 0;

    private int countOfMeditationNumber = 0;
    private int sumOfMeditation = 0;
    private int minMeditation = 100;
    private int maxMeditation = 0;

/**
 * Event funkce spustena pri vytvareni objekty. Zavola funkci init().
 */
    void Start()
    {
        init();
    }
 /**
  *
  * Funkce volana pozastavujicim tlacitkem. Zajisit pozastaveni hry i pocitani casu
  */
    public void pauseButton()
    {
        SettingManager.trackMindActivity = false;
        if (isEnableCogGame)
            disableCogGame(true);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        displayTime = false;
        pauseTime = nowTime();
    }
/**
 * Funkce volana pro pokracovani ve hre.
 */
    public void resume()
    {
        pauseMenu.gameObject.SetActive(false);
        if (isEnableCogGame)
        {
            cogMiniGameTime = cogMiniGameTime + (nowTime() - pauseTime);
            initCogMinigame();
            return;
        }


        Time.timeScale = 1;
        startTime = startTime + (nowTime() - pauseTime);
        isCountDown = true;
        displayTime = true;
    }
/**
 * Deaktivuje kognitivni minihry
 * 
 */
    public void disableCogGame(bool isFromPaused)
    {
        CognitveMinigame.gameObject.SetActive(false);

        if (!isFromPaused)
        {
            isEnableCogGame = false;
            cogMiniGameTimeToDisplay = getColectTime(nowTime() - cogMiniGameTime);
        }
    }
    
    /***
     * Event funkce spustena pri kazdem framu. Zajistuje pauznuti hry, spusteni casomiry,
     * volani funkce pro sber dat z MiondWave Mobile a vypis casomiry.
     */
    void Update()
    {
        if (isEnableCogGame)
        {
            return;
        }


        if (isPaused)
        {
            SettingManager.trackMindActivity = false;
            if (System.DateTime.Now.Second + System.DateTime.Now.Minute * 60 >= tempTime + 5)
            {
                isPaused = false;
                resume();
            }
        }

        if (!isCountDown && startTime == 0)
        {
            lastTime = startTime = nowTime();
        }


        if (SettingManager.trackMindActivity = true && SettingManager.isMindWaveConnect)
            updateMindWaveData();

        if (replenishmentOfMap && displayTime && lastTime < nowTime() && !isCountDown)
        {
            timeText.text = getTime(startTime);
            lastTime = nowTime();
        }

        if (isCountDown)
        {
            countDowm();
        }
    }
/**
 * Funkce pro ukladani dat z MindWave Neurosky
 */
    private void updateMindWaveData()
    {
        countOfAttentionNumber++;
        countOfMeditationNumber++;

        sumOfAttention += InputManager1.instance.attention;
        sumOfMeditation += InputManager1.instance.meditation;

        if (minAttention > InputManager1.instance.attention)
            minAttention = InputManager1.instance.attention;

        if (minMeditation > InputManager1.instance.meditation)
            minMeditation = InputManager1.instance.meditation;

        if (maxAttention < InputManager1.instance.attention)
            maxAttention = InputManager1.instance.attention;

        if (maxMeditation < InputManager1.instance.meditation)
            maxMeditation = InputManager1.instance.meditation;
    }
/**
 * Funkce volana po zniceni cihlicky pro zjisteni vyhry nebo doplneni mapy u hry Preziti
 */
    public void brickDestroyed(int[] position)
    {
        instationField[position[0], position[1]] = EnumBrickType.empty;
        checkWin();
        if (replenishmentOfMap)
            checkReplishment();
    }
/**
 * Funkce zjistuje, zdali nastala vyhra
 */
    private void checkWin()
    {
        if (countDestroyedBrick() == 0)
        {
            winner();
        }
    }
/**
 *
 * Funce je volana pri vyhre a zajistuje pozastavei hry a vpasani vsech dat
 */
    private void winner()
    {
        SettingManager.trackMindActivity = false;
        createCollectedData();
        winnerOverText.text = vyhra;
        winnerOverMenu.gameObject.SetActive(true);
        end();
        pauseB.SetActive(false);
    }
/**
 * Po skonceni hry zajistuje tato funkce vypsanio vsech mereneych dat
 */
    private void createCollectedData()
    {
        String countOfLive;

        if (SettingManager.countOfLive < 6)
            countOfLive = SettingManager.countOfLive + "";
        else
        {
            countOfLive = "neomezeně";
        }

        String dataCogGame;

        if (SettingManager.enableCogGame)
            dataCogGame = "Kognitivní minihry: \nČas miniher: " + cogMiniGameTimeToDisplay +
                          "\nPočet hraných miniher: " + SettingManager.countOfCogMiniGame +
                          "\nPočet špatných odpovědí: " + CognitveMinigame
                              .GetComponent<CognitiveGameManager>().getCountOfWrongAns();
        else
        {
            dataCogGame = "Kognitivní minihry jsou deaktivované";
        }

        String dataGame = "Hraní hry: \nČas hry: " + getColectTime(nowTime() - startTime) + "\nPočet životů: " +
                          countOfLive + " \nPočet úmrtí: " + countOFDeath;
        String mindwave;
        if (SettingManager.isMindWaveConnect)
        {
            mindwave = "Naměřená data z Neurosky: \nPrůměrná pozornost: " +
                       (sumOfAttention / countOfAttentionNumber) + "% \nNejnižší pozornost: " +
                       minAttention + "% \nNejvyšší pozornost: " + maxAttention +
                       "% \nPrůměrná relaxace: " + (sumOfMeditation / countOfMeditationNumber) +
                       "% \nNejnižší relaxace: " + minMeditation + "% \nNejvyšší relaxace: " +
                       maxMeditation + "%";
        }
        else
        {
            mindwave = " Neurosky nebyla připojena";
        }


        colectData.SetText(dataCogGame);
        colectData2.SetText(dataGame);
        colectData3.SetText(mindwave);
    }
    /**
     *
     * Funkce je volana pokud kulicka nebyla zachycena. Dunkce zjistuje, jestli existuje jina kulicka, jestli neni jiz posledni zivoat a popripade zavola
     * funkce pro ukonceni hry.
     */

    public void hitBall()
    {
        BonusManager br = BonusManager.GetComponent<BonusManager>();
        LiveManager lv = LiveManager.GetComponent<LiveManager>();
        if (!br.IsexistOntherBall())
        {
            countOFDeath++;
            if (lv.Live != 6)
                lv.increseLive();


            if (lv.Live != 0)
            {
                basicDeath();
            }
            else
            {
                gameOver();
                end();
            }
        }
    }
/**
 * Funkce slouzi pro nezachyceni posledni micku, ale hrac ma jeste dostatek zivoatu a hra muze pokracovat.
 */
    private void basicDeath()
    {
        SettingManager.trackMindActivity = false;
        BonusManager.GetComponent<BonusManager>().stopBonus();
        resetPosition();
       

        isCountDown = true;
    }
/**
 * Funkce slouzi pro konec hry, kdy uzivatli jiz nezbyl zadny zivoat
 */
    private void gameOver()
    {
        SettingManager.trackMindActivity = false;
        createCollectedData();
        winnerOverText.text = konecHry;
        winnerOverMenu.gameObject.SetActive(true);
        end();
        pauseB.SetActive(false);
    }
/**
 * Funcke je volana pro zastaveni hry a zruseni vypisu casu
 */
    private void end()
    {
        Time.timeScale = 0;
        displayTime = false;
    }
/**
 * Funkice slouzi pro vraceni pozice platformy a micku do streu obrazku.
 */
    private void resetPosition()
    {
        platform.transform.position = new Vector3(0.04f, -3.58f, 0);
        var temp = Instantiate<GameObject>(prefBall);
        temp.GetComponent<BallControler>().Speed = speedOfBall;
        BonusManager.GetComponent<BonusManager>().Ball = temp;
        temp.GetComponent<BallControler>().Gm = GetComponent<gameManager1>();
        temp.transform.position = new Vector3(0.01f, -2.53f, 0);
        temp.GetComponent<BallControler>().initVelocity();
    }
/**
 * Funkce se postara o zavolani funkci pro vytvoreni herniho pole. 
 */

    private void initField()
    {
        if (randomMap || replenishmentOfMap)
        {
            if (replenishmentOfMap)
                createReplishmentField();
            else

                createRandomField();
        }
        else
        {
            loadField();
            var temp = loadField();
            instationField = temp.getLevelField();
        }
    }
    
    /**
     * Nacteni vsech levelu do pole
     */
    private ILevel loadField()
    {
        ILevel[] lev = new ILevel[SettingManager.maximumOFLevel];

        lev[0] = Level1.GetComponent<ILevel>();
        lev[1] = Level2.GetComponent<ILevel>();
        lev[2] = Level3.GetComponent<ILevel>();
        lev[3] = Level4.GetComponent<ILevel>();
        lev[4] = Level5.GetComponent<ILevel>();
        lev[5] = Level6.GetComponent<ILevel>();
        lev[6] = Level7.GetComponent<ILevel>();
        lev[7] = Level8.GetComponent<ILevel>();
        lev[8] = Level9.GetComponent<ILevel>();
        lev[9] = Level10.GetComponent<ILevel>();
        lev[10] = Level11.GetComponent<ILevel>();
        lev[11] = Level12.GetComponent<ILevel>();
        lev[12] = Level13.GetComponent<ILevel>();
        lev[13] = Level14.GetComponent<ILevel>();
        lev[14] = Level15.GetComponent<ILevel>();
        lev[15] = Level16.GetComponent<ILevel>();
        lev[16] = Level17.GetComponent<ILevel>();
        lev[17] = Level18.GetComponent<ILevel>();


        return lev[SettingManager.levelToPlay];
    }
/**
 * Funkce slouzi pro zavolani vsech potrebnych funci, ktere nastavy vsechny potrebne veci pred zavatkem hry 
 */
    private void init()
    {
        SettingManager.trackMindActivity = false;
        initCogMinigame();
        initSetting();
        prepareUI();
        prepareOtherManager();
        initField();
        prepareLiveManager();
        createMap();
        isCountDown = true;
    }
/**
 * Funcke slouzi pro vytvoreni cognitivnich her
 */
    private void initCogMinigame()
    {
        if (!SettingManager.enableCogGame)
        {
            isEnableCogGame = false;
            return;
        }

        cogMiniGameTime = nowTime();
        Time.timeScale = 0;
        CognitveMinigame.gameObject.GetComponent<CognitiveGameManager>().setGameManager(this);
        CognitveMinigame.gameObject.SetActive(true);
        isEnableCogGame = true;
    }
/**
 * Funkce slouti pro nastaveni vychozich hodnot ostatnim objektum
 */
    private void initSetting()
    {
        percentOfbonus = SettingManager.percentOfBonus;
        percentOfbrick = SettingManager.percentOfBrick;

        if (SettingManager.infinityLive && !replenishmentOfMap)
            countOfLive = 6;
        else
            countOfLive = SettingManager.countOfLive;

        speedOfBall = SettingManager.speedOfBall;
        speedOfPlatform = SettingManager.speedOfPlatform;

        platform.GetComponent<PlatfomrControler>().Speed = speedOfPlatform;
        BonusManager.GetComponent<BonusManager>().SpeedOfBall = speedOfBall;
    }

    /**
     *
     * Funkce slouzi pri pripraceni ostatnich ridicich trid
     */
    private void prepareOtherManager()
    {
        var bl = ball.GetComponent<BallControler>();
        bl.Gm = GetComponent<gameManager1>();
        bl.Speed = speedOfBall;
        BonusManager.GetComponent<BonusManager>().GameManager = this.gameObject;
    }
/**
 *Funkce slouzi pro zjisteni, zdali se jedna o hru preziti a pripadno zarizeni vypsani casu.
 * 
 */
    private void prepareUI()
    {
        if (replenishmentOfMap)
        {
            displayTime = true;
            timeText = time.GetComponent<TextMeshProUGUI>();
            timeText.gameObject.SetActive(true);
        }

        winnerOverText = winnerOver.GetComponent<TextMeshProUGUI>();
    }
/**
 * Slouzi pro pripravu LiveManageru
 */
    private void prepareLiveManager()
    {
        LiveManager lv = LiveManager.GetComponent<LiveManager>();
        lv.ObLive = LivePicture;
        lv.Live = countOfLive;
        lv.showLive();
    }
/**
 *
 * Slouzi pro zjisteni aktualni casu ve vterinach
 */
    private int nowTime()
    {
        return System.DateTime.Now.Second + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Hour * 3600 +
               DateTime.Now.DayOfYear * 3600 * 24;
    }
/**
 * Funkce je urcena pro zjisteni, kolik je ve hre znicitelnych cihlicek
 */
    private int countDestroyedBrick()
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (instationField[i, j] != EnumBrickType.empty && instationField[i, j] != EnumBrickType.gold)
                    count++;
            }
        }

        return count;
    }
/**
 * Funkce slouzi pro vytvareni nahodnho pole cilicek
 */
    private void createMap()
    {
        for (int i = 4; i >= 0; i--)
        {
            for (int j = 0; j < 11; j++)
            {
                createSingeInstation(i, j);
            }
        }
    }
    /**
     * Funcke slouzi pro nahodnemu urceni, zdali je bonus v zavislosti na procentulani pravdepodobmosti
     */

    private bool isBonus()
    {
        int temp = 10 - percentOfbonus / 10;
        if (rand.Next(temp) == 0)
            return true;

        return false;
    }

    /**
     * Funkce slouzi pro vytvoreni nahodne cihlicky s moznym bonusem
     */
    private GameObject randomBonus()
    {
        int temp = rand.Next(5);

        switch (temp)
        {
            case 0: return Instantiate<GameObject>(brickGreen);
            case 1: return Instantiate<GameObject>(brickBlue);
            case 2: return Instantiate<GameObject>(brickRed);
            case 3: return Instantiate<GameObject>(brickWhite);
            case 4: return Instantiate<GameObject>(brickPurple);
        }

        return null;
    }
/**
 * Funkce slouzi pro vytvoreni nahodne pole Cihlicek
 */
    private void createRandomField()
    {
        int percent = 10 - percentOfbrick / 10;
        instationField = new EnumBrickType[5, 11];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (rand.Next(percent) == 0)
                    createBrick(i, j);
                else
                    instationField[i, j] = EnumBrickType.empty;
            }
        }
    }
/**
 * Funcke vytvari konkretni cihlicku na pozici
 */
    private void createBrick(int i, int j)
    {
        if (goldPosition(i, j))
        {
            instationField[i, j] = EnumBrickType.gold;
        }
        else
        {
            if (rand.Next(6) == 0)
            {
                instationField[i, j] = EnumBrickType.gray;
            }
            else
            {
                instationField[i, j] = EnumBrickType.randomBonus;
            }
        }
    }
/**
 * Funkce urcije, zdali zlata fcihlicka muze na urcite pozici byt. 
 */
    private bool goldPosition(int i, int j)
    {
        if ((j == 0 | i == 0 | j == 10) && rand.Next(2) == 0)
            if ((i == 1 && j == 0) || i == 0 && j == 1 || i == 1 && j == 10)
                return false;
            else
                return true;


        return false;
    }
/**
 * Vytvari nahodne pole cihlicek, ktere bule plne zaplneno
 */
    private void createReplishmentField()
    {
        instationField = new EnumBrickType[5, 11];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                createBrick(i, j);
            }
        }
    }

    /**
     * Slouzi k zjisteni, zdali cihlicky nejsou pod stanovenou hodnotou a pokud ano zavola funkci pro doplneni pole
     */
    private void checkReplishment()
    {
        if (countDestroyedBrick() < (5 * 11) * percentOfReplishment / 100)
        {
            replishBrick();
        }
    }
/**
 * Funkce slouzi pro doplneni cihlicek
 */
    private void replishBrick()
    {
        int fill = 5;

        int count = countOfEmptyPlace();
        int[,] fieldOfEmpty = new int[count, 2];
        int k = 0;
        int s = 0;


        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (instationField[i, j] == EnumBrickType.empty)
                {
                    fieldOfEmpty[k, 0] = i;
                    fieldOfEmpty[k, 1] = j;
                    k++;
                }
            }
        }


        while (s <= fill)
        {
            int pos = rand.Next(count);

            if (fieldOfEmpty[pos, 0] != -1)
            {
                createBrick(fieldOfEmpty[pos, 0], fieldOfEmpty[pos, 1]);
                createSingeInstation(fieldOfEmpty[pos, 0], fieldOfEmpty[pos, 1]);
                s++;
            }

            fieldOfEmpty[pos, 0] = -1;
        }
    }
/**
 * Funkce pocita prazna mista v hernim poli
 */
    private int countOfEmptyPlace()
    {
        int count = 0;
        ;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (instationField[i, j] == EnumBrickType.empty)
                    count++;
            }
        }

        return count;
    }

/**
 * Funkce vytvarri konkretni instaci cihlicky na urcenem miste
 */
    private void createSingeInstation(int i, int j)
    {
        float positionX = MinWidth + WidthSpace + WidthBrick / 2 + j * (WidthSpace + WidthBrick);
        float positionY = MaxHeight + recalculateI(i) * (HeightBrick + HeightSpace);


        GameObject instance = null;
        switch (instationField[i, j])
        {
            case EnumBrickType.green:
                instance = Instantiate<GameObject>(brickGreen);
                break;
            case EnumBrickType.blue:
                instance = Instantiate<GameObject>(brickBlue);
                break;
            case EnumBrickType.red:
                instance = Instantiate<GameObject>(brickRed);
                break;
            case EnumBrickType.white:
                instance = Instantiate<GameObject>(brickWhite);
                break;
            case EnumBrickType.purple:
                instance = Instantiate<GameObject>(brickPurple);
                break;
            case EnumBrickType.randomBonus:
                instance = randomBonus();
                break;
            case EnumBrickType.gray:
                instance = Instantiate<GameObject>(brickGray);
                break;
            case EnumBrickType.gold:
                instance = Instantiate<GameObject>(brickGold);
                break;
        }

        if (instationField[i, j] != EnumBrickType.empty)
        {
            instance.transform.position = new Vector3(positionX, positionY, 0);

            if (instationField[i, j] != EnumBrickType.gray && instationField[i, j] != EnumBrickType.gold)
            {
                brickBonus br = instance.GetComponent<brickBonus>();
                if (isBonus())
                {
                    br.Bonus = bonus;
                    br.setBonus();
                }


                br.BonusManager = BonusManager;
                int[] temp = br.PositionFiled;
                temp[0] = i;
                temp[1] = j;
                br.PositionFiled = temp;
            }
        }

        if (instationField[i, j] == EnumBrickType.gray)
        {
            var temp = instance.GetComponent<brickGray>();
            temp.BonusManager1 = BonusManager;
            int[] temp1 = temp.PositionField;
            temp1[0] = i;
            temp1[1] = j;
            temp.PositionField = temp1;
        }
    }
/**
 * Slouzi pro prepocet pozici v poli cihlicek
 */
    private int recalculateI(int i)
    {
        switch (i)
        {
            case 0: return 4;
            case 1: return 3;
            case 2: return 2;
            case 3: return 1;
            case 4: return 0;
        }

        return 0;
    }
/**
 * Funcke je urcena pro vytvoreni casu k vypisu
 */
    private string getTime(int time)
    {
        return recalculateTime(nowTime() - time);
    }
/**
 * Funkce vytvari text daneho casu
 */
    private string recalculateTime(int time)
    {
        string displaytime = "";
        int temp = 0;

        if (time >= 3600)
        {
            temp = time / 3600;
            displaytime = displaytime + displayNumbers(temp);
            time = time - temp * 3600;
        }

        if (time >= 60)
        {
            if (displaytime.Length > 0)
                displaytime = displaytime + ":";
            temp = time / 60;
            displaytime = displaytime + displayNumbers(temp);
            time = time - temp * 60;
        }

        if (temp > 0 && displaytime.Length > 0)
            displaytime = displaytime + ":";
        displaytime = displaytime + displayNumbers(time);


        return displaytime;
    }
/**
 * Funkce slouzi pro prevod casu pro vypis na konci hry
 */
    private String getColectTime(int time)
    {
        int hours = 0;
        int minut = 0;
        int sec = 0;

        String hodiny = "hodin";
        String vteriny = "vteřin";
        String minuty = "minut";

        String answ = "";

        int temp = 0;
        if (time >= 3600)
        {
            hours = time / 3600;
            temp = hours * 3600;
            time = time - temp;
        }

        if (time >= 60)
        {
            minut = time / 60;
            temp = minut * 60;
            time = time - temp;
        }

        sec = time;


        if (hours > 0)
        {
            hodiny = hodiny + getEndOfWord(hours);
            answ = answ + hours + " " + hodiny;
        }

        if (minut > 0)
        {
            if (answ.Length != 0)
                answ = answ + " ";
            minuty = minuty + getEndOfWord(minut);
            answ = answ + minut + " " + minuty;
        }

        if (sec > 0)
        {
            if (answ.Length != 0)
                answ = answ + " ";
            vteriny = vteriny + getEndOfWord(sec);
            answ = answ + sec + " " + vteriny;
        }

        return answ;
    }
/**
 * Stara se o spravne sklonovani slov
 */
    private String getEndOfWord(int countOfTime)
    {
        if (countOfTime == 1)
            return "a";
        if (countOfTime < 5)
            return "y";

        return "";
    }
/*
 * Funcke slouzi pro pridani nuly pred cisla mensi nez 10
 */
    private String displayNumbers(int time)
    {
        if (time < 10)
            return "0" + time;

        return "" + time;
    }
/*
 *
 * Funcke slouzi pro vytvoreni odpoctu pred startem hry.
 */
    private void countDowm()
    {
        if (countDownTime == 0)
            countDownTime = nowTime();

        Time.timeScale = 0;

        pauseB.SetActive(false);
        CountDownText.SetActive(true);
        TextMeshProUGUI temp = CountDownText.GetComponent<TextMeshProUGUI>();

        if (nowTime() - countDownTime < 1)
            temp.text = "3";
        if (nowTime() - countDownTime == 1)
            temp.text = "2";
        if (nowTime() - countDownTime == 2)
            temp.text = "1";
        if (nowTime() - countDownTime == 3)
        {
            CountDownText.SetActive(false);
            Time.timeScale = 1;
            if (startTime != 0)
                startTime = startTime + 3;

            isCountDown = false;
            countDownTime = 0;
            pauseB.SetActive(true);
            SettingManager.trackMindActivity = true;
        }
    }
}