using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{

    public GameObject[] spawnPoints;

    public GameObject enemyToSpawn;

    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoints");
        InvokeRepeating("spawn", 0.1f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void spawn(){
        Instantiate(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
    }
}
