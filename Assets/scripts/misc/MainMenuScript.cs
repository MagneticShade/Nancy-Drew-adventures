using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField]  GameObject loadMenu;
    [SerializeField] LoadMenu loadMenuScript;
    private FileSystemManager fileSystemManager;
    // Start is called before the first frame update
    void Start()
    {
        fileSystemManager=new FileSystemManager(Application.persistentDataPath);
    }

    public void NewGame(){
        SceneManager.LoadScene("General");
        SaveDataManager.instance.NewGame();
    }
    
    public void Continue(){

    }

    public void Load(){
        loadMenu.SetActive(true);
        gameObject.SetActive(false);

        loadMenuScript.GenerateSaves(fileSystemManager.LoadSaves());

    }

    public void Exit(){
        
        Application.Quit();
    }

    public void Options(){

    }
}
