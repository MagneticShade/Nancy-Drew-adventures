using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    
    [SerializeField] private inkManager inkManager;
    [SerializeField] private backgroundManager backgroundManager;
    [SerializeField] private characterManager characterManager;

    void Start()
    {
        Bind();

        backgroundManager.SetBackground((string)inkManager._inkStory.variablesState["location"]);

        ManageStory();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&inkManager.textDialog.maxVisibleCharacters<inkManager.textDialog.textInfo.characterCount){
            inkManager.SkipText();
        }
        else if (Input.GetMouseButtonDown(0)){
            ManageStory();
        }

    }

    void ManageStory(){

        characterData currentSubCharacter=new characterData("tmp","255,0,0","tmp");

        string tmp=inkManager.ProceedStory();
       

        if (tmp==characterManager.MainCharacterData.getName()&&!characterManager.CheckIfExsit(characterManager.MainCharacter)){
            characterManager.AddCharacter(characterManager.MainCharacter,characterManager.MainCharacterData.getSprite());

            characterManager.SetActive(characterManager.MainCharacter);
            inkManager.ChangeNameColor(characterManager.MainCharacterData.getColor());

            if(characterManager.CheckIfExsit(characterManager.SubCharacter)){

                characterManager.SetInactive(characterManager.SubCharacter);
            }
        }
        else if(tmp!=""){

            foreach(characterData person in characterManager.SubCharactersData){
                if(tmp==person.getName()){
                    if(characterManager.CheckIfExsit(characterManager.SubCharacter,person.getSprite())){
                        characterManager.AddCharacter(characterManager.SubCharacter,person.getSprite());
                    }
                    currentSubCharacter=person;

                    characterManager.SetActive(characterManager.SubCharacter);
                        inkManager.ChangeNameColor(currentSubCharacter.getColor());

                        if(characterManager.CheckIfExsit(characterManager.MainCharacter)){

                        characterManager.SetInactive(characterManager.MainCharacter);
            }
                    

                }
            }
        }
        else{
            characterManager.RemoveCharacter(characterManager.MainCharacter);
            characterManager.RemoveCharacter(characterManager.SubCharacter);
        }
        
        
    }

    void Bind(){

        inkManager._inkStory.ObserveVariable("location",(string varName,object newValue)=>{
            backgroundManager.SetBackground((string)newValue);
        });

        inkManager._inkStory.BindExternalFunction("addNewSubcharacter",(string newName,string newColor,string newSpriteName)=>{
            characterManager.addSubCharacter( newName, newColor, newSpriteName);
        });

        inkManager._inkStory.BindExternalFunction("setMainCharacter",(string newName,string newColor,string newSpriteName)=>{
            characterManager.setMainCharacter( newName, newColor, newSpriteName);
        });
    }
}

