using TMPro;
using UnityEngine;

public class translator : MonoBehaviour
{
    public TextMeshProUGUI messageBoxText;
    public TextMeshProUGUI deleteAllQuestion;
    public TextMeshProUGUI yes;
    public TextMeshProUGUI no;
    void Start()
    {
        if(PlayerPrefs.GetString("language", "") == "")
        {
            messageBoxText.text = "Sizdə səhv cavab yoxdur";
            deleteAllQuestion.text = "Bütün sualları\n silmək istədiyinizə\n əminsiniz?";
            yes.text = "Bəli";
            no.text = "Xeyr";
        }
        else
        {
            messageBoxText.text = "У вас нет ошибок";
            deleteAllQuestion.text = "Вы уверены,\n что хотите удалить\n все вопросы?";
            yes.text = "Да";
            no.text = "Нет";
        }
    }
}
