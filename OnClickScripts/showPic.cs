using UnityEngine;
using UnityEngine.UI;
public class showPic : MonoBehaviour
{
    public GameObject box;
    public GameObject prevImage; // to remove previous image on bg, while showing it on full size
    public void show()
    {
        prevImage.SetActive(false);
        box.SetActive(true);
    }

    public void remove()
    {
        prevImage.SetActive(true);
        box.SetActive(false);
    }
}
