using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class SceneController : MonoBehaviour
{
    
    [SerializeField] private inkManager inkManager;
    [SerializeField] private backgroundManager backgroundManager;
    [SerializeField] private characterManager characterManager;
    [SerializeField] private GameObject choiceHolder;
    public bool clickable;
    GraphicRaycaster raycaster;
    void Start()
    {
        clickable=true;
        raycaster = GetComponent<GraphicRaycaster>();
        Bind();

        backgroundManager.SetBackground((string)inkManager._inkStory.variablesState["location"]);

        ManageStory();
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetMouseButtonDown(0)){
            bool UI=false;

            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            
            pointerData.position = Input.mousePosition;
            raycaster.Raycast(pointerData, results);

            
            foreach (RaycastResult result in results)
            {
                if(result.gameObject.tag=="UI"){
                    UI=true;
                }
                
            }
                if (clickable&&!UI)
                {
                    if(inkManager.textDialog.maxVisibleCharacters<inkManager.textDialog.textInfo.characterCount){
                        inkManager.SkipText();
                    }
                    else{
                        ManageStory();
                    }
                }

            

        }

    }

     public void ManageStory(){

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

        else if(tmp=="choice"){
            GameObject choiceField=GameObject.Find("ChoiceContainer");
            // while(choiceField.transform.childCount>1){
            //         Destroy(choiceField.transform.GetChild(0));
            //     }
            for(int i=0; i<inkManager._inkStory.currentChoices.Count;i++){
                
                Choice choice = inkManager._inkStory.currentChoices [i];
                GameObject choiceButton=Resources.Load<GameObject>("Prefab/Choice");
                GameObject inst=Instantiate(choiceButton,choiceField.transform);
                TextMeshProUGUI text=inst.GetComponentInChildren<TextMeshProUGUI>();
                ChoiceScript choicescript=inst.GetComponent<ChoiceScript>();
                choicescript.Setup(i,inkManager,this);
                text.SetText(choice.text);
                clickable=false;
                

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

    public void ChoiceSweep(){
        
        for (int i=choiceHolder.transform.childCount;i>0;i--) 
        {

        DestroyImmediate(choiceHolder.transform.GetChild(0).gameObject);


        }
        
    }
}

