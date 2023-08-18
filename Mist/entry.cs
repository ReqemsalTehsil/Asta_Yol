using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class entry : MonoBehaviour
{   
    public static bool rightIsClicked,leftIsClicked,answerIsClicked;
    public GameObject hint;
    public GameObject[] button = new GameObject[4];
    public static byte currentQuestionNumber; // range: from 0 to 9
    
    void Start(){
        currentQuestionNumber = 0;
        answerIsClicked =false;
        rightIsClicked = false;
        leftIsClicked = false;
    }
    
    public void showAnswers()
    {
        for(byte i = 0; i < 4; i++)
        {
        if(i == DBconnector.getAnswer())button[i].GetComponent<Image>().color = new Color32(43,248,80,255); // answer is green
        else button[i].GetComponent<Image>().color = new Color32(250,65,65,255); //red 
        }
    }
   
    public void nextQuestion(bool right)
    {
        if(right)
        {
            currentQuestionNumber++;
        }
        else
        {
            currentQuestionNumber--;
        }
        
        DBconnector.updateData = true;
    }

    public void Update(){
         
        if(answerIsClicked){ showAnswers();answerIsClicked = false;}
        if(rightIsClicked){ nextQuestion(true); rightIsClicked = false; }
        if(leftIsClicked){ nextQuestion(false); leftIsClicked = false; }
    }
}
