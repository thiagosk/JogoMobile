using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "TopBorder")
        {
            Destroy(gameObject);
        }

        else if (other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

}
