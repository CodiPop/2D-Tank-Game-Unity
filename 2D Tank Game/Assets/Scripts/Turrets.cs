using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{

    private GameObject Tower;
    private Turrets Self;
    private GameObject Enemy;
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
        print(Tower);
    }

    void Update()
    {

        Tower.transform.Rotate(new Vector3(0.0f,0.0f,5.0f));
        if (Vector3.Distance(Enemy.transform.position,Self.transform.position) <= 1.0f)
        {
           
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<Projectile>() != null)
        {
            
            Destroy(col.gameObject);
            print("mate");
            Destroy(gameObject);
        }

        
    }



}
