using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    private SaveData saveData=null;
    public static SaveDataManager instance{get; private set;}

    private void Awake(){
        if (instance!=null){
            Debug.Log("more than one instances of SaveDataManage");
        }

        instance=this;
    }

    public void NewGame(){

        this.saveData=new SaveData();
    }
    public void LoadGame(){
        if (this.saveData==null){
            NewGame();
        }
        sceneController.LoadData(saveData);
        Debug.Log(saveData.location);
        
    }

    public void SaveGame(){
       NewGame();
        sceneController.SaveData(ref saveData);
        Debug.Log(saveData.location);
    }
}
