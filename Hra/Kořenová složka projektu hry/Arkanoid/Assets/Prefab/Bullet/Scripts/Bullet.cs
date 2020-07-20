using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *Trida se slouzi pro strileny projektyl aktivovany pri bonusu.
 * 
 */
public class Bullet : MonoBehaviour
{
    private float speed = 0.1f;

    [SerializeField]private GameObject ball;
  

   /**
    *
    * Event funkce spustena v kazdem framu, ktera se stara o pohyb projektilu.
    */
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y + speed,0);
    }
 /**
  *Funkce spoustena pri kolizi, zde zajisti zniceni projektilu
  * 
  */
   void OnCollisionEnter2D(Collision2D collider)
    {
            Destroy(gameObject);
      
        
    }
   
   
}
