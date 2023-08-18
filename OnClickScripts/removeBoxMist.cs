using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeBoxMist : MonoBehaviour
{
    public GameObject messageBox;
    public void deleteMessageRemove()
    {
        messageBox.SetActive(false);
    }
}
