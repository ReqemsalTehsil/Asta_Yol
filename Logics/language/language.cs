using UnityEngine;
using TMPro;
public class language : MonoBehaviour
{
    private static string lang ="";
    /*
        language abbreviations
        1. Az is "" - empthy string // by default
        2. Rus is "Ru"

    */
    
    // Start is called before the first frame update
   
   
    public static void change(){
        
        // abb should be one of abbreviations above
        if(lang == "")lang = "Ru";
        else lang = "";
        
        Debug.Log("Language: "+ lang);
    }
    public static string get(){
        
        return lang;
    }
}
