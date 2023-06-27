using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public Canvas UIManager;

    public TMP_Text basicEntries;
    public TMP_Text adventurerEntries;
    public TMP_Text heroEntries;

    public void BuyBasicChance() {
        if(UIManager.GetComponent<UiManager>().coinValue >= 30) {
            gameManager.GetComponent<Manager>().basicChance += 1;
            UIManager.GetComponent<UiManager>().ChangeCoinValue(-30);
            basicEntries.text = "Basic entries: " + gameManager.GetComponent<Manager>().basicChance.ToString();
        }
    }
    public void BuyAdventurerChance() {
        if(UIManager.GetComponent<UiManager>().coinValue >= 150) {
            gameManager.GetComponent<Manager>().adventurerChance += 1;
            UIManager.GetComponent<UiManager>().ChangeCoinValue(-150);
            adventurerEntries.text = "Adventurer entries: " + gameManager.GetComponent<Manager>().adventurerChance.ToString();
        }
    }

    public void BuyHeroChance() {
        if(UIManager.GetComponent<UiManager>().coinValue >= 300) {
            gameManager.GetComponent<Manager>().heroChance += 1;
            UIManager.GetComponent<UiManager>().ChangeCoinValue(-300);
            heroEntries.text = "Hero entries: " + gameManager.GetComponent<Manager>().heroChance.ToString();
        }
    }
}