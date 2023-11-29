using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public string StoryStateJson=null;
    public characterData MainCharacterData=null;
    public List <characterData> SubCharactersData=null;

    public string CurrentMainCharacterSpriteName=null;

    public string CurrentSubCharacterSpriteName=null;

    public string location="mansion";

    public string activeCharacter=null;



}
