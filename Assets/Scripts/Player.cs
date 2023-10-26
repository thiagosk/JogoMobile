using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    public float fireRate;
    private float timeToFire;
    public Transform firingPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, 0).normalized;
        Shoot();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);
    }

    private void Shoot() {
        if (timeToFire <= 0f) {
            timeToFire = fireRate;
            Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        }
        else {
            timeToFire -= Time.deltaTime;
        }
    }
}
