using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject pause;

    [SerializeField] SoundController soundController;
    [SerializeField] inkManager inkManager;

    [SerializeField] Slider textSlider;
    [SerializeField] Slider soundSlider;
    // Start is called before the first frame update
    void Awake()
    {
        if(!PlayerPrefs.HasKey("charactersPerSecond")){
            PlayerPrefs.SetInt("charactersPerSecond",20);
        }

        if(!PlayerPrefs.HasKey("volume")){
            PlayerPrefs.SetFloat("volume",1);
        }
    }

    public void Startup(){
        textSlider.value=PlayerPrefs.GetInt("charactersPerSecond");
        soundSlider.value=PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    public void SetNewText(){
        PlayerPrefs.SetInt("charactersPerSecond",(int)textSlider.value);
        
    }
    public void SetNewSound(){
        PlayerPrefs.SetFloat("volume",soundSlider.value);
    }

    public void Escape(){
        soundController.UpdateSound();
        
        if(inkManager!=null){
            inkManager.SetNewDelay();
        }
        gameObject.SetActive(false);
        pause.SetActive(true);
    }
    
}
