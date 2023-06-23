using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HeroManager : MonoBehaviour
{

    public Canvas infoCanva;
    private int availablePoints;
    [SerializeField] int maxInitialPoints = 13;
    private SpriteRenderer[] bodyFeaturesSprites;
    private bool createdHero = false;
    public int cha;
    public int inte;
    public int str;
    public int dex;
    public BodyFeaturesList  bodyFeatureList;

    private void Awake() {
        if(!createdHero)
        {
            createdHero = true;
            
            availablePoints = maxInitialPoints;
            DefineRandomBodyFeature();
            DefineRandomAttributes();    
        }
        
    }



    private void OnMouseEnter() {
        infoCanva.enabled = true;
    }

    private void OnMouseExit() {
        infoCanva.enabled = false;
    }

    private void DefineRandomBodyFeature() {
        List<Sprite> spriteList = bodyFeatureList.GetRandomSprites();
        bodyFeaturesSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0; i < bodyFeaturesSprites.Length; i++)
        {
           bodyFeaturesSprites[i].sprite = spriteList[i];
        }
    }

    private void DefineRandomAttributes() {
        int numberOfRandoms = 4;

        List<int> randoms = new List<int>();
        for(int i = 0; i < numberOfRandoms; i++)
        {
            randoms.Add(1);
        }

        for(int i = 0; i < maxInitialPoints - 4; i++)
        {
            randoms[UnityEngine.Random.Range(0,3)] += 1;
        }

        cha = randoms[0];
        inte = randoms[1];
        str = randoms[2];
        dex = randoms[3];
    }
}