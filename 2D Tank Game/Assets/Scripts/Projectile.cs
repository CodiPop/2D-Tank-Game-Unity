using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float lifetime;

    private void Start()
    {
        Invoke("Destroyprojectile", lifetime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Turrets>() != null)
        {
           Destroy(gameObject);
        }
    }

    void Destroyprojectile()
    {
        Destroy(gameObject);
    }
}
