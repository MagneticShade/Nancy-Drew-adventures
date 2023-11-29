using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterData{
        string name;
        Color32 color;
        string spriteName;

        public characterData(string newName,string newColor,string newSpriteName){
            name=newName;
    
            string [] tmp=newColor.Split(",");
            color=new Color32(byte.Parse(tmp[0]),byte.Parse(tmp[1]),byte.Parse(tmp[2]),255);
            spriteName=newSpriteName;
        }
        public string getName(){
            return name;
        }
        public Color32 getColor(){
            return color;
        }
        public string getSpriteName(){
            return spriteName;
        }
    }

