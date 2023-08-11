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

    //UI caixas explicativas
    public GameObject boxReputationExplain; 
    public GameObject boxVilanExplain; 
    private Vector2 ajuste;
    public TMP_Text textReputation; 
    public TMP_Text textVillan;
    
    

    void Start()
    {
        coinStatus.text=coinValue.ToString();
        ajuste = new Vector2 (-3.2f, -1.0f);
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

    //INSTANCIANDO AS BOXES DE EXPLICAÇÃO NAS BARRAS
        
    public void BoxReputationBar()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Debug.Log(mousePosition);
        boxReputationExplain.SetActive(true);
        boxReputationExplain.transform.position = mousePosition+ ajuste; 
        textReputation.text = "Your reputation is: "+ currentReputationStatus +".      Once you reach zero, you'll face defeat."; 
    }

    public void BoxVilanBar()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Debug.Log(mousePosition);
        boxVilanExplain.SetActive(true);
        boxVilanExplain.transform.position = mousePosition+ajuste;
        textVillan.text = "Your relationship with the villain is: "+ currentVilanStatus +".  Once you reach a hundread, you'll win.";
    }

    public void CleanBoxExplain()
    {
        boxReputationExplain.SetActive(false);
        boxVilanExplain.SetActive(false);
    }

}