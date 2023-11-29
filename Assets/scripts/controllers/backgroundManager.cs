using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class backgroundManager : MonoBehaviour
{
    
    Image image;
    // Start is called before the first frame update
    void Awake()
    {
        image=GetComponent<Image>();
        
    }

    public void SetBackground(string path){

        Sprite sprite = Resources.Load<Sprite>($"locations/{path}");
        image.sprite=sprite;

    }
   
}
