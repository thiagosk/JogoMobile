using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;

    public Memory memory;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            scoreText.text = ((int)memory.score).ToString();
            moneyText.text = memory.money.ToString();
        }
    }

    public void Restart()
    {
        memory.moneyTotal+=memory.money;
        // Restart game 
        memory.score = 0;
        memory.money = 0;
        memory.fireRate = 0.3f;
        memory.numBulletsSpawn = 1;
        memory.damage = 1;
        memory.instaKill = 0;
        memory.doubleMoney = 0;
        memory.bulletSpeed = 12;
        memory.backgroundSpeed = 4f;
        memory.cameraSpeed = 4f;
        memory.timeBetweenSpawn = 2f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        // Restart game 
        memory.score = 0;
        memory.money = 0;
        memory.fireRate = 0.3f;
        memory.numBulletsSpawn = 1;
        memory.damage = 1;
        memory.instaKill = 0;
        memory.doubleMoney = 0;
        memory.bulletSpeed = 12;
        memory.backgroundSpeed = 4f;
        memory.cameraSpeed = 4f;
        memory.timeBetweenSpawn = 2f;
        
        memory.moneyTotal+=memory.money;
        // SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
