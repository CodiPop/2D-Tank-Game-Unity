using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{

    private GameObject Tower;
    private Turrets Self;
    private GameObject Enemy;
    private Disparo Gun;
    private Transform[] shotPoints;

    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Player")[0];
        Self = this.GetComponent<Turrets>();
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        foreach (GameObject tower in towers)
        {
            if (tower.GetComponentInParent<Turrets>().name == Self.name)
            {
                Tower = tower;
            }
        }
        if(Tower != null)

        {
            Gun = GameObject.Find($"{Self.name}/{Tower.name}/Gun").GetComponent<Disparo>();
            if (Gun.isBoss)
            {   
                GameObject[] shotPointsGO= GameObject.FindGameObjectsWithTag("tagShotPointBoss");
                print(shotPointsGO.Length);
                List<Transform> _shotPoints = new List<Transform>();
                foreach (GameObject shotPoint in shotPointsGO)
                {
                    _shotPoints.Add(shotPoint.GetComponentInParent<Transform>());
                }
                shotPoints = _shotPoints.ToArray();
            }
        }
    }

    void Update()
    {
        if (Tower != null)

            
        {
            Vector3 diff = Enemy.transform.position - Tower.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            Tower.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (Vector2.Distance(Enemy.transform.position, Self.transform.position) <= 5.0f)
            {
                Fire();
            }
            
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile p = col.gameObject.GetComponent<Projectile>();
        if (p != null)
        {
            if (!p.getParent() && !Gun.isBoss)
            {
               Destroy(p);
               Destroy(gameObject);
            }
        }
    }

    void Fire()
    {
        if(Gun != null)
        {
            if (Gun.isBoss)
            {
                Gun.FireBoss(true, shotPoints);
            }
            else
            {
                Gun.Fire();
            }
            
        }
        
    }

    public Disparo getGun()
    {
        return Gun;
    }



}
