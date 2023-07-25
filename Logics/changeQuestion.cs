using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class changeQuestion : MonoBehaviour
{
    public static byte clickedAnswer;
    
    public static bool buttonIsClicked = false;
    public static bool squareIsClicked = false;
    public static byte squareNumber;
    public GameObject[] square = new GameObject[10];
    public GameObject[] button = new GameObject[4];
    public static byte currentQuestionNumber; // range: from 0 to 9
    
    void Start(){
        currentQuestionNumber = 0;
    }
    
    public void display(){
        database.updateRequested = true; // update info on question.text, button_text
        
        // if there is no text in the button -> button vanishes
        
    

        //  IF NOT ANSWERED
        if(!local.isAnswered(currentQuestionNumber)){

            //CURRENT SQUARE TO BLACK 
            square[currentQuestionNumber].GetComponent<Image>().color = new Color32(0,0,0,255); //black square
            TextMeshProUGUI tmp_component = square[currentQuestionNumber].GetComponentInChildren<TextMeshProUGUI>();
            tmp_component.color = new Color32(255,255,255,255); // white text
            for(byte i=0 ; i < 4; i++){
                    button[i].GetComponent<Image>().color = new Color32(255,255,255,255); // white button
                }
        }
        //IF ANSWERED we don`t change current square

        else{ // 1 - wrong, 2 - right

            //BUTTONS' COLOR
            for(byte i=0 ; i < 4; i++){
                if(i == database.getAnswer())button[i].GetComponent<Image>().color = new Color32(43,248,80,255); // answer is green
                else button[i].GetComponent<Image>().color = new Color32(250,65,65,255); //red 
            }
        }
        
    }
   
    public void nextQuestion(byte to_number = 20){ // since 20th question won`t exist we can use it as a flag
        if(to_number == currentQuestionNumber)return;
        //if question is unaswered,    we make text again black and white square
        if(!local.isAnswered(currentQuestionNumber)){         
        
        square[currentQuestionNumber].GetComponent<Image>().color = new Color32(255,255,255,255); // white square

        TextMeshProUGUI tmp_component = square[currentQuestionNumber].GetComponentInChildren<TextMeshProUGUI>(); //black text
        tmp_component.color = Color.black; //
        }

        //if question is answered, we don`t change anything since onClick we have changeSquareColor()

        //
        if(to_number == 20)currentQuestionNumber = local.getUnasweredQUestionNumber();
        else currentQuestionNumber = to_number;
        display();
    }

    public void Update(){
        if(database.dataIsLoaded){display();database.dataIsLoaded = false;} // evertrhing appears as all data is loaded from database 
        if(buttonIsClicked){changeSquareColor(); nextQuestion(); buttonIsClicked = false;}
        if(squareIsClicked){nextQuestion(squareNumber); squareIsClicked = false;}

    }
 
    public void changeSquareColor(){
        bool is_true = !(local.isMistake(currentQuestionNumber)); // true if question is answered correctly else false
        //for squares below
        //make green if true
        //make red else
        if(is_true) square[currentQuestionNumber].GetComponent<Image>().color = new Color32(0,255,0,255); 
        else  square[currentQuestionNumber].GetComponent<Image>().color = new Color32(255,0,0,255); 
    }

}
