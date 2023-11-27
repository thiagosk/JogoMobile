using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;



public class SolidWall : MonoBehaviour
{
    [SerializeField] private AudioSource DeathSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BottomBorder")
        {
            Destroy(gameObject);
        }

        else if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }

        else if (other.tag == "Player")
        {
            DeathSound.Play();
            Destroy(other.gameObject);
        }
    }
}
