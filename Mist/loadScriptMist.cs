using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScriptMist : MonoBehaviour
{
    public GameObject firstLoadingPic;
    public GameObject secondLoadingPic;
    public GameObject thirdLoadingPic;
    public GameObject loadingObj;
    public GameObject rubbishBin;

    
    // Start is called before the first frame update
    void Start()
    {
        DBconnector.removeLoading = false;
        DBconnector.dataIsLoaded = false;

        rubbishBin.SetActive(false);
        
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
    firstLoaded(); 

    yield return new WaitForSeconds(0.5f);

    secondLoaded();

    yield return new WaitForSeconds(0.5f);

    thirdLoaded();

    yield return new WaitForSeconds(0.5f);
    }
    allLoaded();
}

private void firstLoaded()
{
    firstLoadingPic.SetActive(true);
    secondLoadingPic.SetActive(false);
    thirdLoadingPic.SetActive(false);
}
private void secondLoaded()
{
    firstLoadingPic.SetActive(false);
    secondLoadingPic.SetActive(true);
}
private void thirdLoaded()
{
    secondLoadingPic.SetActive(false);
    thirdLoadingPic.SetActive(true);
}
private void allLoaded()
{
    loadingObj.SetActive(false);
    rubbishBin.SetActive(true);
}
}
