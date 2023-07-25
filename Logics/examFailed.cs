using UnityEngine;
using System;

// we will need obj reference;
public class examFailed : MonoBehaviour
{

public GameObject obj; 

bool continueClicked = false;
void Update(){
    if(local.mistakes == 2 && !continueClicked)obj.SetActive(true);
    
}
}
//file should be hung on obj itself