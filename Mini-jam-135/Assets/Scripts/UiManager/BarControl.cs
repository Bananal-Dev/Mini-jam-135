
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    public BoxCollider2D boxReputation; 
    public string barTag; 

    void Start()
    {
        boxReputation =GetComponent<BoxCollider2D>(); 
        barTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        
        if(barTag == "ReputationBar")
            Debug.Log("Mouse entrou na barra de reputação");
        
        else
            Debug.Log("Mouse entrou na barra de vilania");
    }

    
}
