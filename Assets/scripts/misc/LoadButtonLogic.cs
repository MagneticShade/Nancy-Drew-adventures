using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private string saveName;
    private string pathToSave;

    [SerializeField] private TextMeshProUGUI SaveFileName;

    public void Setup(FileInfo file){
        saveName=Path.GetFileNameWithoutExtension(file.Name);
        pathToSave=file.Name;
        SaveFileName.SetText(saveName);
    }

    public void Delete(){
        SaveDataManager.instance.DeleteSave(pathToSave);
        DestroyImmediate(gameObject);
    }

    public void Load(){
        gameObject.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<LoadMenu>().UltimateEscape();
        SaveDataManager.instance.BetweenScenesSavePath=pathToSave;
        SceneManager.LoadSceneAsync("General");

        
     
    }
}
