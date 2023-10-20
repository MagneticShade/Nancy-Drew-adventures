using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNext : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public inkManager inkManager;
    public void OnClick(){
        inkManager.ProceedStory();
    }

    // Update is called once per frame
   
}
