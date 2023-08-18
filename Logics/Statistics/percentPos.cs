using System;
using UnityEngine;
using TMPro;
public class percentPos : MonoBehaviour
{
    public GameObject redPercentage;
    public GameObject greenPercentage;

    public TextMeshProUGUI redText;
    public TextMeshProUGUI greenText;

    byte fails;
    byte passes ;

    void Start()
    {

        fails = (byte)PlayerPrefs.GetInt("fail", 0);
        passes = (byte)PlayerPrefs.GetInt("pass", 0);

        if(fails == 0 && passes == 0){redPercentage.SetActive(false);greenPercentage.SetActive(false);return;} // to prevent zero division 
        if(fails == 0)redPercentage.SetActive(false);
        if(passes == 0)greenPercentage.SetActive(false);
        //setting values of percentages
        redText.text = $"{( (int)(fails*1f/(fails+passes) * 100))}";
        greenText.text = $"{((100 - (int)(fails*1f/(fails+passes) * 100)))}";
        //setting position of percentages

        // we will use same vars for setting coordinates for both objects
        float x = (float) (  25f*Math.Cos( (Math.PI/2f - 0.5*(((fails*1.0)/(passes+fails)) * 2.0*Math.PI) )) );
        float y = (float) (  25f*Math.Sin( (Math.PI/2f - 0.5*(((fails*1.0)/(passes+fails)) * 2.0*Math.PI) )) );

        redPercentage.GetComponent<RectTransform>().anchoredPosition = new Vector2(x,y);
        greenPercentage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-x,-y); // symmetry

    }
}
