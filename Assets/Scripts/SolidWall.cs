using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SolidWall : MonoBehaviour
{

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
            Destroy(other.gameObject);
        }
    }
}
