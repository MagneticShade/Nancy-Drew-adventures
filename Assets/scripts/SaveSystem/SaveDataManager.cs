using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveDataManager : MonoBehaviour
{
    private SaveData saveData=null;
    public static SaveDataManager instance{get; private set;}
    private FileSystemManager fileSystemManager;
    public string BetweenScenesSavePath;
    private List<IDataPersistance> dataList;

    private void Awake(){
        if (instance!=null){
            DestroyImmediate(this);
        }
        else{
            DontDestroyOnLoad(this);
            instance=this;
        }
    }

    private void Start(){
        BetweenScenesSavePath=null;
        this.fileSystemManager=new FileSystemManager(Application.persistentDataPath);
    }
    private void OnEnable(){
        SceneManager.sceneLoaded+=OnSceneLoaded;

    }
    private void OnSceneLoaded(Scene scene,LoadSceneMode mode){
        dataList=FindAllIDataPersistanceExamplars();
        if(BetweenScenesSavePath!=null&&BetweenScenesSavePath!=""){
            LoadGame(BetweenScenesSavePath);
        }

    }
    


    public void NewGame(){

        this.saveData=new SaveData();
    }
    public void LoadGame(){
        this.saveData=fileSystemManager.QuickLoad();
        ForeachLoad(dataList);
    }

    public void LoadGame(string fileName){
        this.saveData=fileSystemManager.LoadMenu(fileName);
        ForeachLoad(dataList);

    }

    public List<FileInfo> LoadSaveGames(){
       return fileSystemManager.LoadSaves();
    }

    public void SaveGame(){

        ForeachSave(dataList);
        fileSystemManager.Save(saveData,"quicksave");
    }

    public void SaveGame(string saveAltName){
        
        ForeachSave(dataList);
        fileSystemManager.Save(saveData,saveAltName);
    }

    public void DeleteSave(string fileName){
        fileSystemManager.SaveDelete(fileName);
    }

    public  List<IDataPersistance>FindAllIDataPersistanceExamplars(){
        IEnumerable<IDataPersistance> dataPersistances=FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }

    public void ForeachLoad(List<IDataPersistance> dataPersistances){
        foreach(IDataPersistance dataPersistance in dataPersistances){
            dataPersistance.LoadData(saveData);
        }
        
    }

    public void ForeachSave(List<IDataPersistance> dataPersistances){
        foreach(IDataPersistance dataPersistance in dataPersistances){
            dataPersistance.SaveData(ref saveData);
        }
        
    }
}
