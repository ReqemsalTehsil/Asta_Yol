using TMPro;
using UnityEngine;
using System;
public class stats : MonoBehaviour
{
    public TextMeshProUGUI stat1;
    public TextMeshProUGUI stat2;
    public TextMeshProUGUI stat3;
    public TextMeshProUGUI sifirla;
    void Start()
    {
        //setting default text values
        if(PlayerPrefs.GetString("language","") == "")
        {
        stat1.text = "Imtahanların sayı:\n\n";
        stat2.text = "Uğurla tamamlanan:\n\n";
        stat3.text = "Uğursuz nəticələr:\n\n";
        sifirla.text = "Sıfırla";
        }
        else
        {
            stat1.text = "Всего экзаменов:\n\n";
            stat3.text = "Проваленных:\n\n";
            stat2.text = "Пройденных:\n\n";
            sifirla.text = "Обнулить";
        }
        // using PlayerPrefs.GetSmth("key", defaultVal);

        stat3.text += Convert.ToString(PlayerPrefs.GetInt("fail", 0));
        stat2.text += Convert.ToString(PlayerPrefs.GetInt("pass", 0));
        stat1.text += Convert.ToString(PlayerPrefs.GetInt("fail", 0) + PlayerPrefs.GetInt("pass", 0));
    }

    
}
