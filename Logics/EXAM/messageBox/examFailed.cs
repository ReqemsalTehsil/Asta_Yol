using UnityEngine;
using System;

// we will need obj reference;
public class examFailed : MonoBehaviour
{

    public GameObject obj; 
    public GameObject home;
    bool continueClicked;

    void Start(){
    continueClicked = false; 
    }

    void Update(){
        if(local.mistakes == 2 && !continueClicked)
        {
            // saving mistake
            PlayerPrefs.SetInt("fail", PlayerPrefs.GetInt("fail", 0) + 1);
            obj.SetActive(true);
            CountdownTimer.Stop();
            home.SetActive(true);
            continueClicked = true;
            
        }

        // we created message BOX

        // we stopped CountdownTimer until the response 
        
    }
}
//file should be hung on obj itself