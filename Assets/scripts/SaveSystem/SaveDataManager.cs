using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    private SaveData saveData=null;
    public static SaveDataManager instance{get; private set;}
    [SerializeField] private string fileName;
    private FileSystemManager fileSystemManager;

    private void Awake(){
        if (instance!=null){
            Debug.Log("more than one instances of SaveDataManage");
        }

        instance=this;
    }

    private void Start(){
        this.fileSystemManager=new FileSystemManager(Application.persistentDataPath);
    }
    

    public void NewGame(){

        this.saveData=new SaveData();
    }
    public void LoadGame(){
        this.saveData=fileSystemManager.QuickLoad();
        sceneController.LoadData(saveData);
    }

    public void LoadGame(string fileName){
        this.saveData=fileSystemManager.LoadMenu(fileName);
        sceneController.LoadData(saveData);

    }

    public List<FileInfo> LoadSaveGames(){
       return fileSystemManager.LoadSaves();
    }

    public void SaveGame(){

        sceneController.SaveData(ref saveData);
        fileSystemManager.Save(saveData,"quicksave");
    }

    public void SaveGame(string saveAltName){
        
        sceneController.SaveData(ref saveData);
        fileSystemManager.Save(saveData,saveAltName);
    }

    public void DeleteSave(string fileName){
        fileSystemManager.SaveDelete(fileName);
    }
}
