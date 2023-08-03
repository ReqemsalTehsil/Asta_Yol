using UnityEngine.SceneManagement;
using UnityEngine;

public class delete : MonoBehaviour
{
    public void deleteCurrentMistake()
    {
        JsonReadWrite.mistakeRemove(JsonReadWrite.getMistakes()[entry.currentQuestionNumber]);
        SceneManager.LoadScene(3);
    }

    public void deleteAllMistakes()
    {

    }
}
