using UnityEngine;

public class removeMessage : MonoBehaviour
{
    public GameObject obj;

    public void remove()
    {
        obj.SetActive(false);
    }
}
