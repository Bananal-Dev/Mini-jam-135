using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public int coinValue=200;
    public TMP_Text coinStatus; 
    public Image reputationBar;
    public Image vilanBar; 

    public int currentReputationStatus = 50;
    public int maxReputationStatus = 100;
    public int currentVilanStatus = 5;
    public int maxVilanStatus = 100; 


    void Start()
    {
        coinStatus.text=coinValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ReputationBarUp();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            ReputationBarDown();
        }
            
        coinStatus.text=coinValue.ToString();
    }

    public void ChangeCoinValue(int value)
    {
        coinValue+=value;
    }

    void ReputationBarUp ()
    {
        currentReputationStatus += 5;
        Vector3 reputationBarScale = reputationBar.rectTransform.localScale;
        reputationBarScale.y = (float)currentReputationStatus/maxReputationStatus;
        reputationBar.rectTransform.localScale = reputationBarScale;
    }

    void ReputationBarDown()
    {
        currentReputationStatus -= 5;
        Vector3 reputationBarScale = reputationBar.rectTransform.localScale;
        reputationBarScale.y = (float)currentReputationStatus/maxReputationStatus;
        reputationBar.rectTransform.localScale = reputationBarScale;
    }

    void VilanBarUp()
    {
        currentVilanStatus += 5;
        Vector3 vilanBarScale = vilanBar.rectTransform.localScale;
        vilanBarScale.y = (float)currentVilanStatus/maxVilanStatus;
        vilanBar.rectTransform.localScale = vilanBarScale;
    }

}
