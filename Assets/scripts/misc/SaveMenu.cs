using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField  inputField;
    [SerializeField] private GameObject pause;

    public void SaveNewName(){
        SaveDataManager.instance.SaveGame(inputField.text);
        Escape();
        
    }

    public void Escape(){
        gameObject.SetActive(false);
        pause.SetActive(true);
    }
    
}
