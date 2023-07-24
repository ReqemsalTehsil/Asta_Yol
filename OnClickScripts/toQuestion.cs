using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toQuestion : MonoBehaviour
{
    public void toSquare(int x){
        changeQuestion.squareIsClicked = true;
        changeQuestion.squareNumber = (byte)x;
    }
     
}
