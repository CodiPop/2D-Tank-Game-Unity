using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    

    

 

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<Projectile>() != null)
        {
            
            Destroy(col.gameObject);
            print("mate");
            Destroy(gameObject);
        }

        
    }



}
