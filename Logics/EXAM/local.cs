using UnityEngine;
using System;
public class local : MonoBehaviour
{
    // everything here should be cleaned after each time scene is loaded (indexes also)
    private static bool[] answer_flag;
    private static bool[] mistake;

    //local data to be installed to cache 
    public static byte answers;
    public static byte mistakes;
    public static byte[] chosen_answer;

    public static bool isAnswered(byte i)
    {
        return answer_flag[i];
    }
    public static void setAnswered(byte i)
    {
        answer_flag[i] = true;
        answers++;
    }

    public static bool isMistake(byte i){
        return mistake[i];
    }
    public static void setMistake(byte i){
        mistake[i] = true;
        mistakes++;

        addMistakeId(); // adding answered question Id to statistics
    }
    public static void SetAnswer(byte x)
    {
        chosen_answer[changeQuestion.currentQuestionNumber] = x;
    }
    public static byte getAnswer(byte i)
    {
        return chosen_answer[i];
    }
    public static byte getUnasweredQUestionNumber(){
        if( (answers == 9 && mistakes == 0) || (answers == 10 && mistakes == 1)) 
        {
            //case when exam is passed so we summon messageBox
            PlayerPrefs.SetInt("pass", PlayerPrefs.GetInt("pass", 0) + 1);
        return 255; // messageBox flag
        }

        //if chosen answer is wrong, we simply don`t change question just stay in same one
        if(isMistake(changeQuestion.currentQuestionNumber))return changeQuestion.currentQuestionNumber;

        //finding closest unaswered question
        for(byte i = (byte)(changeQuestion.currentQuestionNumber+1); i < 10; i++){
            if(!isAnswered(i))return i;
        }
        for(byte i = (byte)(changeQuestion.currentQuestionNumber-1); i>=0; i--){
/*
                 NOTION!!!!!!
            since we are using byte 
            after 0-- we will get 255, which ,in its turn, will create arrayIndexOutOfRange while checking isAnswered(255);
            so we had to add simple if(i == 255)break;
*/
            if(i == 255)break;
            if(!isAnswered(i))return i;
        }

    return changeQuestion.currentQuestionNumber; // will be achieved iff all questions are answered, so we return 255 as a flag for messageBox.
    }


    //local data will vanish as first frame of new loaded scene uploads
    void Start()
    {     // initialize local memory that soon should be saved in cache
        //initialization
        mistakes = 0;
        answers = 0;
        answer_flag = new bool [10];
        mistake = new bool [10]; 
        chosen_answer = new byte [10];

    }

    public static void addMistakeId()
    {
        JsonReadWrite.saveMistakeToJson(Indexes.getIndex(changeQuestion.currentQuestionNumber));
    }


}
