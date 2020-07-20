using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
/**
 * Trida obstarava Bonusy. Stara se o jijich vytvoreni, hlida jejich dobu trvani a pote se postara i o jejich deaktivaci
 */

public class BonusManager : MonoBehaviour
{
    private int timeOfBonus = 5;

    [SerializeField] private GameObject platform;

    [SerializeField] private GameObject mainBall;

    [SerializeField] private GameObject gameManager;

    private GameObject ballTemp1;

    private GameObject ballTemp2;

    private int startTime = 0;

    private bool isBonus = false;

    private PlatfomrControler pl;

    private EnumBonusType currentBonus;

    private bool isPause = false;

    private int speedOfBall = 5;

    /**
     *Funkce slouzi pro zjisteni, zdali existuje dalsi kulicka ve hre.
     * 
     */

    public bool IsexistOntherBall()
    {
        if ((mainBall != null && mainBall.GetComponent<BallControler>().IsDestroyed == false) ||
            (ballTemp1 != null && ballTemp1.GetComponent<BallControler>().IsDestroyed == false) ||
            (ballTemp2 != null && ballTemp2.GetComponent<BallControler>().IsDestroyed == false))
            return true;

        return false;
    }
    /**
     *
     * Event funkce ktera je spustena pri vytvareni instance. Zde si pouze uklada rychlost kulicky.
     * 
     */

    private void Start()
    {
        mainBall.GetComponent<BallControler>().Speed = speedOfBall;
    }

    /**
     *Funkce pro zastaveni bonusu
     * 
     * 
     */
    public void stopBonus()
    {
        restore();
    }

    public int SpeedOfBall
    {
        get => speedOfBall;
        set => speedOfBall = value;
    }
    public GameObject Platform
    {
        get => platform;
        set => platform = value;
    }

    public GameObject Ball
    {
        get => mainBall;
        set => mainBall = value;
    }

    public int TimeOfBonus
    {
        get => timeOfBonus;
        set => timeOfBonus = value;
    }

    /**
     *Slouzi pro nastaveni bonusu. Ulozi si aktualni cas a podle typu bonusu zavola prislsnou funkci pro jeho aktivaci
     * 
     */
    public void setBonus(EnumBonusType type)
    {
        startTime = nowTime();

        if (isBonus && sameBonus(type))
            return;

        if (isBonus)
            restore();

        currentBonus = type;
        isBonus = true;

        switch (type)
        {
            case EnumBonusType.Red:
                fire();
                break;
            case EnumBonusType.Green:
                bals();
                break;
            case EnumBonusType.Blue:
                makeBigger();
                break;
        }
    }
    /**
     *Funkce urcuje, zdali je prave aktivovany bonus a nove zachyceny bonus stejny.
     * 
     */

    private bool sameBonus(EnumBonusType type)
    {
        if (type == currentBonus && type != EnumBonusType.Green)
            return true;
        return false;
    }

    /**
     *Funkce slouzi pro ulozeni skriptu platformControler
     * 
     */
    private void init()
    {
        pl = platform.GetComponent<PlatfomrControler>();
    }

    /**
     *Zajisti spusteni bonusu pro strelbu projektylu
     * 
     */
    private void fire()
    {
        if (pl == null)
            init();
        pl.addGun();
    }

    /**
     *Zajisti vytvoreni dalsich dvou kulicek a nstavi jim pocatecni hodnoty.
     * 
     */
    private void bals()
    {
        ballTemp1 = Instantiate<GameObject>(mainBall);
        ballTemp2 = Instantiate<GameObject>(mainBall);
        var bl = ballTemp1.GetComponent<BallControler>();
        bl.Gm = mainBall.GetComponent<BallControler>().Gm;
        bl.Speed = speedOfBall;
        
        var bl2= ballTemp2.GetComponent<BallControler>();
        bl2.Gm = mainBall.GetComponent<BallControler>().Gm;
        bl2.Speed = speedOfBall;

        ballTemp1.gameObject.transform.position =
            new Vector3(mainBall.transform.position.x + 0.2f, mainBall.transform.position.y, 0);

        ballTemp2.gameObject.transform.position =
            new Vector3(mainBall.transform.position.x - 0.2f, mainBall.transform.position.y, 0);
    }

    /**
     *Zajisti spusteni bonusu, ktery zvetsi platformu
     * 
     */
    private void makeBigger()
    {
        if (pl == null)
            init();
        pl.makeBigger();
    }

    /**
     *
     * Funkce zajisit spusteni spravne funkce, ktera deaktivuje bonus, podle aktulane spusteneho bonuusu
     */
    private void restore()
    {
        switch (currentBonus)
        {
            case EnumBonusType.Red:
                pl.restoreFire();
                break;
            case EnumBonusType.Blue:
                pl.restoreSize();
                break;
            case EnumBonusType.Green:
                restoreBall();
                break;
        }
    }

    public GameObject GameManager
    {
        get => gameManager;
        set => gameManager = value;
    }

    /**
     * Preda inforamci o zniceni cihlicky GameManageru
     */
    public void brickDestroyed(int[] position)
    {
        gameManager.GetComponent<gameManager1>().brickDestroyed(position);
    }

    /**
     *Funkce slouzi pro daktivaci bonusu se tremi kulickami. Funkce musi urcit, kterou kulicku ponechat a ktere znicit.
     * 
     */
    private void restoreBall()
    {
        BallControler main = null;
        BallControler ball1 = null;
        BallControler ball2 = null;

        if (mainBall != null)
            main = mainBall.GetComponent<BallControler>();

        if (ballTemp1 != null)
            ball1 = ballTemp1.GetComponent<BallControler>();

        if (ballTemp2 != null)
            ball2 = ballTemp2.GetComponent<BallControler>();


        if (mainBall == null || main.IsDestroyed)
        {
            if (ballTemp1 == null || ball1.IsDestroyed)
            {
                mainBall = ballTemp2;
                return;
            }

            if (ballTemp2 == null || ball2.IsDestroyed)
            {
                mainBall = ballTemp1;
                return;
            }

            if (isHigher(ballTemp1, ballTemp2))
            {
                mainBall = ballTemp1;
                Destroy(ballTemp2);
            }
            else
            {
                mainBall = ballTemp2;
                Destroy(ballTemp1);
            }

            return;
        }

        if (ballTemp1 == null || ball1.IsDestroyed)
        {
            if (ballTemp2 == null || ball2.IsDestroyed)
                return;

            if (isHigher(mainBall, ballTemp2))
                Destroy(ballTemp2);
            else
            {
                Destroy(mainBall);
                mainBall = ballTemp2;
            }


            return;
        }

        if (ballTemp2 == null || ball2.IsDestroyed)
        {
            if (isHigher(mainBall, ballTemp1))
                Destroy(ballTemp1);
            else
            {
                Destroy(mainBall);
                mainBall = ballTemp1;
            }


            return;
        }

        mainBall = highestBall();
    }

 /**
  *Funkce slouzi k rozhodnuti, ktera kulicka je vyse v hernim poli
  * 
  */
    private bool isHigher(GameObject ball1, GameObject ball2)
    {
        if (ball1.transform.position.y > ball2.transform.position.y)
            return true;
        return false;
    }
 
    /**
     * Funkce zjistii nejvyse umistenou kulicku v hernim poli
     * 
     */

    private GameObject highestBall()
    {
        if (isHigher(mainBall, ballTemp1) && isHigher(mainBall, ballTemp2))
        {
            Destroy(ballTemp1);
            Destroy(ballTemp2);
            return mainBall;
        }


        if (isHigher(ballTemp1, mainBall) && isHigher(ballTemp1, ballTemp2))
        {
            Destroy(mainBall);
            Destroy(ballTemp2);
            return ballTemp1;
        }

        Destroy(mainBall);
        Destroy(ballTemp1);
        return ballTemp2;
    }

    private int nowTime()
    {
        return System.DateTime.Now.Second + System.DateTime.Now.Minute * 60;
    }

 /**
  *
  *Event funkce spoustena v kazdem framu. Hlida jestli bonus jiz nevyprsel a popripade zajisti zavolani funkci pro jeho zruseni
  * 
  */
    void Update()
    {
        if (isBonus)
        {
            if (nowTime() >= startTime + timeOfBonus)
            {
                isBonus = false;
                restore();
            }
        }
    }
}