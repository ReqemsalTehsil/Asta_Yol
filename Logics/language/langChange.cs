using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class langChange : MonoBehaviour
{
    public GameObject rus_pic;
    public GameObject az_pic;
    public void change(){
        Debug.Log("changing language from " + language.get());
        if(language.get() == ""){az_pic.SetActive(true);rus_pic.SetActive(false);}
        else {rus_pic.SetActive(true);az_pic.SetActive(false);}
        language.change();
    }
}
