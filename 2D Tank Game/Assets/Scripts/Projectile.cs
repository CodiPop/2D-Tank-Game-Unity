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
    void Destroyprojectile()
    {
        Destroy(gameObject);
    }
}
