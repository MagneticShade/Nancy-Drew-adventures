using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int index;
    inkManager inkmanager;
    SceneController sceneController;
    public void Setup(int indexToSet,inkManager ink,SceneController scene)
    {   inkmanager=ink;
        sceneController=scene;
        index=indexToSet;
    }

    public void Click(){
        inkmanager._inkStory.ChooseChoiceIndex (index);
        Debug.Log(index);
        sceneController.ManageStory();
        sceneController.clickable=true;
        sceneController.ChoiceSweep();
    }
    

    // Update is called once per frame
   
}
