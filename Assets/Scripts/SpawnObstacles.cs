using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject[] obstacleWithUpgradeFR;
    public GameObject[] obstacleWithUpgradeMB;
    public GameObject[] obstacleWithMoney;
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
        if (randomNum <= 2 && memory.fireRate > 0.05)
        {
            int randomObstacleWithUpgradeFRIndex = Random.Range(0, obstacleWithUpgradeFR.Length);
            Instantiate(obstacleWithUpgradeFR[randomObstacleWithUpgradeFRIndex], transform.position, transform.rotation);
        }
        else if (randomNum <= 4 && memory.numBulletsSpawn < 3)
        {
            int randomObstacleWithUpgradeMBIndex = Random.Range(0, obstacleWithUpgradeMB.Length);
            Instantiate(obstacleWithUpgradeMB[randomObstacleWithUpgradeMBIndex], transform.position, transform.rotation);
        }
        else if (randomNum <= 6)
        {
            int randomObstacleWithMoneyIndex = Random.Range(0, obstacleWithMoney.Length);
            Instantiate(obstacleWithMoney[randomObstacleWithMoneyIndex], transform.position, transform.rotation);
        }
        else
        {
            int randomObstacleIndex = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[randomObstacleIndex], transform.position, transform.rotation);
        }
    }
}
