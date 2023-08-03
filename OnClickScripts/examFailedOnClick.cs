using UnityEngine;
using UnityEngine.SceneManagement;
using System;
// we will need obj reference;

public class examFailedOnClick : MonoBehaviour
{
    public GameObject timer;      // timer reference
    public GameObject obj;        // messageBox reference
    public GameObject homeButton; // button to return to menu will be activated if continue is pressed

    public void davamEt(bool yes){

        if(yes)
        {
            obj.SetActive(false);
            timer.SetActive(false);
            homeButton.SetActive(true);
        } // removing timer with messageBox and adding homeButton;
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