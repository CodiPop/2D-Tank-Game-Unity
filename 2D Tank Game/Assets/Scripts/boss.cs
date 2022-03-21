using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public Timer other;
    public GameObject WinText;
    
    int stop = 100;



    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile p = col.gameObject.GetComponent<Projectile>();
        if ( p != null)
        {
            if (!p.getParent())
            {
                
                stop -= 15;
                print(stop);
                Destroy(p);
                if (stop <= 0)
                {
                    print(stop);
                    Destroy(gameObject);
                    Destroy(p);
                    other.StopWatchStop();
                }
            }
      
        }

    }

}