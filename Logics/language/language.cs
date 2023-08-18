using UnityEngine;
using TMPro;
public class language : MonoBehaviour
{
    
    /*
        language abbreviations
        1. Az is "" - empthy string // by default
        2. Rus is "Ru"

    */
    
    // Start is called before the first frame update
   
   
    public static void change()
    {
        
        // abb should be one of abbreviations above
        if(get() == "")PlayerPrefs.SetString("language","Ru");
        else PlayerPrefs.SetString("language","");

    }
    public static string get(){
        
        return PlayerPrefs.GetString("language");
    }

    void Start()
    {
        //if it is first time game is uploaded 
        // we have to initially set lang as "", which means Az by default
        if(!PlayerPrefs.HasKey("language"))PlayerPrefs.SetString("language","");
    }
}
