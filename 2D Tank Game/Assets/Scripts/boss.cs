using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public Timer other;

    public int stop = 100;

    public void Update()
    {
        if (stop >= 3)
        {
            print("Entre al if");
            other.StopWatchStop();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Projectile>() != null)
        {

            
            stop = stop - 15;
            
            print("mate");
            
            if (stop <= 0)
            {
                print("entre al if");
                Destroy(gameObject);
                Destroy(col.gameObject);
                other.StopWatchStop();
                
            }
        }


    }

}