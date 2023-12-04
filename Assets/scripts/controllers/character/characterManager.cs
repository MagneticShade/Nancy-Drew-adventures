using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterManager : MonoBehaviour
{
    public Image MainCharacter;
    public Image SubCharacter;
    
    public characterData MainCharacterData;
    public List <characterData> SubCharactersData=new List<characterData>();
    
    void Awake()
    {
        MainCharacter=transform.GetChild(0).GetComponent<Image>();
        SubCharacter=transform.GetChild(1).GetComponent<Image>();

    }

    public bool CheckIfExsit(Image character){
        if(character.sprite!=null){
            return true;
        }
        return false;

    }

    public bool CheckIfExsit(Image character,Sprite sprite){
        if(character.sprite!=sprite){
            return true;
        }
        return false;
    }

    public void RemoveCharacter(Image character){
        character.color-= new Color(0f, 0f, 0f, 1f);
        character.sprite=null;
    }

    public void AddCharacter(Image character,Sprite sprite){
        character.color+= new Color(0f, 0f, 0f, 1f);
        character.sprite=sprite;
    }

    public void SetActive(Image character){
        character.color=new Color32(255,255,255,255);
        
    }
    public void SetInactive(Image character){
        character.color=new Color32(0,0,0,255);

    }
     
    public void addSubCharacter(string newName,string newColor,string newSpriteName){
        SubCharactersData.Add(new characterData(newName,newColor,newSpriteName));
        
    }

    public void setMainCharacter(string newName,string newColor,string newSpriteName){
        MainCharacterData=new characterData(newName,newColor,newSpriteName);
    }
   
}


