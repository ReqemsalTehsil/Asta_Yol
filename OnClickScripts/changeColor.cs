using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
     

    public static void ColorChange(int x){
        if(local.isAnswered(changeQuestion.currentQuestionNumber))return; // if question is already answered nothing happens by clicking the button
        //else
        local.setAnswered(changeQuestion.currentQuestionNumber); // saving that the question is answered

        //if(x == correct answer)                         saving that it is correctly answered by leaving local.mistakes[i] = 0
        
        if((byte) x != database.getAnswer())local.setMistake(changeQuestion.currentQuestionNumber); //saving that it is a mistake
        

        
        changeQuestion.buttonIsClicked = true;  // then we changeSquareColor and changeQuestion


    }
    
}
