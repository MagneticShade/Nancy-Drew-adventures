using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipMaxButton : MonoBehaviour
{
  [SerializeField] inkManager inkManager;
  [SerializeField] SceneController sceneController;

  public void SkipMax(){
    while(inkManager._inkStory.canContinue){
        sceneController.ManageStory();
    }
  }
}
