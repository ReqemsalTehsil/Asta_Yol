using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examCalc : MonoBehaviour
{
    public void addExam()
    {
        PlayerPrefs.SetInt("exams", PlayerPrefs.GetInt("exams", 0) + 1);
    }
}
