using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public void PlayGame(){
SceneManager.LoadSceneAsync(1);
}

public void BackMenuMain(){
SceneManager.LoadSceneAsync(0);
}

public void QuitGame(){
    Debug.Log("quit");
    Application.Quit();
}

}