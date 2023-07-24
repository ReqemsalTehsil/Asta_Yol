using UnityEngine;
using UnityEngine.SceneManagement;
using System;
// we will need obj reference;

private GameObject obj; 

public void continue(bool yes){
    if(yes)obj.SetActive(false);
    else {
        // probably we will have to clean all data in :
        //local.clean()
        //indexes do something
        // obj.SetActive(true); probably should be turned on
        SceneManager.LoadScene(SceneId); // back to main menu
    }
}