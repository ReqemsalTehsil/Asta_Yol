using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class entry : MonoBehaviour
{
    public static bool rightIsClicked,leftIsClicked;
    public static bool answerIsGiven;
    public static byte clickedAnswer;   
    public GameObject hint;
    public static bool buttonIsClicked = false;
    public GameObject[] button = new GameObject[4];
    public static byte currentQuestionNumber; // range: from 0 to 9
    
    void Start(){
        currentQuestionNumber = 0;
        answerIsGiven = false;
        rightIsClicked = false;
        leftIsClicked = false;
    }
    
    public void display()
    {
        Debug.Log("at display");
        DBconnector.updateRequested = true; // update info on question.text, button_text
        
        
        
    }
   
    public void nextQuestion(bool right){ // since 20th question won`t exist we can use it as a flag
        if(right)
        {
            currentQuestionNumber++;
        }
        else
        {
            currentQuestionNumber--;
        }
        display();
    }

    public void Update(){
        if(DBconnector.dataIsLoaded){display();DBconnector.dataIsLoaded = false;} // evertrhing appears as all data is loaded from database 
        if(answerIsGiven)
        {    display();
            answerIsGiven = false;
        }
        if(rightIsClicked){ nextQuestion(true); rightIsClicked = false;}
        if(leftIsClicked){ nextQuestion(false); leftIsClicked = false; }
    }
}
