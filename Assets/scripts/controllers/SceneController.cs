using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class SceneController : MonoBehaviour,IDataPersistance
{
    
    [SerializeField] private inkManager inkManager;
    [SerializeField] private backgroundManager backgroundManager;
    [SerializeField] private characterManager characterManager;
    [SerializeField] private GameObject choiceHolder;
    public bool clickable;
    private string activeCharacter;
    GraphicRaycaster raycaster;
    void Awake()
    {
        clickable=true;
        raycaster = GetComponent<GraphicRaycaster>();
        Bind();

        backgroundManager.SetBackground((string)inkManager._inkStory.variablesState["location"]);

        Time.timeScale=1;

        ManageStory();
        
        
    }

    public void LoadData(SaveData saveData){

        characterManager.RemoveCharacter(characterManager.MainCharacter);
        characterManager.RemoveCharacter(characterManager.SubCharacter);

        if(saveData.StoryStateJson!=null){
            inkManager._inkStory.state.LoadJson(saveData.StoryStateJson);
        }

        if(saveData.SubCharactersData!=null){
        characterManager.SubCharactersData=saveData.SubCharactersData;
        }

        if(saveData.MainCharacterData!=null){
        characterManager.MainCharacterData=saveData.MainCharacterData;
        }

        backgroundManager.SetBackground(saveData.location);

        if(saveData.CurrentMainCharacterSpriteName!=null){
            characterManager.AddCharacter(characterManager.MainCharacter,Resources.Load<Sprite>("characters/"+saveData.CurrentMainCharacterSpriteName));
        }
        else{
            characterManager.RemoveCharacter(characterManager.MainCharacter);
        }

        if(saveData.CurrentSubCharacterSpriteName!=null){
            characterManager.AddCharacter(characterManager.SubCharacter,Resources.Load<Sprite>("characters/"+saveData.CurrentSubCharacterSpriteName));
        }
        else{
            characterManager.RemoveCharacter(characterManager.SubCharacter);
        }

        if(saveData.activeCharacter!=null){
            if(saveData.activeCharacter=="main"){
                characterManager.SetActive(characterManager.MainCharacter);
                if(characterManager.SubCharacter.sprite!=null)
                characterManager.SetInactive(characterManager.SubCharacter);
            }

            if(saveData.activeCharacter=="sub"){
                characterManager.SetActive(characterManager.SubCharacter);
                if(characterManager.MainCharacter.sprite!=null)
                characterManager.SetInactive(characterManager.MainCharacter);
            }
        }
        ManageStory();
    }

    public void SaveData(ref SaveData saveData){

        
        saveData.StoryStateJson=inkManager._inkStory.state.ToJson();
        
        saveData.SubCharactersData = characterManager.SubCharactersData;

        saveData.MainCharacterData = characterManager.MainCharacterData;

        saveData.location=(string)inkManager._inkStory.variablesState["location"];

        if(characterManager.MainCharacter.sprite!=null){
            saveData.CurrentMainCharacterSpriteName=characterManager.MainCharacter.sprite.name;
        }
        else{
            saveData.CurrentMainCharacterSpriteName=null;
        }

        if(characterManager.SubCharacter.sprite!=null){
            saveData.CurrentSubCharacterSpriteName=characterManager.SubCharacter.sprite.name;
        }
        else{
            saveData.CurrentSubCharacterSpriteName=null;
        }

        
        saveData.activeCharacter=activeCharacter;

    }

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
       
        if (tmp==characterManager.MainCharacterData.name){

            if(!characterManager.CheckIfExsit(characterManager.MainCharacter)){

                characterManager.AddCharacter(characterManager.MainCharacter,Resources.Load<Sprite>("characters/"+characterManager.MainCharacterData.spriteName));
            }
            
            characterManager.SetActive(characterManager.MainCharacter);

            inkManager.ChangeNameColor(characterManager.MainCharacterData.color);

            activeCharacter="main";

            if(characterManager.CheckIfExsit(characterManager.SubCharacter)){

                characterManager.SetInactive(characterManager.SubCharacter);
            }
        }

        else if(tmp=="choice"){
            GameObject choiceField=GameObject.Find("ChoiceContainer");
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
                if(tmp==person.name){
                    if(characterManager.CheckIfExsit(characterManager.SubCharacter,Resources.Load<Sprite>("characters/"+person.spriteName))){
                        
                        characterManager.AddCharacter(characterManager.SubCharacter,Resources.Load<Sprite>("characters/"+person.spriteName));
                    }
                    currentSubCharacter=person;

                    characterManager.SetActive(characterManager.SubCharacter);

                    activeCharacter="sub";

                    inkManager.ChangeNameColor(currentSubCharacter.color);

                    if(characterManager.CheckIfExsit(characterManager.MainCharacter)){

                    characterManager.SetInactive(characterManager.MainCharacter);
                    }
                    

                }
            }
        }
       
        else{
            activeCharacter="null";
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

