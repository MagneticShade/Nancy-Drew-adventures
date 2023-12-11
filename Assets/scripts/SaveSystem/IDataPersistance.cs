using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    // Start is called before the first frame update
    void LoadData(SaveData saveData)
    {
        
    }

    // Update is called once per frame
    void SaveData(ref SaveData saveData)
    {
        
    }
}
