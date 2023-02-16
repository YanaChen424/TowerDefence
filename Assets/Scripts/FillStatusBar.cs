using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public int gameHealth;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        gameHealth = 4;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        int enemyReach = GameManager.Instance.enemyReachTargetNum;
        if(slider.value<=slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(slider.value>slider.minValue && fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        if(enemyReach!=0)
        {
            print(enemyReach);
        }
        float fillvalue = (float)(gameHealth-enemyReach) / gameHealth;
        if(fillvalue!=1)
        print(fillvalue);
        slider.value = fillvalue;
    }
}
