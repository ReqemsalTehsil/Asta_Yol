using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/*
    mistakes are located in file MistId
*/

public class JsonReadWrite : MonoBehaviour
{
    
    private class Mistakes
    {
        public List<byte> list;

        public Mistakes(List<byte> oldMistakes)
        {
            list = new List<byte>(oldMistakes);
        }

    }


    public static void saveMistakeToJson(byte mistakeId)
    {
        // now lets add this mistake if its index hasn`t been added

        
        Mistakes mistakesNew = new Mistakes(getMistakes()); // getting old indexes if file with indexes exists

        if(mistakesNew.list.Contains(mistakeId))return; // if we already have the index saved, we simply get outta the function

        mistakesNew.list.Add(mistakeId); // adding mistakeId

        string json = JsonUtility.ToJson(mistakesNew); // parsing into json notation

        File.WriteAllText(getPath("MistId"), json); // saving data to file MistId 
    }

    private static string getPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    public static List<byte> getMistakes()
    {
        if(!File.Exists(getPath("MistId")))return new List<byte>(); // if the file doesn`t exist we return pointer to empty list

        string json = File.ReadAllText(getPath("MistId")); // parsing indexes from file in json notation

        Mistakes oldMistakes = JsonUtility.FromJson<Mistakes>(json); // parsing json notation to obj
        
        return oldMistakes.list; // returning list
    }

    public static void cleanMistakes()
    {
        //we will simply delete mistakes file
        File.Delete(getPath("MistId"));
    }

    public static void removeMistake(byte id)
    {
        Mistakes newMistakeList = new Mistakes(getMistakes()); // copying old data to new mistlist

        newMistakeList.list.Remove(id); // removing id from old list

        string json = JsonUtility.ToJson(newMistakeList); // parsing into json format

        File.WriteAllText(getPath("MistId"), json); // saving data to file MistId 
    }

    public static byte getMistakeAt(byte i)
    {
        return getMistakes()[i];
    }
}
