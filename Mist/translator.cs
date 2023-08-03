using TMPro;
using UnityEngine;

public class translator : MonoBehaviour
{
    public TextMeshProUGUI messageBoxText;

    void Start()
    {
        if(PlayerPrefs.GetString("language", "") == "")
        {
            messageBoxText.text = "sizdə\n səhv cavablar\n yoxdur";
        }
        else
        {
            messageBoxText.text = "у вас\n нет ошибок";
        }
    }
}
