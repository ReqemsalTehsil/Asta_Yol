using Firebase.Database;
using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class database : MonoBehaviour
{   
    public static bool dataIsLoaded = false;
    private static bool[] dataLoadedAt = new bool[10];
    // some references to UI objects
    public GameObject[] button = new GameObject[4];
    public TextMeshProUGUI question_text; // question text reference
    public TextMeshProUGUI[] button_text = new TextMeshProUGUI[4]; // button text reference
    public TextMeshProUGUI hint_text; // text for hint messageBox
    //variables that handle data from db
    private static string[] question =new string[10];
    private static string[,] buttonText = new string[10,4];
    private static byte[] answer = new byte[10];
    private static string[] hint = new string[10];
    //
    public static bool updateRequested = false;
    private static DatabaseReference dbRef;
    public static byte numberOfQuestions = 31;
    // Start is called before the first frame update
    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference; 
        question_text.text = "loading...";
        Indexes.generateRandomIndexes(); // generate "random" question indexes for database

        for(byte i=0; i < 10; i++)StartCoroutine(getData(i)); // getting data to fill question, answer, buttonText fields
        
        
    }

    void Update(){
        if(updateRequested){requestUpdate(); updateRequested = false;}
    }
   
    
    public void requestUpdate(){
        Debug.Log("Hint : " + getHint(changeQuestion.currentQuestionNumber));
        question_text.text = question[changeQuestion.currentQuestionNumber];
        hint_text.text = hint[changeQuestion.currentQuestionNumber];
        for(int i=0 ; i < 4; i++){
            button_text[i].text = buttonText[changeQuestion.currentQuestionNumber, i];
            if(button_text[i].text == "")button[i].SetActive(false); // button vanishes if it has no text
            else button[i].SetActive(true); // display button if it has content
        }
        Debug.Log("answer : " + getAnswer());
    }
    
    public static bool isLoaded(){
        for(byte i =0; i < 10; i++)if(dataLoadedAt[i] == false)return false;
        return true;
    }
    public IEnumerator getData(byte i)
    {
        var question = dbRef.Child("Questions" + language.get()).Child((Indexes.getIndex(i)).ToString()).GetValueAsync();   // 

        yield return new WaitUntil(predicate: () => question.IsCompleted);

        if(question.Exception != null)Debug.LogError(question.Exception);
        else if(question.Result == null)Debug.Log("Null");
        else{
           // Debug.Log("Q: " + i.ToString() + " with real index: " + Indexes.getIndex(i).ToString());
            DataSnapshot snapshot = question.Result;    //getting snapshot
            //assigning gotten data
            setAnswer(Convert.ToByte(snapshot.Child("answers").Child("answer").Value.ToString()), i); // assigning answer
            setQuestion(Convert.ToString(snapshot.Child("question").Value).ToString(), i); // assigning question text   should be CHANGED!!!!
            setHint(Convert.ToString(snapshot.Child("hint").Value).ToString(), i); // taking hints

            for(byte j=0; j < 4; j++){
            setButtonText(snapshot.Child("answers").Child(j.ToString()).Value.ToString(), i, j); // setting buttons` texts 
        

            //test for collection of data
            
            
            }
            dataLoadedAt[i] = true;
        if(isLoaded()){Debug.Log("DATA IS COLLECTED!!!!");dataIsLoaded = true; } // flag of completely loaded data

        }
    }

    //getters and setters are required since in IEnumberator we cannot use indexes (idk why...)
    private string getQuestion(byte i){return question[i];}
    private byte getAnswer(byte i){return answer[i];}
    public static byte getAnswer(){return answer[changeQuestion.currentQuestionNumber];} // some kinda polymorphism for being called from outside
    private string getButtonText(byte i, byte j){return buttonText[i,j];}
    private static string getHint(byte i){return hint[i];}

    private void setButtonText( string str, byte i, byte j){buttonText[i,j] = str;}
    private void setQuestion(string str, byte i){question[i] = str;}
    private void setAnswer(byte ans, byte i){answer[i] = ans;}
    private void setHint(string str, byte i){hint[i] = str;}

    public static bool hasHint(){
        if(getHint(changeQuestion.currentQuestionNumber) == "")return false;
        return true;
    }



}
