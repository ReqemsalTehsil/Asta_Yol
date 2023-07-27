using UnityEngine;

public class local : MonoBehaviour
{
    // everything here should be cleaned after each time scene is loaded (indexes also)
    private static bool[] answer_flag;
    private static bool[] mistake;

    //local data to be installed to cache 

    public static byte mistakes=0;

    public static void initialize(){
        mistakes = 0;
        answer_flag = new bool [10];
        mistake = new bool [10];
    }

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
        mistakes++;
    }
    public static byte getUnasweredQUestionNumber(){
       
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

    return changeQuestion.currentQuestionNumber;
    }
}
