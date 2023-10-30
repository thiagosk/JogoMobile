using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    private float score;

    public Memory memory;

    void Start()
    {
        memory.score = 0;
        memory.money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            scoreText.gameObject.SetActive(true);
            moneyText.gameObject.SetActive(true);
            memory.score += 1 * Time.deltaTime;
            scoreText.text = ((int)memory.score).ToString();
            moneyText.text = memory.money.ToString();
        }
        else
        {
            scoreText.gameObject.SetActive(false);
            moneyText.gameObject.SetActive(false);
        }
    }
}
