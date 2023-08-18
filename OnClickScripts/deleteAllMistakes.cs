using UnityEngine.SceneManagement;
using UnityEngine;

public class deleteAllMistakes : MonoBehaviour
{
    public void deleteAll()
    {
        JsonReadWrite.cleanMistakes();
        SceneManager.LoadScene(3);
    }
}
