
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    public BoxCollider2D boxReputation; 
    private string barTag; 
    private UiManager uiManager;
    public GameObject canva; 
    

    void Start()
    {
        boxReputation =GetComponent<BoxCollider2D>(); 
        barTag = gameObject.tag;
        uiManager = canva.GetComponent<UiManager>();
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
            uiManager.BoxVilanBar();
    }
    
    void OnMouseExit()
    {
        uiManager.CleanBoxExplain();
    }

}
