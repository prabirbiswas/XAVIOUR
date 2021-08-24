using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;
    public float spawnTime = 3f;
    public PlayerStats playerStats;

    private void Start()
    {
        spawners = new GameObject[50];

        for(int i=0;i<spawners.Length;i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
            InvokeRepeating("spawnEnemy", spawnTime, 0);
        }
       

    }

    



    private void spawnEnemy()
    {
        if (playerStats.currhealth <= 0)
        {
            
            return;
        }
        int spawnerID = Random.Range(0, spawners.Length);
        
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }
}
