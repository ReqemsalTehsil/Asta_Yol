using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mistLocal : MonoBehaviour
{
    private static bool[] wrong; // local mistakes for mistake repetition scene
    private static bool[] answered;
    // Start is called before the first frame update
    void Start()
    {
        //reinitialization of variables

        wrong = new bool [10];
        answered = new bool[10];
    }

    public static void setWrong(){wrong[entry.currentQuestionNumber] = true;}
    public static bool isWrong(){return wrong[entry.currentQuestionNumber];}

    public static bool isAnswered(){return answered[entry.currentQuestionNumber];}
    public static void setAnswered(){answered[entry.currentQuestionNumber] = true;}
}
