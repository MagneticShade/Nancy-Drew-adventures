using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] SceneController sceneController;
    public void Pause(){
        pauseCanvas.SetActive(true);
        Time.timeScale=0;
        gameObject.SetActive(false);
        sceneController.clickable=false;
    }

    public void UnPause(){
        pauseCanvas.SetActive(false);
        Time.timeScale=1;
        gameObject.SetActive(true);

        sceneController.clickable=true;
    }
}
