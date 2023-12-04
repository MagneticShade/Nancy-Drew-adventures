using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class characterData{
        public string name;
        public Color32 color;
        public string spriteName;

        public characterData(string newName,string newColor,string newSpriteName){
            name=newName;
    
            string [] tmp=newColor.Split(",");
            color=new Color32(byte.Parse(tmp[0]),byte.Parse(tmp[1]),byte.Parse(tmp[2]),255);
            spriteName=newSpriteName;
        }
    }

