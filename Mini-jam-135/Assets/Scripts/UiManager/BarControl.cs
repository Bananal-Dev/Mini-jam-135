
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    public BoxCollider2D boxReputation; 
    public string barTag; 
    public UiManager uiManager;
       

    void Start()
    {
        boxReputation =GetComponent<BoxCollider2D>(); 
        barTag = gameObject.tag;
        uiManager = new UiManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        
        if(barTag == "ReputationBar")
            uiManager.BoxReputationBar();
        
        else
            Debug.Log("Mouse entrou na barra de vilania");
    }
    
    
    
}
