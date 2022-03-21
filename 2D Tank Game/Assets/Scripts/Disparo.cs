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
    public AudioClip shootingClip, reloadClip;
    public bool isTurret;
    public bool isBoss;

    public void Update()
    {
        if (!isTurret)
        {
            if (timebtwnShots <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
                {
                    Shoot(false);
                }
            }
            else
            {
                timebtwnShots -= Time.deltaTime;

            }
        }        
    }

    private void Shoot(bool isParentTurret)
    {
        GameObject newBullet = Instantiate(projectile, shotPoint.position, transform.rotation);
        newBullet.GetComponent<Projectile>().setParent(isParentTurret);
        if (!isParentTurret)
        {
            audioSource.PlayOneShot(shootingClip);
        }

        newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        timebtwnShots = Cadenciadedisparo;
        if (!isParentTurret)
        {
            audioSource.PlayOneShot(reloadClip);
        }

    }

    public void Fire()
    {
        if (timebtwnShots <= 0)
        {
                Shoot(true);   
        }
        else
        {
            timebtwnShots -= Time.deltaTime;

        }
    }

    public void FireBoss(bool isParentTurret, Transform[] shotPoints) {
        if (timebtwnShots <= 0){
            foreach (Transform shotPoint in shotPoints) {
                GameObject newBullet = Instantiate(projectile, shotPoint.position, transform.rotation);
                newBullet.GetComponent<Projectile>().setParent(isParentTurret);
                //audioSource.PlayOneShot(shootingClip);
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.up* speed;
                timebtwnShots = Cadenciadedisparo;
                //audioSource.PlayOneShot(reloadClip);
                }
        } else { 
            timebtwnShots -= Time.deltaTime;
        }
    }      
    
}


