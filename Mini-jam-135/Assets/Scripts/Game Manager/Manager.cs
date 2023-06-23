using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject heroPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newHero = Instantiate(heroPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
