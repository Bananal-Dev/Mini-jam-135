using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEditor;

public class QuestManager : MonoBehaviour
{
    public Image questCardBig;
    public SpriteRenderer questCardSmall;
    public Manager gameManager;
    public Canvas infoCanva;
    public Quest myQuest;
    public SpriteRenderer smallCard;
    public SpriteRenderer caveira2Sprite;
    public SpriteRenderer caveira3Sprite;
    public Image bigCard;
    public Image caveira2Image;
    public Image caveira3Image;

    public TMP_Text descriptionText;
    public TMP_Text attribText;


    void Start()
    {
        infoCanva.enabled = false;
    }

    private void OnMouseEnter() {
        infoCanva.enabled = true;
    }

    private void OnMouseExit() {
        infoCanva.enabled = false;
    }

    public void UpdateQuestCards() {

        descriptionText.text = myQuest.questDescription;
        string spriteName = myQuest.questLevel.ToString()+'.'+myQuest.questAttribute.ToString()+'.'+myQuest.questTipo.ToString()+".png";
        if(myQuest.questAttribute == Quest.questAttributes.cha) {
            bigCard.color = new Color(0.35f, 0.09f, 0.56f);
            smallCard.color = new Color(0.35f, 0.09f, 0.56f);
            attribText.text = "Charism";
        }
        else if(myQuest.questAttribute == Quest.questAttributes.inte) {
            bigCard.color = new Color(0.09f, 0.50f, 0.70f);
            smallCard.color = new Color(0.09f, 0.50f, 0.70f);
            attribText.text = "Intellect";
        }
        else if(myQuest.questAttribute == Quest.questAttributes.str) {
            bigCard.color = new Color(0.55f, 0.03f, 0.00f);
            smallCard.color = new Color(0.55f, 0.03f, 0.00f);
            attribText.text = "Strength";
        }
        else if(myQuest.questAttribute == Quest.questAttributes.dex) {
            bigCard.color = new Color(0.11f, 0.53f, 0.09f);
            smallCard.color = new Color(0.11f, 0.53f, 0.09f);
            attribText.text = "Dexterity";
        }
        if(myQuest.questLevel == Quest.questLevels.adventurer) {
            caveira2Image.enabled = true;
            caveira2Sprite.enabled = true;
        }
        else if(myQuest.questLevel == Quest.questLevels.hero) {
            caveira2Image.enabled = true;
            caveira2Sprite.enabled = true;
            caveira3Image.enabled = true;
            caveira3Sprite.enabled = true;
        }
        questCardBig.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Resources/Sprites/QuestCards/"+spriteName);
        questCardSmall.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Resources/Sprites/QuestCards/"+spriteName);
    }
    
    private void OnMouseDown() {
        gameManager.SelectQuest(myQuest, gameObject);
    }
}
