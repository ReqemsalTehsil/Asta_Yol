using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScript : MonoBehaviour
{
    public GameObject firstLoadingPic;
    public GameObject secondLoadingPic;
    public GameObject thirdLoadingPic;
    public GameObject loadingObj;
    public GameObject Timer;

    
    // Start is called before the first frame update
    void Start()
    {
        database.removeLoading = false;
        database.dataIsLoaded = false;

        
        Debug.Log("loading starts");
        StartCoroutine(loading());
    }

    // Update is called once per frame

    
//loading pic scripts 
private IEnumerator loading()
{
    while(!database.removeLoading)
    {
        Debug.Log("loading starts");
    firstLoaded(); 

    yield return new WaitForSeconds(1);

    secondLoaded();

    yield return new WaitForSeconds(1);

    thirdLoaded();

    yield return new WaitForSeconds(1);
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
    Timer.SetActive(true);
}
}
