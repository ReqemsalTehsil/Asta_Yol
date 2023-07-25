using UnityEngine;
using UnityEngine.SceneManagement;
using System;
// we will need obj reference;
public class examFailedOnClick : MonoBehaviour
{

    public GameObject obj; 

    public void davamEt(bool yes){
        if(yes){obj.SetActive(false);}
        else {
            /*
               BEFORE GETTING MAIN MENU WE HAVE TO CLEAN AND RETURN SOME DATA TO INITIAL STATES

               1. all static flags in local should be reinitialized
               2. changeQuestion.currentQuestion = 0
            */
            SceneManager.LoadScene(0); // back to main menu
        }
    }
}