using TMPro;
using UnityEngine;

public class texts : MonoBehaviour
{
    public TextMeshProUGUI cont;
    public TextMeshProUGUI menu;
    public TextMeshProUGUI menu1;
    public TextMeshProUGUI replay;
    public TextMeshProUGUI failMessage;
    public TextMeshProUGUI passMessage;

    void Start(){
        // between the time scene is loaded and first frame is shown
       

        if(language.get() == ""){
            cont.text = "Davam et";
            menu.text = "Ana səhifə";
            menu1.text = "Ana səhifə";
            replay.text = "Yenidən Başla";
            failMessage.text = "Təəssüflər,\nimtahandan\nkeçə bilmədiniz";
            passMessage.text = "Təbrik edirik\nSiz imtahanı uğurla\nbitirdiniz";
        }
        else{
            cont.text = "Продолжить";
            menu.text = "В меню";
            menu1.text = "В меню";
            replay.text = "Заново";
            failMessage.text = "К сожалению,\nвы не прошли\nэкзамен";
            passMessage.text = "Поздравляем, вы успешно прошли\nэкзамен";
        }
    }
}
