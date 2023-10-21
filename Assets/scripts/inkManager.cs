using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;

public class inkManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDialog;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextAsset inkAsset;
    [SerializeField] private backgroundManager backgroundManager;
    Story _inkStory;
    
    // Start is called before the first frame update
    void Awake()
    {
        _inkStory = new Story(inkAsset.text);
        
        _inkStory.ObserveVariable("location",(string varName,object newValue)=>{
            backgroundManager.SetBackground((string)newValue);
        });
        
        backgroundManager.SetBackground((string)_inkStory.variablesState["location"]);
        WriteText(_inkStory.Continue());
        
        
    }
    public void ProceedStory(){
        if (_inkStory.canContinue) {
            WriteText(_inkStory.Continue());
            
        }
    }

    void WriteText(string text){
        string[] newLine=text.Split("::");
        
        textName.SetText(newLine[0]);
        textDialog.SetText(newLine[1]);
        
    }

    // Update is called once per frame

}
