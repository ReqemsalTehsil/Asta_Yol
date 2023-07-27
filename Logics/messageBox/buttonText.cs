using TMPro;
using UnityEngine;

public class buttonText : MonoBehaviour
{
    public TextMeshProUGUI cont;
    public TextMeshProUGUI menu;
    public TextMeshProUGUI menu1;
    public TextMeshProUGUI replay;

    void Start(){
        // between the time scene is loaded and first frame is shown
       

        if(language.get() == ""){
            cont.text = "Davam et";
            menu.text = "Ana səhifə";
            menu1.text = "Ana səhifə";
            replay.text = "Yenidən Başla";
        }
        else{
            cont.text = "Продолжить";
            menu.text = "В меню";
            menu1.text = "В меню";
            replay.text = "Заново";
        }
    }
}
