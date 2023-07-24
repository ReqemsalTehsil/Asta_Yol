using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class local : MonoBehaviour
{
    // everything here should be cleaned after each time scene is loaded (indexes also)
    private static bool[] answer_flag = new bool [10];
    private static bool[] mistake = new bool [10];


    public static bool isAnswered(byte i){
        return answer_flag[i];
    }
    public static void setAnswered(byte i){
        answer_flag[i] = true;
    }

    public static bool isMistake(byte i){
        return mistake[i];
    }
    public static void setMistake(byte i){
        mistake[i] = true;
    }
    public static byte getUnasweredQUestionNumber(){
        for(byte i = (byte)(changeQuestion.currentQuestionNumber+1); i < 10; i++){
            if(!isAnswered(i))return i;
        }
        for(byte i = (byte)(changeQuestion.currentQuestionNumber-1); i>=0; i--){
            if(!isAnswered(i))return i;
        }
        Debug.Log("gonna be filled");
    return changeQuestion.currentQuestionNumber;
    }
}
