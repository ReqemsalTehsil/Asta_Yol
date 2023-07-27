using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examPassed : MonoBehaviour
{
    // reference to endMessage
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        if(changeQuestion.currentQuestionNumber == 255)obj.SetActive(true); // since 255 is like a flag that tells "all questions are answered and exam is passed"
        
    }

     
}
