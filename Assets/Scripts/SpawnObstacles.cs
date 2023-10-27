using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject[] obstacleWithUpgrade;
    private float spawnTime;
    public Memory memory;

    void Start()
    {
        memory.timeBetweenSpawn = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + memory.timeBetweenSpawn;
        }
        if (memory.timeBetweenSpawn >= 1.5)
        {
            memory.timeBetweenSpawn-=memory.score/100000;
        }
    }

    void Spawn()
    {
        int randomNum = Random.Range(1, 11);
        if (randomNum <= 3)
        {
            int randomObstacleWithUpgradeIndex = Random.Range(0, obstacleWithUpgrade.Length);
            Instantiate(obstacleWithUpgrade[randomObstacleWithUpgradeIndex], transform.position, transform.rotation);
        }
        else
        {
            int randomObstacleIndex = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[randomObstacleIndex], transform.position, transform.rotation);
        }
    }
}
