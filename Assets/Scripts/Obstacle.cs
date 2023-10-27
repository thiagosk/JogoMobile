using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Obstacle : MonoBehaviour
{
    // private GameObject player;
    
    private int life;

    public TextMeshPro lifeText;

    private float time;

    public Memory memory;

    // Start is called before the first frame update
    void Start()
    {
        life = Random.Range(3+(int)memory.score/4, 7+(int)memory.score/3);
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
            Destroy(other.gameObject);
            life--;
            lifeText.text = life.ToString();
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
