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

    [SerializeField] private AudioSource DestroyWallSound;
    [SerializeField] private AudioSource DeathSound;

    // Start is called before the first frame update
    void Start()
    {
        if (memory.instaKill == 1)
        {
            life = 1;
        }
        else
        {
            if (memory.fireRate<=0.1 || memory.damage>=5)
            {
                life = Random.Range(3+(int)memory.score/2, 7+(int)memory.score/1);
            }
            else
            {
                life = Random.Range(3+(int)memory.score/4, 7+(int)memory.score/3);
            }
        }
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
            DeathSound.Play();
        }

        else if (other.tag == "Bullet")
        {
            if (memory.bulletColor == 0 && gameObject.tag == "ObstacleYellow")
            {
                life -= memory.damage * 2;
            }
            else if (memory.bulletColor == 1 && gameObject.tag == "ObstacleBlue")
            {
                life -= memory.damage * 2;
            }
            else if (memory.bulletColor == 2 && gameObject.tag == "ObstacleRed")
            {
                life -= memory.damage * 2;
            }
            else if (memory.bulletColor == 3 && gameObject.tag == "ObstacleGreen")
            {
                life -= memory.damage * 2;
            }
            else if (memory.bulletColor == 4 && gameObject.tag == "ObstaclePink")
            {
                life -= memory.damage * 2;
            }
            else if (memory.bulletColor == 5 && gameObject.tag == "ObstacleOrange")
            {
                life -= memory.damage * 2;
            }
            else
            {
                life -= memory.damage;
            }

            Destroy(other.gameObject);
            lifeText.text = life.ToString();
            if (life <= 0)
            {
                Destroy(gameObject);
                DestroyWallSound.Play();
            }
        }
    }
}
