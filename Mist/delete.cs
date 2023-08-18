using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class delete : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject messageBox;
    private bool startTimeCount;
    private double timeOfHeldButton;
    private double t0;
    void Start()
    {
        startTimeCount = false;
        timeOfHeldButton = 0.0;
        t0 = 0.0;
    }

    void Update()
    {
        if(startTimeCount)timeOfHeldButton = Time.time - t0;
        if(timeOfHeldButton >= 1)
        {
            messageBox.SetActive(true);
            timeOfHeldButton = 0.0;
        }
    }

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
        
        
        DBconnector.updateData = true;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if(!startTimeCount)
        {
            t0=Time.time;
            //Debug.Log(Time.time - t0);
            startTimeCount = true;
        }
       
        
    }
    
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        startTimeCount = false;
    }
    
}
