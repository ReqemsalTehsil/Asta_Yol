using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public void Right()
    {
        if(entry.currentQuestionNumber == JsonReadWrite.getMistakes().Count - 1)return; // removes bug with fast click on rightButton causing outOfRange error
        entry.rightIsClicked = true;
    }

    public void Left()
    {
        if(entry.currentQuestionNumber == 0)return; // removes bug with fast click on leftButton causing outOfRange error
        entry.leftIsClicked = true;
    }
}
