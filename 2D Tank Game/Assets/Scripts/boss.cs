using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public Timer other;

    int stop = 100;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Projectile>() != null)
        {

            print(stop);
            stop = stop - 15;
            print(stop);

            print("mate");
            Destroy(col.gameObject);
            if (stop <= 0)
            {
                print("entre al if 123");
                Destroy(gameObject);
                Destroy(col.gameObject);
                other.StopWatchStop();
                
            }
        }


    }

}