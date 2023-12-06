using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileSystemManager 
{
    private string dataDirPath="";
    public FileSystemManager(string dataDirPath){
        this.dataDirPath=dataDirPath;
    }

    public SaveData QuickLoad(){
        string fullpath=Path.Combine(dataDirPath,"quicksave.txt");
        return Load(fullpath);
    }
    public SaveData LoadMenu(string fileName){
        string fullpath=Path.Combine(dataDirPath,fileName);
        return Load(fullpath);
    }
    public SaveData Load(string fullpath){
         SaveData loadedData=null;
        if(File.Exists(fullpath)){

                string dataToLoad="";
                using (FileStream stream = new FileStream(fullpath,FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream)){
                        dataToLoad=reader.ReadToEnd();  
                    }
                }

                loadedData = JsonUtility.FromJson<SaveData>(dataToLoad);
        }
        return loadedData;
    }

    public List<FileInfo> LoadSaves(){
        var dir = new DirectoryInfo(dataDirPath);
        List<FileInfo> saves = new List<FileInfo>(dir.GetFiles("*.txt"));
        return saves;
    }

    public void Save(SaveData data,string fileName){
        string fullpath=Path.Combine(dataDirPath,fileName+".txt");
        data.saveName=fileName;
        Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
        string dataToStore=JsonUtility.ToJson(data,true);

        using(FileStream stream=new FileStream(fullpath,FileMode.Create)){

            using (StreamWriter writer=new StreamWriter(stream)){
                writer.Write(dataToStore);
            }
        }
    }

    public void SaveDelete(string fileName){
        string fullpath=Path.Combine(dataDirPath,fileName);
        if (File.Exists(fullpath)) {
                    // If file found, delete it
                    File.Delete(fullpath);
                    Console.WriteLine("File deleted.");
                }
    }
}
