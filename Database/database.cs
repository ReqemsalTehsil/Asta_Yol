using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class database : MonoBehaviour
{   
    public static bool removeLoading =false;
    public static bool dataIsLoaded = false;
     
    // some references to UI objects
    public GameObject imageHolder; // to remove image if there is no
    public Image image,image1; // for question
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
    public static byte numberOfQuestions = 60;
    // Start is called before the first frame update
    void Start()
    {

        //add exam to statistics 

        //reinitialization

        question =new string[10];
        buttonText = new string[10,4];
        answer = new byte[10];
        hint = new string[10];
        // 

        dbRef = FirebaseDatabase.DefaultInstance.RootReference; 
        question_text.text = "loading...";
        Indexes.generateRandomIndexes(); // generate "random" question indexes for database

        
        for(byte i=0; i < 10; i++)
        {
            StartCoroutine(getData(i)); // getting data to fill question, answer, buttonText fields
        }
        
    }

    void Update(){
        if(updateRequested){requestUpdate(); updateRequested = false;}
    }
   
    
    public void requestUpdate(){
       
        question_text.text = question[changeQuestion.currentQuestionNumber]; // changing question 
        hint_text.text = hint[changeQuestion.currentQuestionNumber]; // changing hint 
        loadSprite(); // loading sprite
        for(int i=0 ; i < 4; i++){
            button_text[i].text = buttonText[changeQuestion.currentQuestionNumber, i];
            if(button_text[i].text == "")button[i].SetActive(false); // button vanishes if it has no text
            else button[i].SetActive(true); // display button if it has content
        }
        Debug.Log("answer : " + getAnswer() + "for index: "+ Indexes.getIndex(changeQuestion.currentQuestionNumber));
    }
    
    public static bool isLoaded(){
        for(byte i =0; i < 10; i++)if(question[i] == null)return false;
        return true;
    }
    public IEnumerator getData(byte i)
    {
        var question = dbRef.Child("Questions" + language.get()).Child((Indexes.getIndex(i)).ToString()).GetValueAsync();   // 

        yield return new WaitUntil(predicate: () => question.IsCompleted);

        if(question.Exception != null)Debug.LogError(question.Exception);
        else if(question.Result == null)Debug.Log("Null");
        else{
           
            DataSnapshot snapshot = question.Result;    //getting snapshot
            

            //test for any bugs in db
            if(snapshot.Child("answers").Child("answer").Value == null){SceneManager.LoadScene(1); yield return new WaitForSeconds(1);StartCoroutine(getData(i));Debug.LogError($"NULL RETURNED AT {Indexes.getIndex(i)} at byte answer");}
            if(snapshot.Child("question").Value == null){SceneManager.LoadScene(1);yield return new WaitForSeconds(1);StartCoroutine(getData(i));Debug.LogError($"NULL RETURNED AT {Indexes.getIndex(i)} at question");}
            if(snapshot.Child("hint").Value == null){SceneManager.LoadScene(1);yield return new WaitForSeconds(1);StartCoroutine(getData(i));Debug.LogError($"NULL RETURNED AT {Indexes.getIndex(i)} hint");}


            //assigning gotten data
            setAnswer(Convert.ToByte(snapshot.Child("answers").Child("answer").Value.ToString()), i); // assigning answer
            setQuestion(Convert.ToString(snapshot.Child("question").Value).ToString(), i); // assigning question text   should be CHANGED!!!!
            setHint(Convert.ToString(snapshot.Child("hint").Value).ToString(), i); // taking hints

            for(byte j=0; j < 4; j++){
            setButtonText(snapshot.Child("answers").Child(j.ToString()).Value.ToString(), i, j); // setting buttons` texts 
            //test for collection of data
            if(snapshot.Child("answers").Child(j.ToString()).Value == null)Debug.LogError($"NULL RETURNED AT {Indexes.getIndex(i)}");
            }
            
                    if(isLoaded()){Debug.Log("DATA IS COLLECTED!!!!");dataIsLoaded = true;removeLoading = true; } // flag of completely loaded data

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


public void loadSprite()
    {
        byte index = Indexes.getIndex(changeQuestion.currentQuestionNumber); // index is added to correspond to db and resources folder

        string dbIndex = index.ToString();

        
        float scaler = 1.2f; // scaler for full size pic
        //we will separate each category for corresponding width and height
        
        this.imageHolder.SetActive(true);
        //cat 1
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat1/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(139.15f,135.7f);

            image1.rectTransform.sizeDelta = new Vector2(139.15f*scaler,135.7f*scaler); // for full size view
        //cat 2 
        if(this.image.sprite == null) //iff didn`t find in cat 1
        {
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat2/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(173,60);

            image1.rectTransform.sizeDelta = new Vector2(173*scaler,60*scaler); // for full size view
        }
        //cat 3
        if(this.image.sprite == null) //iff didn`t find in cat 2
        {
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat3/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(85,119);

            image1.rectTransform.sizeDelta = new Vector2(85*scaler,119*scaler); // for full size view
        }
        //cat 4
        if(this.image.sprite == null) //iff didn`t find in cat 3
        {
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat4/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(201,60);

            image1.rectTransform.sizeDelta = new Vector2(201*scaler,60*scaler); // for full size view
        }
        //cat 5
        if(this.image.sprite == null) //iff didn`t find in cat 4
        {
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat5/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(121,118);

            image1.rectTransform.sizeDelta = new Vector2(121*scaler,118*scaler); // for full size view
        }
        //cat 6
        if(this.image.sprite == null) //iff didn`t find in cat 1
        {
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat6/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(160,98);

            image1.rectTransform.sizeDelta = new Vector2(160*scaler,98*scaler); // for full size view
        }
        //cat 7
        if(this.image.sprite == null) //iff didn`t find in cat 1
        {
            this.image.sprite = this.image1.sprite = Resources.Load<Sprite>("pictures/cat7/" + dbIndex);
            image.rectTransform.sizeDelta = new Vector2(192,84);

            image1.rectTransform.sizeDelta = new Vector2(192*scaler,84*scaler); // for full size view
        }
        if(this.image.sprite == null)imageHolder.SetActive(false);
    }
}
