using System;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;
using Tobii.Gaming;
using System.Net.Sockets;
/**
 * Trida slouzi pro zpracovani vstupu
 *
 * @autor David Zaruba
 */

public class InputManager1 : MonoBehaviour
{
    [NotNull] public static InputManager1 instance;

    [SerializeField] private InputType type = InputType.Mouse;
    [SerializeField] private Camera cam;
    private bool isStoped = false;

    public float positionX;
    private float eyeDirSmoothXVelocity = 0f;
    public float positionY;
    public static int sceneParametr = 0;
    public int attention = 0;
    public int meditation = 0;

    private MindwaveController mwController;
    private ConnectionStatus connectionStatus;


  /**
   * Event funkce spustena pri vytvareni instance. Zajistuje pripojeni MindWave Mobile
   */
    void Start()
    {
        if (mwController == null)
        {
            mwController = GetComponent<MindwaveController>();
        }

        bindMindwaveConEvents();
   
    }
/**
 * Nastavuje, ktere funcke budou odposlouchavat akce MindWave Mobile
 */
    private void bindMindwaveConEvents()
    {
        mwController.OnUpdateMindwaveData += onUpdateMindwaveData;
        mwController.OnConnectMindwave += onNeuroSkyConnected;
        mwController.OnDisconnectMindwave += onNeroSkyDisconnected;
        mwController.OnConnectionTimeout += onNeuroSkyConnectionTimeOut;
    }
/**
 * Stara se o pripojeni MindWave Mobile
 */
    public void ConnectNeuroSky()
    {
        if (!connectionStatus)
            return;

        connectionStatus.Connect();
        try
        {
            mwController.Connect();
        }
        catch (Exception e)
        {
            connectionStatus.ConnectionException();
        }
    }

/**
 * Funkce slouzi pro aktualiuaci dat z MindWave
 */
    private void onUpdateMindwaveData(MindwaveDataModel data)
    {
        attention = data.eSense.attention;
        meditation = data.eSense.meditation;
    }
/**
 * Funkce slouzi pro pripojeni MindWave
 */
    private void onNeuroSkyConnected()
    {
        connectionStatus?.Connected();
        SettingManager.isMindWaveConnect = true;
    }
/**
 * Funkce slouzi pro odpojeni  MindWave
 */
    private void onNeroSkyDisconnected()
    {
        connectionStatus?.Disconnect();
        SettingManager.isMindWaveConnect = false;
    }
/**
 * Funkce slouzi pokud trva prihlaseni MindWave prilis dlouo
 */
    private void onNeuroSkyConnectionTimeOut()
    {
        connectionStatus?.ConnectionTimeOut();
        SettingManager.isMindWaveConnect = false;
    }

    public bool IsStoped => isStoped;
/*
 * Event funkce spousten kazdy frame. Zjistuje jaky je nastaveny vstup a aktualizuje pozici ovlasdaciho prvku
 */
    void Update()
    {
       
       
        typeOfInput();
        position();
    }

    /**
     * Nastavuje, jaky je zvoleny typ ovladani
     */
    private void typeOfInput()
    {
        InputType temp = type;
        switch (SettingManager.typeOFInput)
        {
            case 0:
                type = InputType.Mouse;
                break;

            case 1:
                type = InputType.Arrow;
                break;
            case 2:
                type = InputType.Eye;
                break;
        }

        if (!temp.Equals(type))
        {
            positionX = 0;
        }
    }
/**
 * Zjisujea uchovava si kameru dane sceny
 */
    public void setCamera()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    public Camera Cam
    {
        get => cam;
        set => cam = value;
    }
    /**
     * Funcke slouzi pro akutalizace pozice ovladaci zarizeni
     */

    public void position()
    {
        if (cam == null)
            setCamera();


        switch (type)
        {
            case InputType.Mouse:
                mouseControl();
                break;
            case InputType.Eye:
                eyeControl();
                break;
            case InputType.Arrow:
                arrowControl();
                break;
        }
    }
/**
 * Funkce obstarava ovladani pomoci mysi. 
 */
    private void mouseControl()
    {
        isStoped = false;
        positionX = cam.ScreenToWorldPoint(Input.mousePosition).x;
        positionY = cam.ScreenToWorldPoint(Input.mousePosition).y;
    }
/*
 * Funkce se stara ovladani pomoci klavesnice
 */
    private void arrowControl()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            positionX = getCamWidth() / 2;
            isStoped = false;
            return;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isStoped = true;
            return;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isStoped = true;
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            positionX = (getCamWidth() / 2) * -1;
            isStoped = false;
            return;
        }


        // isStoped = true; 
    }
/**
 * Funkce obstarava ovladani pomic eyetrackeru
 */
    private void eyeControl()
    {
      
        isStoped = false;
        positionX = TobiiAPI.GetGazePoint().Viewport.x * getCamWidth() - getCamWidth() / 2;
    
        positionY = TobiiAPI.GetGazePoint().Viewport.y * 2f * cam.orthographicSize - cam.orthographicSize;
    }
/**
 * Funkce vrci sirku kamery
 */
    private float getCamWidth()
    {
        return (cam.aspect * 2f * cam.orthographicSize);
    }

/**
 * Funkce je spustena pri znovu aktivovani objektu. Stara se kontrolu stagvum MindWave Mobile
 */
    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        connectionStatus = FindObjectOfType<ConnectionStatus>();

        if (mwController && mwController.IsConnected)
            connectionStatus.Connected();

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
/**
 *
 * Funkce kontroluje stav MinWave mobile
 */

    public bool checkStatus()
    {
        if (mwController && mwController.IsConnected)
            return true;
        return false;
    }
}
/*
 *Enum pro typ ovladani
 * 
 */

public enum InputType
{
    Eye,
    Arrow,
    Mouse
}