using UnityEngine;
using System;

// we will need obj reference;

private GameObject obj; 

public void Update(){
    if(local.mistakes == 3)obj.SetActive(true);
}

//file should be hung on obj itself