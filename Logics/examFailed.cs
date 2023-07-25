using UnityEngine;
using System;

// we will need obj reference;
public class examFailed : MonoBehaviour
{

    public GameObject obj; 

    bool continueClicked;

    void Start(){
    continueClicked = false; 
    }

    void Update(){
        if(local.mistakes == 2 && !continueClicked){obj.SetActive(true);CountdownTimer.Stop();continueClicked = true;}

        // we created message BOX

        // we stopped CountdownTimer until the response 
        
    }
}
//file should be hung on obj itself