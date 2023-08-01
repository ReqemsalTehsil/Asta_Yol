using UnityEngine.UI;
using UnityEngine;

public class pieChartRed : MonoBehaviour
{
    public Image redImg;
    public Image greenImg;
    // Start is called before the first frame update
    void Start()
    {

        byte fails = (byte)PlayerPrefs.GetInt("fail", 0);
        byte passes = (byte)PlayerPrefs.GetInt("pass", 0);

        
        
        //based on fact that redPie is OVER green, there is no need to calculate both
        redImg.fillAmount = (fails*1f)/(fails + passes)*1f;
        greenImg.fillAmount = 1;
        
        if(fails == 0 && passes == 0)
        {
            greenImg.fillAmount = 0;
            redImg.fillAmount = 0;
        }
    }
}
