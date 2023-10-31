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
        int randomNum = Random.Range(1, 25);
        print(randomNum);
        if (randomNum <= 4 && memory.fireRate > 0.05)
        {
            int randomObstacleWithUpgradeFRIndex = Random.Range(0, obstacleWithUpgradeFR.Length);
            Instantiate(obstacleWithUpgradeFR[randomObstacleWithUpgradeFRIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 5 && randomNum <= 7 && memory.numBulletsSpawn < 3)
        {
            int randomObstacleWithUpgradeMBIndex = Random.Range(0, obstacleWithUpgradeMB.Length);
            Instantiate(obstacleWithUpgradeMB[randomObstacleWithUpgradeMBIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 8 && randomNum <= 10)
        {
            int randomObstacleWithUpgradeDMIndex = Random.Range(0, obstacleWithDoubleMoney.Length);
            Instantiate(obstacleWithDoubleMoney[randomObstacleWithUpgradeDMIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 10 && randomNum <= 12)
        {
            int randomObstacleWithUpgradeIKIndex = Random.Range(0, obstacleWithInstaKill.Length);
            Instantiate(obstacleWithInstaKill[randomObstacleWithUpgradeIKIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 13 && randomNum <= 14)
        {
            int randomObstacleWithUpgradeMDIndex = Random.Range(0, obstacleWithUpgradeMD.Length);
            Instantiate(obstacleWithUpgradeMD[randomObstacleWithUpgradeMDIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 15 && randomNum <= 17)
        {
            int randomObstacleWithMoneyIndex = Random.Range(0, obstacleWithMoney.Length);
            Instantiate(obstacleWithMoney[randomObstacleWithMoneyIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 18 && randomNum <= 19)
        {
            int randomSolidWallsIndex = Random.Range(0, solidWalls.Length);
            Instantiate(solidWalls[randomSolidWallsIndex], transform.position, transform.rotation);
        }
        else if (randomNum >= 20 && randomNum <= 23)
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
