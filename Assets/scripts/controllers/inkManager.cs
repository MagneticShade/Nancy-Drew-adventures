using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;

public class inkManager : MonoBehaviour
{   
    [SerializeField] private float characterPerSecond=20;
    [SerializeField] private float emergencyDelayAmmount=0.5f;
    public int currentVisibleCharacters;
    public Coroutine typeWriterCoroutine=null;
    private WaitForSeconds delay;
    private WaitForSeconds emergencyDelay;
    [SerializeField] public TextMeshProUGUI textDialog;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextAsset inkAsset;

    
    
    public Story _inkStory;
    
    void Awake()
    {
        _inkStory = new Story(inkAsset.text);

        delay=new WaitForSeconds(1/characterPerSecond);
        emergencyDelay=new WaitForSeconds(emergencyDelayAmmount);
        
        
    }
    public string ProceedStory(){
        if (_inkStory.canContinue) {

            string tmp= WriteText(_inkStory.Continue());
            return tmp;
        }

        else if( _inkStory.currentChoices.Count > 0 )
        {
            return "choice";
        }

        else{
            return "end";
        }
    }

    string WriteText(string text){

        if(typeWriterCoroutine!=null){
            StopCoroutine(typeWriterCoroutine);
        }

        currentVisibleCharacters=0;
        textDialog.maxVisibleCharacters=0;


        string[] newLine=text.Split("::");
        
        textName.SetText(newLine[0]);
        textDialog.SetText(newLine[1]);

        typeWriterCoroutine = StartCoroutine(TypeWriter());



        return newLine[0];
        
    }

    private IEnumerator TypeWriter(){
        while (currentVisibleCharacters<textDialog.textInfo.characterCount+1){

            yield return delay;
            textDialog.maxVisibleCharacters++;
            currentVisibleCharacters++;
        }
    }

    public void SkipText(){
        StopCoroutine(TypeWriter());
        currentVisibleCharacters=0;
        textDialog.maxVisibleCharacters=textDialog.textInfo.characterCount+1;
    }


    public void ChangeNameColor(Color32 color){
        textName.color= color;
    }

    public void stateLoad(string stateJson){
        _inkStory.state.LoadJson(stateJson);
    }

}
