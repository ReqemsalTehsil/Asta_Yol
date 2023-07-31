using UnityEngine;

public class answerToQuestion : MonoBehaviour
{
    public static void ColorChange(int x){
        if(local.isAnswered(changeQuestion.currentQuestionNumber))return; // if question is already answered nothing happens by clicking the button
        //else
        local.SetAnswer((byte)x); // to save info about chosen answer
        local.setAnswered(changeQuestion.currentQuestionNumber); // saving that the question is answered

        //if(x == correct answer)                         saving that it is correctly answered by leaving local.mistakes[i] = 0
        
        if((byte) x != database.getAnswer())local.setMistake(changeQuestion.currentQuestionNumber); //saving that it is a mistake
        

        
        changeQuestion.buttonIsClicked = true;  // then we changeSquareColor and changeQuestion


    }
}
