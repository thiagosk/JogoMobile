using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Obstacle : MonoBehaviour
{
    // private GameObject player;
    
    public int life;

    public TextMeshPro lifeText;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        lifeText.text = life.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BottomBorder")
        {
            Destroy(gameObject);
        }

        else if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }

        else if (other.tag == "Bullet")
        {
            life--;
            lifeText.text = life.ToString();
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
