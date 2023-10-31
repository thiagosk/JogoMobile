using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private float timeToFire;
    public Transform firingPoint1;
    public Transform firingPoint2;
    public Transform firingPoint3;
    // public GameObject bullet;

    public Memory memory;

    private float InstaKillTime;
    private float DoubleMoneyTime;

    public GameObject[] bulletColors;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        memory.fireRate = 0.4f;
        memory.numBulletsSpawn = 1;
        memory.damage = 1;
        memory.instaKill = 0;
        memory.doubleMoney = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, 0).normalized;
        Shoot();
        
        if (InstaKillTime <= memory.score)
        {
            memory.instaKill = 0;
        }
        if (DoubleMoneyTime <= memory.score)
        {
            memory.doubleMoney = 0;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * memory.playerSpeed, 0);
    }

    private void Shoot() {
        if (timeToFire <= 0f) {
            timeToFire = memory.fireRate;
            if (memory.numBulletsSpawn == 1)
            {
                Instantiate(bulletColors[memory.bulletColor], firingPoint1.transform.position, firingPoint1.transform.rotation);
            }
            else if (memory.numBulletsSpawn == 2)
            {
                Instantiate(bulletColors[memory.bulletColor], firingPoint1.transform.position, firingPoint1.transform.rotation);
                Instantiate(bulletColors[memory.bulletColor], firingPoint2.transform.position, firingPoint2.transform.rotation);
            }
            else
            {
                Instantiate(bulletColors[memory.bulletColor], firingPoint1.transform.position, firingPoint1.transform.rotation);
                Instantiate(bulletColors[memory.bulletColor], firingPoint2.transform.position, firingPoint2.transform.rotation);
                Instantiate(bulletColors[memory.bulletColor], firingPoint3.transform.position, firingPoint3.transform.rotation);
            }
        }
        else {
            timeToFire -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MoreFireRate")
        {
            Destroy(other.gameObject);
            if (memory.fireRate > 0.05)
            {
                memory.fireRate-=0.05f;
            }
        }
        else if (other.tag == "MoreBulletsSpawn")
        {
            Destroy(other.gameObject);
            if (memory.numBulletsSpawn<=2)
            {
                memory.numBulletsSpawn+=1;
                memory.fireRate+=0.05f;
            }
        }
        else if (other.tag == "MoreDamage")
        {
            Destroy(other.gameObject);
            memory.damage += (int) 2 / ((int) memory.score/3);
        }
        else if (other.tag == "DoubleMoney")
        {
            Destroy(other.gameObject);
            memory.doubleMoney = 1;
            DoubleMoneyTime = memory.score + 15;
        }
        else if (other.tag == "InstaKill")
        {
            Destroy(other.gameObject);
            memory.instaKill = 1;
            InstaKillTime = memory.score + 10;
        }
        else if (other.tag == "Money")
        {
            if (memory.doubleMoney == 1)
            {
                memory.money+=10;
            }
            else
            {
                memory.money+=5;
            }
            Destroy(other.gameObject);
        }
        else if (other.tag == "ColorChange")
        {
            int randomIndex = Random.Range(0, bulletColors.Length);
            memory.bulletColor = randomIndex;
            Destroy(other.gameObject);
        }
    }
}
