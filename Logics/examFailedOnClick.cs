using UnityEngine;
using UnityEngine.SceneManagement;
using System;
// we will need obj reference;
public class examFailedOnClick : MonoBehaviour
{

    public GameObject obj; 

    public void davamEt(bool yes){
        if(yes)obj.SetActive(false);
        else {
            // probably we will have to clean all data in :
            //local.clean()
            //indexes do something
            // obj.SetActive(false); probably should be turned off
            SceneManager.LoadScene(0); // back to main menu
        }
    }
}