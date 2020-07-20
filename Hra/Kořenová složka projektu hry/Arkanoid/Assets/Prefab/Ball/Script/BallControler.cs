using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *Trida slouzi pro kulicku, zjmena pro kontrolu pohybu a vypoctu odrazu od platformy
 *
 * @autor David Zaruba
 *
 * 
 */
public class BallControler : MonoBehaviour
{
    private float speed = 5f;
    private gameManager1 gm;
    private bool isDestroyed = false;
    private Rigidbody2D rid;


    public gameManager1 Gm
    {
        get => gm;
        set => gm = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public bool IsDestroyed => isDestroyed;

    /**
     * Event funkce z unity spoustena pri vytvareni instance. Nastavuje pocatecni hodnota a hlavne uvede kulicku do pohybu
     */
    void Start()
    {
        speed = SettingManager.speedOfBall;
        rid = GetComponent<Rigidbody2D>();
        initVelocity();
    }
    
    /**
     *Funkce slouzi k vytvoreni prvotniho pohybu
     * 
     */

    public void initVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    /**
     *Funkce je spoustna pri kolizi s jinym objektem. Je vyhodnocovano o jaky jde objekt a pripadne zajistena patricna reakce.
     * 
     */
    void OnCollisionEnter2D(Collision2D col)
    {
        String name = col.gameObject.name;
        
        if (name == "Platform")
        {
          
            float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);

       
            Vector2 dir = new Vector2(x, 1).normalized;

  
            rid.velocity = dir * speed;
        }

        if (col.gameObject.name == "OutOfMapRect")
        {
            isDestroyed = true;
            Destroy(gameObject);
            gm.hitBall();
        }
    }
    
    /**
     *
     * Funkce slouzi pro vypocet odrazu kulicky od platformy
     */

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketWidth)
    {
        // 
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    
    /**
     *Kontrola rychlosti kulicky a popripade jeji upraveni
     * 
     */

    private void checkVelocity()
    {
        Vector2 temp = rid.velocity;

        if (temp.magnitude < speed || temp.magnitude > speed)
        {
            rid.velocity = temp.normalized * speed;
        }
    }
    /**
     *Event funkce unity vyvolana v kazdem framu vytvorenym Unity.
     * 
     */

    private void Update()
    {
        checkVelocity();
    }
}