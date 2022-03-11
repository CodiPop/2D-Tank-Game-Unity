using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> turrets;
    public List<Transform> spawnPoints;
    int randomSpawnPoint, ramdonTurret;
    public static bool spawnAllowed;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnaTurret", 0f, 1f);
    }

    // Update is called once per frame
    void spawnaTurret()
    {
        if(spawnAllowed){
            randomSpawnPoint = Random.Range(0,spawnPoints.Count-1);
            ramdonTurret = Random.Range(0,turrets.Count-1);
            Instantiate(turrets[ramdonTurret], spawnPoints[randomSpawnPoint].position,Quaternion.identity);
            turrets.RemoveAt(ramdonTurret);
            spawnPoints.RemoveAt(randomSpawnPoint);
            count = count + 1;
            if(count==3){
                spawnAllowed = false;
            }
        }
    }


}
