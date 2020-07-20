using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
/**
 * Trifa lsouzi pro ovladani platofrmy a realizaci bonusu spojewnych s platformou
 */
public class PlatfomrControler : MonoBehaviour
{
    [SerializeField] private Sprite longr;
    private float speed = 5;
    private bool bonus = false;
    private int timeOfBonus = 5;
    private int spentTime = 0;
    private Rigidbody2D movement;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Sprite def;
    [SerializeField] private GameObject bullet;
    private int buletTime;
    private int frequeciesOfBulet = 500;
    private bool isFire = false;
    private InputManager1 im;
    private float correction;

    /**
     * Funke spustena pri vytvareni objektu
     */
    void Start()
    {
        correction = speed/50;
        im = InputManager1.instance;
        movement = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        def = sprite.sprite;
    }

   

  

    public float Speed
    {
        get => speed;
        set => speed = value;
    }
/**
 * Event funkce spustena v kazdem framu. Zajistuje volani funkce pro pohyb platofrmy a take vytvoreni strileni z platofrmy pri danem bonusu.
 */
    void FixedUpdate()
    {
        move();
        if (isFire)
            fire();

        
    }
/**
 * Funcke slouzi pro pohyb platofrmy.
 */
    private void move()
    {
        if (im.IsStoped)
        {
            movement.velocity= new  Vector2(0, 0);
            return; 
        }
            
 
        Vector2 pom = new Vector2(im.positionX - transform.position.x, 0).normalized;
        if (Mathf.Abs(im.positionX - transform.position.x) < correction)
            movement.velocity = new Vector2(pom.x / 2, 0);
        else
            movement.velocity = new Vector2(pom.x * speed, 0);
    }

/**
 * Funkce zajisti prepdani itributu urcujiciho, jeslti je aktitovan bonus strileni projektilu
 */
    public void restoreFire()
    {
        isFire = false;
    }
    /**
     * Funkce vraci velikost pltaformy na puvodni
     */

    public void restoreSize()
    {
        sprite.sprite = def;
        collider.size = sprite.sprite.bounds.size;
    }

/**
 *
 * Funcke zvetsuje platformu
 */
    public void makeBigger()
    {
        sprite.sprite = longr;
        collider.size = sprite.sprite.bounds.size;
    }
    
/**
 * Funkce zaridi strileni projektilu
 */
    public void addGun()
    {
        fireBullet();
        isFire = true;
        buletTime = System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000;
    }
/**
 * Funke  kontorouje cas a ve spravne intervalu necha vystreli projektily.
 */
    private void fire()
    {
        if (System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000 - buletTime > frequeciesOfBulet)
        {
            fireBullet();
            buletTime = System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000;
        }
    }

    /**
     * Zajisti vystreleni dvou projektilu
     */
    private void fireBullet()
    {
        var ins = Instantiate<GameObject>(bullet);
        float x = transform.position.x;
        float y = transform.position.y;
        float y1 = ins.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        float tempr = y1 / 2 + y + def.bounds.size.y / 2;

        ins.transform.position = new Vector3(x + def.bounds.size.x * 0.75f, tempr, 0);

        var ins2 = Instantiate<GameObject>(bullet);
        ins2.transform.position = new Vector3(x - def.bounds.size.x * 0.75f, tempr, 0);
    }
}