using TMPro;
using UnityEngine;

public class hint : MonoBehaviour
{
    public TextMeshProUGUI hint_text;
    public GameObject box;
    public GameObject hint_on_image; // to put hint_on image over hint image
    public void showBox()
    {
        box.SetActive(true);
        hint_on_image.SetActive(true);
    }
    public void removeBox()
    {
        box.SetActive(false);
        hint_on_image.SetActive(false);
    }
}
