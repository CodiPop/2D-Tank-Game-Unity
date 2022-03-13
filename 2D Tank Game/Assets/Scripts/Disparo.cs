using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    private float timebtwnShots;
    public float Cadenciadedisparo;
    public float speed; 
    public AudioSource audioSource;
    public AudioClip shootingClip;

    public void Update()
    {
        if (timebtwnShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject newBullet = Instantiate(projectile, shotPoint.position, transform.rotation);
                audioSource.PlayOneShot(shootingClip);
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed; 
                timebtwnShots = Cadenciadedisparo;

            }
        }else 
        {
            timebtwnShots -= Time.deltaTime;
                
        }
        
    }
}
