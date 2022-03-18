using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    

    public int stop = 0;

 

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<Projectile>() != null)
        {
            
            Destroy(col.gameObject);
            stop = stop + 1;
            print("mate");
            Destroy(gameObject);
        }

        
    }



}
