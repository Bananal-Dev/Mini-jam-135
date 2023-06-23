using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HeroManager : MonoBehaviour
{

    public Canvas infoCanva;

    private SpriteRenderer[] bodyFeaturesSprites;
    private void Awake() {
        bodyFeaturesSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer thisSprite in bodyFeaturesSprites)
        {
            thisSprite.color = UnityEngine.Random.ColorHSV();
        }
        DefineRandomBodyFeature();
        DefineRandomAttributes();
    }



    private void OnMouseEnter() {
        infoCanva.enabled = true;
    }

    private void OnMouseExit() {
        infoCanva.enabled = false;
    }

    private void DefineRandomBodyFeature() {

    }

    private void DefineRandomAttributes() {
        
    }
}