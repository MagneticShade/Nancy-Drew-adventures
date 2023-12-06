using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
   [SerializeField] GameObject savesField;
   [SerializeField] GameObject pause;
   [SerializeField] EscapeButton unpauseScript;

    public void GenerateSaves(List<FileInfo> saves){
        if(savesField.transform.childCount>0){

            for (int i=savesField.transform.childCount;i>0;i--){
                    DestroyImmediate(savesField.transform.GetChild(0).gameObject);
            }
        }
        foreach(FileInfo save in saves){
            GameObject saveSlot=Resources.Load<GameObject>("Prefab/SaveSlot");
            GameObject inst=Instantiate(saveSlot,savesField.transform);
            inst.GetComponent<LoadButtonLogic>().Setup(save);
        }
    }

    public void Escape(){
        gameObject.SetActive(false);
        pause.SetActive(true);
    }

    public void UltimateEscape(){
        Escape();
        unpauseScript.UnPause();
        
    }

}
