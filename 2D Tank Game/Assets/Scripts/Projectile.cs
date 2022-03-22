using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float lifetime;
    bool isParentTurret = false;

    private void Start()
    {
        Invoke("Destroyprojectile", lifetime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isParentTurret)
        {
            if (col.gameObject.GetComponent<Turrets>() != null)
            {
                Destroy(gameObject);
            }
        }
        else{ 
            if (col.gameObject.GetComponent<movement>() != null)
            {
                Destroy(gameObject);
            }
        }
        
    }

    void Destroyprojectile()
    {
        Destroy(gameObject);
    }

    public void setParent(bool parent)
    {
        isParentTurret = parent;
    }

    public bool getParent()
    {
        return isParentTurret;
    }
}
