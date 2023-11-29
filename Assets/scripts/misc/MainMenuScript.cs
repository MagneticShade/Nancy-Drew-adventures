using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGame(){
        SceneManager.LoadScene("General");
    }
    
    public void Continue(){

    }

    public void Load(){

    }

    public void Exit(){
        
        Application.Quit();
    }

    public void Options(){

    }
}
