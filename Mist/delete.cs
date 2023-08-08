using UnityEngine.SceneManagement;
using UnityEngine;

public class delete : MonoBehaviour
{
    public void deleteCurrentMistake()
    {
        JsonReadWrite.mistakeRemove(JsonReadWrite.getMistakes()[entry.currentQuestionNumber]);

        //before we request update we should contemplate of several cases

        // at 0 th index -> if there was only one mistake, we should summon messageBox after deleting last one, else do nothing
        // between the end and beginning -> do nothing
        //if we are at the end, index--
        Debug.Log($" number of mistakes after deleting {JsonReadWrite.getMistakes().Count}");
        Debug.Log($"old question number is {entry.currentQuestionNumber}");

        if(JsonReadWrite.getMistakes().Count == 0){SceneManager.LoadScene(3);return;}
        if(entry.currentQuestionNumber != 0 && entry.currentQuestionNumber == JsonReadWrite.getMistakes().Count){Debug.Log("last removed");entry.currentQuestionNumber--;}
        
        
        Debug.Log($" new question number is {entry.currentQuestionNumber}");
        DBconnector.updateRequested = true;
    }

    void Update()
    {
   
    }

    public void deleteAllMistakes()
    {

    }
}
