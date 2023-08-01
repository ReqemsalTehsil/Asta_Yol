using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatClear : MonoBehaviour
{
    // will delete entire statistics 
    public void Clear()
    {
        PlayerPrefs.DeleteKey("fail");
        PlayerPrefs.DeleteKey("exams");
        PlayerPrefs.DeleteKey("pass");
    }
}
