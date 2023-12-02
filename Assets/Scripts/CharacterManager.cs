using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterDB characterDB;
    public TextMeshProUGUI NameText;
    public SpriteRenderer artworkSprite;
    public Memory memory;
    void Start()
    {
        UpdateCharacter();
    }

    public void NextOption(){
        Debug.Log("next");     
        memory.skingChoice++;
        if(memory.skingChoice >= characterDB.CharacterCount){
            memory.skingChoice = 0;
        }
        UpdateCharacter();
    }

    public void BackOption(){
        memory.skingChoice--;
        if(memory.skingChoice < 0){
            memory.skingChoice = characterDB.CharacterCount - 1;
        }
        UpdateCharacter();
        Debug.Log("back");
    }

    private void UpdateCharacter(){
        Character character = characterDB.GetCharacter(memory.skingChoice);
        artworkSprite.sprite = character.characterSprite;
        NameText.text = character.characterName;
    }
    public void Playgame(){
        SceneManager.LoadSceneAsync(1);
    }


}
