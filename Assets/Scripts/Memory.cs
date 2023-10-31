using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Memory", menuName = "Memory")]
public class Memory : ScriptableObject
{
    public float score;
    public float bulletSpeed;
    public float backgroundSpeed;
    public float cameraSpeed;
    public float playerSpeed;
    public float fireRate;
    public int numBulletsSpawn;
    public float timeBetweenSpawn;
    public int money;
    public int moneyTotal;
    public int damage;
    public int instaKill;
    public int doubleMoney;
    public int bulletColor;
}
