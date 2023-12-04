using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject load;
    [SerializeField] private GameObject save;

    public void Options(){
        //God Help Us
    }
    public void Save(){
        gameObject.SetActive(false);
        save.SetActive(true);
        
    }
    public void Load(){
        gameObject.SetActive(false);
        load.SetActive(true);

    }
    public void ToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
  
}
