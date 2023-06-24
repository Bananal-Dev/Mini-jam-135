using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    public List<GameObject> currentHeroes;
    public int currentHero;
    public GameObject heroPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject newHero = Instantiate(heroPrefab, new Vector2(0f, 0f), Quaternion.identity);
        StartDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDay()
    {
        while(currentHeroes.Count < 5)
        {
            currentHeroes.Add(Instantiate(heroPrefab, new Vector2(0f, 0f), Quaternion.identity));
            currentHeroes[currentHeroes.Count-1].SetActive(false);
            currentHeroes[currentHeroes.Count-1].GetComponent<HeroManager>().onClick.AddListener(NextHero);
        }
        currentHeroes[0].SetActive(true);
        currentHero = 0;
    }

    public void NextHero()
    {
        Debug.Log("Ue");
        currentHeroes[currentHero].SetActive(false);
        currentHero++;
        currentHeroes[currentHero].SetActive(true);
    }
}
