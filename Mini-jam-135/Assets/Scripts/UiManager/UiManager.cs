using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    //variaveis de uso na moeda
    public int coinValue=200;
    public TMP_Text coinStatus; 
    public Image reputationBar;
    public Image vilanBar; 

    //variaveis de uso nos medidores de moral 
    public int currentReputationStatus = 50;
    public int maxReputationStatus = 100;
    public int currentVilanStatus = 5;
    public int maxVilanStatus = 100; 


    void Start()
    {
        coinStatus.text=coinValue.ToString();
    }

    //alteracao de valor monetario
    public void ChangeCoinValue(int value)
    {
        coinValue+=value;
        coinStatus.text=coinValue.ToString();
    }


    //alteracao do valor de reputacao
    public void ReputationBarUp ()
    {
        currentReputationStatus += 5;
        currentReputationStatus = Mathf.Min(currentReputationStatus, maxReputationStatus);
        Debug.Log(currentReputationStatus);
        Vector3 reputationBarScale = reputationBar.rectTransform.localScale;
        reputationBarScale.y = (float)currentReputationStatus/maxReputationStatus;
        reputationBar.rectTransform.localScale = reputationBarScale;
    }

    public void ReputationBarDown()
    {
        currentReputationStatus -= 5;
        currentReputationStatus = Mathf.Max(0, currentReputationStatus);
        Debug.Log(currentReputationStatus);
        Vector3 reputationBarScale = reputationBar.rectTransform.localScale;
        reputationBarScale.y = (float)currentReputationStatus/maxReputationStatus;
        reputationBar.rectTransform.localScale = reputationBarScale;
    }

    public void VilanBarUp()
    {
        currentVilanStatus += 3;
        currentVilanStatus = Mathf.Clamp(currentVilanStatus, 0, 100);
        Vector3 vilanBarScale = vilanBar.rectTransform.localScale;
        vilanBarScale.y = (float)currentVilanStatus/maxVilanStatus;
        vilanBar.rectTransform.localScale = vilanBarScale;
    }

}