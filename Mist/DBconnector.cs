using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class DBconnector : MonoBehaviour
{   
    //some flags
    
    public static bool updateData;
    public static bool updateScreen;
    public static bool removeLoading =false;
    public static bool dataIsLoaded = false;
    public static bool[] isDeleted;
     
    // some references to UI objects
    public GameObject hintImage;
    public GameObject messageBox;
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject imageHolder; // to remove image if there is no
    public Image image,image1; // for question
    public GameObject[] button = new GameObject[4];
    public TextMeshProUGUI question_text; // question text reference
    public TextMeshProUGUI[] button_text = new TextMeshProUGUI[4]; // button text reference
    public TextMeshProUGUI hint_text; // text for hint messageBox

    //variables that handle data from db
    private static string question;
    private static string[] buttonText = new string[4];
    private static byte answer;
    private static string hint;
    //

    private static DatabaseReference dbRef;
    public static byte numberOfQuestions = 60;
    // Start is called before the first frame update
    void Start()
    {
        updateScreen = false;
        updateData = false;
        entry.currentQuestionNumber = 0;
        if(JsonReadWrite.getMistakes().Count == 0){messageBox.SetActive(true);removeLoading = true;}
        else
        {   
            // 

            dbRef = FirebaseDatabase.DefaultInstance.RootReference; 
            question_text.text = "loading...";

            //
            
            
        loadData(); // getting data to fill question, answer, buttonText fields
        }
    }

    void Update(){
        if(updateData){loadData(); updateData = false;}
        if(dataIsLoaded){updScreen(); dataIsLoaded = false;}
    }
   
    public void loadData()
    {
        Debug.Log("Data is uploading");
        StartCoroutine(getData(JsonReadWrite.getMistakeAt(entry.currentQuestionNumber)));
    }
    
    public void updScreen()
    {
        Debug.Log("Screen Is UPdated");
        byte currentQuestionNumber = entry.currentQuestionNumber;
        
        question_text.text = question; // changing question 
        hint_text.text = hint; // changing hint 
        loadSprite(); // loading sprite

        // setting Right/Left buttons to switch questions

        if(currentQuestionNumber == 0){rightButton.SetActive(true);leftButton.SetActive(false);} // at the beginning of list we have only rightbutton
        if(currentQuestionNumber == JsonReadWrite.getMistakes().Count-1){leftButton.SetActive(true);rightButton.SetActive(false);} // in the end we will only have leftbutton
        if(currentQuestionNumber > 0 && currentQuestionNumber < JsonReadWrite.getMistakes().Count - 1){rightButton.SetActive(true);leftButton.SetActive(true);} // in other cases we have both buttons
        if(JsonReadWrite.getMistakes().Count == 1){leftButton.SetActive(false);rightButton.SetActive(false);}
        
        //if there is no any hint it won`t appear

        if(hasHint())hintImage.SetActive(true);
        else hintImage.SetActive(false);
        //answer buttons` color, visibility and text
        for(byte i=0 ; i < 4; i++)
        {
            //button colors
            button[i].GetComponent<Image>().color = new Color32(255,255,255,255); // white button

            //button text
            button_text[i].text = getButtonText(i);

            //button visibility
            if(button_text[i].text == "")button[i].SetActive(false); // button vanishes if it has no text
            else button[i].SetActive(true); // display button if it has content
        }
        
        Debug.Log("answer : " + getAnswer());
    }
    
    
    public IEnumerator getData(byte index)
    {
        var question = dbRef.Child("Questions" + language.get()).Child(Convert.ToString(index)).GetValueAsync();

        yield return new WaitUntil(predicate: () => question.IsCompleted);

        if(question.Exception != null)Debug.LogError(question.Exception);
        else if(question.Result == null)Debug.Log("Null");
        else{
           // Debug.Log("Q: " + i.ToString() + " with real index: " + Indexes.getIndex(i).ToString());
            DataSnapshot snapshot = question.Result;    //getting snapshot
            //assigning gotten data
            setAnswer(Convert.ToByte(snapshot.Child("answers").Child("answer").Value.ToString())); // assigning answer
            setQuestion(Convert.ToString(snapshot.Child("question").Value).ToString()); // assigning question text   should be CHANGED!!!!
            setHint(Convert.ToString(snapshot.Child("hint").Value).ToString()); // taking hints

            if(snapshot.Child("answers").Child("answer").Value == null){yield return new WaitForSeconds(1);StartCoroutine(getData(index));Debug.LogError($"NULL RETURNED AT {index} at byte answer");}
            if(snapshot.Child("question").Value == null){yield return new WaitForSeconds(1);StartCoroutine(getData(index));Debug.LogError($"NULL RETURNED AT {index} at question");}
            if(snapshot.Child("hint").Value == null){yield return new WaitForSeconds(1);StartCoroutine(getData(index));Debug.LogError($"NULL RETURNED AT {index} hint");}

            for(byte j=0; j < 4; j++){
            setButtonText(snapshot.Child("answers").Child(j.ToString()).Value.ToString(), j); // setting buttons` texts 
            //test for collection of data
            }
            Debug.Log(getQuestion());
            dataIsLoaded = true;removeLoading = true; // flag of completely loaded data
        }
    }

    //getters and setters are required since in IEnumberator we cannot use indexes (idk why...)
    private string getQuestion(){return question;}
    public static byte getAnswer(){return answer;} 
    private string getButtonText(byte i){return buttonText[i];}
    private static string getHint(){return hint;}

    private void setButtonText(string str, byte j){buttonText[j] = str;}
    private void setQuestion(string str){question = str;}
    private void setAnswer(byte ans){answer = ans;}
    private void setHint(string str){hint = str;}

    public static bool hasHint(){
        if(getHint() == "")return false;
        return true;
    }


public void loadSprite()
    {
        byte index = JsonReadWrite.getMistakeAt(entry.currentQuestionNumber); // index is added to correspond to db and resources folder

        string dbIndex = index.ToString();
        //Debug.Log($"pic value is {Resources.Load<Sprite>("pictures/cat2/" + dbIndex)});
        
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
