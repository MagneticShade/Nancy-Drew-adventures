using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject load;
    [SerializeField] private GameObject save;

    [SerializeField] private LoadMenu loadMenu;
    [SerializeField] private GameObject optionsMenu;

    public void Options(){
        gameObject.SetActive(false);
        optionsMenu.SetActive(true);
        optionsMenu.GetComponent<OptionsMenu>().Startup();

    }
    public void Save(){
        gameObject.SetActive(false);
        save.SetActive(true);
        
    }
    public void Load(){
        loadMenu.GenerateSaves(SaveDataManager.instance.LoadSaveGames());
        gameObject.SetActive(false);
        load.SetActive(true);

    }
    public void ToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
  
}
