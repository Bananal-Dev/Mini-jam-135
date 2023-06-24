using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;

public class HeroManager : MonoBehaviour
{

    public UnityEvent onClick;
    private Color heroSkinColor;

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

    public int heroLevel = 1;

    public string heroName;

    //Info card
    [SerializeField] TMP_Text heroNameText;
    [SerializeField] TMP_Text heroLevelText;
    [SerializeField] TMP_Text heroChaText;
    [SerializeField] TMP_Text heroInteText;
    [SerializeField] TMP_Text heroStrText;
    [SerializeField] TMP_Text heroDexText;

    private void Awake() {
        infoCanva.enabled = false;
        if(!createdHero)
        {
            createdHero = true;
            heroName = GetRandomMedievalName();
            availablePoints = maxInitialPoints;
            DefineSkinColor();
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
        for(int i = 0; i < 6; i++)
        {
           bodyFeaturesSprites[i].sprite = spriteList[i];
           if(i==0)
           {
                bodyFeaturesSprites[i].GetComponent<Transform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
                bodyFeaturesSprites[i].color = heroSkinColor;
           }
           if(i==1)
           {
                bodyFeaturesSprites[i].color = heroSkinColor;
           }
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
            randoms[UnityEngine.Random.Range(0,4)] += 1;
        }

        cha = randoms[0];
        inte = randoms[1];
        str = randoms[2];
        dex = randoms[3];

        UpdateInfo();
    }

    public void UpgradeRandomAttribues(int numberOfPoints)
    {
        int numberOfRandoms = 4;

        List<int> randoms = new List<int>();
        for(int i = 0; i < numberOfRandoms; i++)
        {
            randoms.Add(1);
        }

        for(int i = 0; i < numberOfPoints - 4; i++)
        {
            randoms[UnityEngine.Random.Range(0,4)] += 1;
        }

        cha += randoms[0];
        inte += randoms[1];
        str += randoms[2];
        dex += randoms[3];

    }

    public void UpdateInfo()
    {
        heroNameText.text = heroName;
        heroLevelText.text = "Level: " + heroLevel.ToString();
        heroChaText.text = "Charism:  " + cha.ToString();
        heroInteText.text = "Intellect:  " + inte.ToString();
        heroStrText.text = "Strength: " + str.ToString();
        heroDexText.text = "Dexterity: " + dex.ToString();
    }

    public void LevelUp()
    {
        heroLevel++;
    }

    private void DefineSkinColor() {
        float minRed = 0.8f;
        float maxRed = 1.0f;
        float minGreen = 0.6f;
        float maxGreen = 0.9f;
        float minBlue = 0.4f;
        float maxBlue = 0.7f;

        // Generate random color values within the defined range
        float randomRed = UnityEngine.Random.Range(minRed, maxRed);
        float randomGreen = UnityEngine.Random.Range(minGreen, maxGreen);
        float randomBlue = UnityEngine.Random.Range(minBlue, maxBlue);

        // Create and return the random skin color
        Color skinColor = new Color(randomRed, randomGreen, randomBlue);
        heroSkinColor = skinColor;
    }
    private void OnMouseDown() {
        LevelUp();
        UpgradeRandomAttribues(5);
        UpdateInfo();
        onClick.Invoke();
    }

    public string GetRandomMedievalName()
    {
        string[] prefixes = { "Sir", "Lord", "Duke", "Baron", "Count", "Squire", "Knight", "Earl", "Viscount", "Marquess", "Prince" };
        string[] middleNames = {"Arthur", "Lancelot", "Galahad", "Tristan", "Merlin", "Percival", "Richard", "Geoffrey", "William", "Henry", "Edward",
                                "Robert", "John", "Thomas", "Francis", "Charles", "Albert", "Alexander", "James", "George", "Andrew", "Michael", "David",
                                "Joseph", "Daniel", "Matthew", "Christopher", "Benjamin", "Samuel", "Nicholas", "Jonathan", "Peter", "Stephen", "Anthony",
                                "Paul", "Mark", "Timothy", "Patrick", "Philip", "Gregory", "Lawrence", "Steven", "Edward", "Victor", "Vincent", "Walter",
                                "Raymond", "Louis", "Jonathan", "Jeremy", "Ronald", "Kenneth", "Alan", "Keith", "Gary", "Donald", "Jerry", "Roger",
                                "Terry", "Billy", "Christopher", "Wayne", "Martin", "Dennis", "Howard", "Carl", "Eugene", "Ralph", "Eric", "Adam",
                                "Patrick", "Harry", "Johnny", "Bobby", "Bruce", "Willie", "Leonard", "Frederick", "Ernest", "Melvin", "Phillip", "Barry",
                                "Leroy", "Rodney", "Maurice", "Freddie", "Gordon", "Lloyd", "Lester", "Alfred", "Norman", "Wallace", "Charlie", "Leslie",
                                "Edwin", "Don", "Dan", "Sidney", "Herman", "Ivan", "Arnold", "Marvin", "Stanley", "Nathaniel", "Lewis", "Clarence",
                                "Glenn", "Jesse", "Curtis", "Herbert", "Gilbert", "Clifford", "Craig", "Jack", "Roger", "Calvin", "Darryl", "Duane",
                                "Sam", "Luther", "Daryl", "Max", "Jose", "Clyde", "Lynn", "Nathan", "Dwayne", "Cecil", "Roland", "Virgil", "Tommy",
                                "Mike", "Harold", "Randy", "Dean", "Bradley", "Franklin", "Darrell", "Randall", "Chester", "Kurt", "Brett", "Tim",
                                "Ricky", "Greg", "Tyler", "Bernard", "Terrence", "Julian", "Travis", "Neil", "Clayton", "Everett", "Frank", "Neil",
                                "Kyle", "Francis", "Jeffery", "Carlton", "Oscar", "Victor", "Mitchell", "Allan", "Jose", "Rodolfo", "Jesus", "Eddie",
                                "Theodore", "Wilbur", "Gregg", "Derek", "Warren", "Leo", "Lonnie", "Alex", "Marc", "Ted", "Russell", "Alvin", "Jim",
                                "Bill", "Rolando", "Ruben", "Emmett", "Corey", "Javier", "Hector", "Angel", "Claude", "Gerard", "Kelvin", "Rudolph",
                                "Hugh", "Reginald", "Wade", "Floyd", "Isaac", "Ramon", "Armando", "Marshall", "Lorenzo", "Rodger", "Johnny", "Leon",
                                "Seth", "Milton", "Kenny", "Bennie", "Clifton", "Sheldon", "Maxwell", "Lyle", "Guy", "Nelson", "Gilberto", "Antonio",
                                "Tom", "Pat", "Sid", "Dominic", "Norbert", "Julio", "Terrance", "Tracy", "Moses", "Owen", "Horace"};
        string[] suffixes = { "the Brave", "the Wise", "the Valiant", "of Camelot", "of the Realm", "of the Round Table", "the Noble", "the Defender", "the Just", "the Magnificent", "the Mighty", "the Bold", "the Fearless", "the Gallant", "the Honorable" };

        string randomPrefix = prefixes[UnityEngine.Random.Range(0, prefixes.Length)];
        string randomMiddleName = middleNames[UnityEngine.Random.Range(0, middleNames.Length)];
        string randomSuffix = suffixes[UnityEngine.Random.Range(0, suffixes.Length)];

        string randomName = randomPrefix + " " + randomMiddleName + " " + randomSuffix;
        return randomName;
    }
}