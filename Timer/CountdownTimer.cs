using UnityEngine;
using System;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private static float currentTime; // total time in seconds
    private static float startingTime = 900f;
    private static byte minutes = 5;            // 5 mins are given for the quiz
    private static byte seconds = 60;
    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {   
        currentTime -= 1*Time.deltaTime;
        minutes = (byte)(currentTime/60);
        seconds = (byte)(currentTime%60);
        
       countdownText.text = string.Format("{0}:{1}{2}", minutes, (seconds<10)? "0":"", seconds);
        
    }
}
