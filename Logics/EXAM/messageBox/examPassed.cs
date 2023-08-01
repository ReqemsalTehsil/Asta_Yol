using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examPassed : MonoBehaviour
{
    // reference to endMessage
    public GameObject obj;
    public GameObject home_button;


    // Update is called once per frame
    void Update()
    {
        if(changeQuestion.currentQuestionNumber == 255 && !home_button.activeSelf)
        {
            obj.SetActive(true);
        }
         // since 255 is like a flag that tells "all questions are answered and exam is passed"
        // if we have home button there is no any need in that message box since it only happens iff in continue mode
    }

    void Start(){
        obj.SetActive(false);
    }
     
}
