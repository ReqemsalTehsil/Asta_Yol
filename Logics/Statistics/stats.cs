using TMPro;
using UnityEngine;
using System;
public class stats : MonoBehaviour
{
    public TextMeshProUGUI stat1;
    public TextMeshProUGUI stat2;
    public TextMeshProUGUI stat3;
    void Start()
    {
        //setting default text values
        stat1.text = "Imtahanların sayı:\n\n";
        stat2.text = "Uğurla tamamlanan:\n\n";
        stat3.text = "Uğursuz nəticələr:\n\n";

        // using PlayerPrefs.GetSmth("key", defaultVal);

        stat3.text += Convert.ToString(PlayerPrefs.GetInt("fail", 0));
        stat2.text += Convert.ToString(PlayerPrefs.GetInt("pass", 0));
        stat1.text += Convert.ToString(PlayerPrefs.GetInt("exams", 0));
    }

    
}
