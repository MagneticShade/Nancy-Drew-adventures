using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio;
    void Start()
    {
        audio=gameObject.GetComponent<AudioSource>();
        UpdateSound();
        
    }

    public void UpdateSound(){
        audio.volume=PlayerPrefs.GetFloat("volume");
    }

}
