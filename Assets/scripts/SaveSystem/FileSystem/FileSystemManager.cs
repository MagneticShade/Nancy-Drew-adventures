using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileSystemManager 
{
    private string dataDirPath="";
    private string dataFileName="";

    public FileSystemManager(string dataDirPath,string dataFileName){
        this.dataDirPath=dataDirPath;
        this.dataFileName=dataFileName;
    }

    // public SaveData Load(){

    // }

    public void Save(SaveData data){
        string fullpath=Path.Combine(dataDirPath,dataFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
        string dataToStore=JsonUtility.ToJson(data,true);

        using(FileStream stream=new FileStream(fullpath,FileMode.Create)){

            using (StreamWriter writer=new StreamWriter(stream)){
                writer.Write(dataToStore);
            }
        }
    }

}
