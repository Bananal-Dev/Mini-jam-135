using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinControl : MonoBehaviour
{
    public int coinValue=200;
    public TMP_Text coinStatus; 


    void Start()
    {
        coinStatus.text=coinValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinStatus.text=coinValue.ToString();
    }

    public void ChangeCoinValue(int value)
    {
        coinValue+=value;
    }
}
