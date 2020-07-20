using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/**
 * Trida LiveManager se stara o vyobrazeni zivotu ve hre
 */
public class LiveManager : MonoBehaviour
{
    private int live = 5;
    [SerializeField] private GameObject obLive;
    private float positionX = 7.5f;
    private float positionY = -4.5f;
    private float spaceX = 1;
    private GameObject[] liveField;

    private void Start()
    {
        liveField = null;
    }

    public int Live
    {
        get => live;
        set => live = value;
    }

    public GameObject ObLive
    {
        get => obLive;
        set => obLive = value;
    }

/**
 * Funcke zajistuje zobrazeni zivotu
 */
    public void showLive()

    {
        if (liveField != null)
            destroyLive();

        if (live == 1 ||live == 6)
            return;

        liveField = new GameObject[live];

        float tempX = positionX;


        for (int i = 0; i < live - 1; i++)
        {
            var instance = Instantiate<GameObject>(obLive);
            instance.gameObject.transform.position = new Vector3(tempX, positionY, 0);
            liveField[i] = instance;

            tempX = tempX - spaceX;
        }
    }
/*
 *
 * Funkce se stara o smazani vyobrazeneho zivota
 */
    private void destroyLive()
    {
        for (int i = 0; i < liveField.Length; i++)
        {
            if (liveField[i] == null)
                return;
            Destroy(liveField[i]);
        }

        liveField = null;
    }
/**
 *
 * Funkce slouzi pro ubrani jednoho zivota a zovnu vyobvrazeni noveho porctu zivotu
 */
    public void increseLive()
    {
        live--;
        showLive();
    }
}