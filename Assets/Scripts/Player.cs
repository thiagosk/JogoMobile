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
    public GameObject bullet;

    public Memory memory;
    private Vector3 touchPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        memory.playerSpeed = 5;
        memory.fireRate = 0.4f;
        memory.numBulletsSpawn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            Debug.Log("aaa");
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
        }

        playerDirection = new Vector2(touchPosition.x, touchPosition.y).normalized;
        Shoot();
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
                Instantiate(bullet, firingPoint1.transform.position, firingPoint1.transform.rotation);
            }
            else if (memory.numBulletsSpawn == 2)
            {
                Instantiate(bullet, firingPoint1.transform.position, firingPoint1.transform.rotation);
                Instantiate(bullet, firingPoint2.transform.position, firingPoint2.transform.rotation);
            }
            else
            {
                Instantiate(bullet, firingPoint1.transform.position, firingPoint1.transform.rotation);
                Instantiate(bullet, firingPoint2.transform.position, firingPoint2.transform.rotation);
                Instantiate(bullet, firingPoint3.transform.position, firingPoint3.transform.rotation);
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
        else if (other.tag == "Money")
        {
            Destroy(other.gameObject);
            memory.money+=5;
        }
    }
}
