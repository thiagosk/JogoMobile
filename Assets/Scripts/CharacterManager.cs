using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDB characterDB;
    public Text NameText;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    void Start()
    {
        if(PlayerPrefs.HasKey("selectedOption")){
            Load();
        }
        else{
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOption(){     
        selectedOption++;
        if(selectedOption >= characterDB.CharacterCount){
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Debug.Log("next");
        Save();
    }

    public void BackOption(){
        selectedOption--;
        if(selectedOption < 0){
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Debug.Log("back");
        Save();
    }

    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        NameText.text = character.characterName;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save(){
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void Playgame(){
        SceneManager.LoadSceneAsync(1);
    }


}
