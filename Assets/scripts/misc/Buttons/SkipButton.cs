using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{

    [SerializeField] SceneController sceneController;
    
    public void Skip(){
        sceneController.ManageStory();
    }
    
}
