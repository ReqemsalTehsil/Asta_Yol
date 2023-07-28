using TMPro;
using UnityEngine;

public class langChange : MonoBehaviour
{
    public GameObject rus_pic;
    public GameObject az_pic;
    public TextMeshProUGUI start;
    public TextMeshProUGUI topics;

    public void change(){
        Debug.Log("changing language from " + language.get());
        if(language.get() == ""){
            az_pic.SetActive(true);rus_pic.SetActive(false);
            //after clicking the language is Ru
            start.text = "Начать Экзамен";
            topics.text = "Темы";
            }
        else {
            rus_pic.SetActive(true);az_pic.SetActive(false);
            //correspondingly Az
            start.text = "Imtahana Başla";
            topics.text = "Mövzular";
            }
        language.change();
    }
}