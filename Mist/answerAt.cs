using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerAt : MonoBehaviour
{
    public void answer(int x)
    {
        // adding answer to localData

        if(mistLocal.isAnswered())return; // if question is already answered, nothing happens

        mistLocal.setAnswered();

        if((byte) x != DBconnector.getAnswer()) //if answer is wrong 
        {
            mistLocal.setWrong(); // saving in temp memory

        }
        else if(entry.currentQuestionNumber != JsonReadWrite.getMistakes().Count - 1)
        {
            entry.rightIsClicked = true;
            return;
        }

        entry.answerIsGiven = true; // triggering event iff answer is wrong
    }
}
