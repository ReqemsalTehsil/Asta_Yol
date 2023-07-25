using UnityEngine;
using System;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private static float currentTime; // total time in seconds
    private static float startingTime = 900f;
    private static byte minutes;            // 5 mins are given for the quiz
    private static byte seconds;
    private static bool timeIsStopped;
    [SerializeField] TextMeshProUGUI countdownText;

    public static void Stop(){
        timeIsStopped = true;
    }
    public static void Resume(){
        timeIsStopped = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeIsStopped = false;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {  
        if(!timeIsStopped) {
        currentTime -= 1*Time.deltaTime;
        minutes = (byte)(currentTime/60);
        seconds = (byte)(currentTime%60);
        
       countdownText.text = string.Format("{0}:{1}{2}", minutes, (seconds<10)? "0":"", seconds);
        }
    }
}
