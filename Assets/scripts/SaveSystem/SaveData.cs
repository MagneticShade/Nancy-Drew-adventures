using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public string StoryStateJson=null;
    public characterData MainCharacterData=null;
    public List <characterData> SubCharactersData=new List<characterData>();

    public string CurrentMainCharacterSpriteName=null;

    public string CurrentSubCharacterSpriteName=null;

    public string location="mansion";

    public string activeCharacter=null;

    public string saveName=null;



}
