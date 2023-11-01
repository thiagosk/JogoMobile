using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject[] obstacleWithUpgradeFR;
    public GameObject[] obstacleWithUpgradeMB;
    public GameObject[] obstacleWithUpgradeMD;
    public GameObject[] obstacleWithMoney;
    public GameObject[] obstacleWithDoubleMoney;
    public GameObject[] obstacleWithInstaKill;
    public GameObject[] solidWalls;
    public GameObject[] ChangeBulletColors;
    private float spawnTime;
    public Memory memory;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (Time.time > spawnTime)
            {
                Spawn();
                spawnTime = Time.time + memory.timeBetweenSpawn;
            }
            if (memory.timeBetweenSpawn >= 1.5)
            {
                memory.timeBetweenSpawn-=memory.score/1000000;
            }
        }
        else
        {
            if (Time.time > spawnTime)
            {
                if (Time.time > spawnTime)
                {
                    Spawn();
                    spawnTime = Time.time + memory.timeBetweenSpawn;
                }
            }
        }
    }

    void Spawn()
    {
        int randomNum = Random.Range(1, 101);
        print(randomNum);
        if (randomNum >= 1 && randomNum <= 15 && memory.fireRate > 0.05)
        {
            int randomObstacleWithUpgradeFRIndex = Random.Range(0, obstacleWithUpgradeFR.Length);
            Instantiate(obstacleWithUpgradeFR[randomObstacleWithUpgradeFRIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 16 && randomNum <= 20 && memory.numBulletsSpawn < 3)
        {
            int randomObstacleWithUpgradeMBIndex = Random.Range(0, obstacleWithUpgradeMB.Length);
            Instantiate(obstacleWithUpgradeMB[randomObstacleWithUpgradeMBIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 21 && randomNum <= 25)
        {
            int randomObstacleWithUpgradeDMIndex = Random.Range(0, obstacleWithDoubleMoney.Length);
            Instantiate(obstacleWithDoubleMoney[randomObstacleWithUpgradeDMIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 26 && randomNum <= 30)
        {
            int randomObstacleWithUpgradeIKIndex = Random.Range(0, obstacleWithInstaKill.Length);
            Instantiate(obstacleWithInstaKill[randomObstacleWithUpgradeIKIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 31 && randomNum <= 40)
        {
            int randomObstacleWithUpgradeMDIndex = Random.Range(0, obstacleWithUpgradeMD.Length);
            Instantiate(obstacleWithUpgradeMD[randomObstacleWithUpgradeMDIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 41 && randomNum <= 50)
        {
            int randomObstacleWithMoneyIndex = Random.Range(0, obstacleWithMoney.Length);
            Instantiate(obstacleWithMoney[randomObstacleWithMoneyIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 51 && randomNum <= 60)
        {
            int randomSolidWallsIndex = Random.Range(0, solidWalls.Length);
            Instantiate(solidWalls[randomSolidWallsIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 61 && randomNum <= 75)
        {
            int randomChangeBulletColorsIndex = Random.Range(0, ChangeBulletColors.Length);
            Instantiate(ChangeBulletColors[randomChangeBulletColorsIndex], transform.position, transform.rotation);
        }
        else
        {
            int randomObstacleIndex = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[randomObstacleIndex], transform.position, transform.rotation);
        }
    }
}
