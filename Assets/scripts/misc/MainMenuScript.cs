using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField]  GameObject loadMenu;
    [SerializeField] LoadMenu loadMenuScript;
    [SerializeField] Button continueButton;
    [SerializeField] GameObject options;
    private OptionsMenu optionsScript;
    private FileSystemManager fileSystemManager;
    // Start is called before the first frame update
    void Start()
    {
        fileSystemManager=new FileSystemManager(Application.persistentDataPath);
        CheckSaves();
        optionsScript=options.GetComponent<OptionsMenu>();
        
    }

    

    public void NewGame(){
        SceneManager.LoadScene("General");
        SaveDataManager.instance.NewGame();
    }
    
    public void Continue(){
        SceneManager.LoadScene("General");
        List<FileInfo> list=SaveDataManager.instance.LoadSaveGames();
        SaveDataManager.instance.BetweenScenesSavePath=list[list.Count-1].Name;
    }

    public void Load(){
        loadMenu.SetActive(true);
        gameObject.SetActive(false);

        loadMenuScript.GenerateSaves(fileSystemManager.LoadSaves());

    }

    public void Exit(){
        
        Application.Quit();
    }

    public void CheckSaves(){
        if(fileSystemManager.LoadSaves().Count==0){
            continueButton.interactable = false;
        }
    }

    public void Options(){
        options.SetActive(true);
        gameObject.SetActive(false);
        optionsScript.Startup();
    }
}
