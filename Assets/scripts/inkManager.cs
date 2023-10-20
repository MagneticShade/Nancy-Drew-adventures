using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;

public class inkManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textDialog;
    [SerializeField] public TextMeshProUGUI textName;
    [SerializeField] private TextAsset inkAsset;
    Story _inkStory;
    
    // Start is called before the first frame update
    void Awake()
    {
        _inkStory = new Story(inkAsset.text);
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
