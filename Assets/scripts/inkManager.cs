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
    
    
    public Story _inkStory;
    
    // Start is called before the first frame update
    void Awake()
    {
        _inkStory = new Story(inkAsset.text);

        
        
    }
    public string ProceedStory(){
        if (_inkStory.canContinue) {

            string tmp= WriteText(_inkStory.Continue());
            return tmp;
        }
        else{
            return "end";
        }
    }

    string WriteText(string text){
        string[] newLine=text.Split("::");
        
        textName.SetText(newLine[0]);
        textDialog.SetText(newLine[1]);

        return newLine[0];
        
    }

    public void ChangeNameColor(Color32 color){
        textName.color= color;
    }


}
