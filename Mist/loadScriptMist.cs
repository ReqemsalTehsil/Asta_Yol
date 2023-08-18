using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class loadScriptMist : MonoBehaviour
{
    public Image image;
    public GameObject objectImage;
    public GameObject loadingObj;
    public GameObject rubbishBin;

    
    // Start is called before the first frame update
    void Start()
    {
        DBconnector.removeLoading = false;
        DBconnector.dataIsLoaded = false;
        objectImage.SetActive(true);
        
        
        Debug.Log("loading starts");
        StartCoroutine(loading());
    }

    // Update is called once per frame

    
//loading pic scripts 
private IEnumerator loading()
{
    while(!DBconnector.removeLoading)
    {
        Debug.Log("loading starts");
        
        for(int i = 1; i < 38; i++)
        {
            image.sprite = Resources.Load<Sprite>("mistakes_scene/" + i );
            yield return new WaitForSeconds(0.02f);
        }
     
    }
   
    objectImage.SetActive(false);    
}

}
