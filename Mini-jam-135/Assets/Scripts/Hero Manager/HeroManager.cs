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

    public List<string> firstDialogue = new List<string>();
    public List<string> futureDialogue = new List<string>();

    public int heroLevel = 1;

    public string heroName;

    //Info card
    [SerializeField] TMP_Text heroNameText;
    [SerializeField] TMP_Text heroLevelText;
    [SerializeField] TMP_Text heroChaText;
    [SerializeField] TMP_Text heroInteText;
    [SerializeField] TMP_Text heroStrText;
    [SerializeField] TMP_Text heroDexText;
    [SerializeField] TMP_Text heroDialogue;

    private void Awake() {
        infoCanva.enabled = false;
        if(!createdHero)
        {
            LoadDialogues();
            createdHero = true;
            heroName = GetRandomMedievalName();
            availablePoints = maxInitialPoints;
            DefineSkinColor();
            DefineRandomBodyFeature();
            DefineRandomAttributes();    
        }
    }

    void OnEnable()
    {
        OnActivate();
    }
    public void OnActivate() {
        if(heroLevel == 1) {
            heroDialogue.text = firstDialogue[UnityEngine.Random.Range(0, firstDialogue.Count)];
        }
        else {
            heroDialogue.text = futureDialogue[UnityEngine.Random.Range(0, futureDialogue.Count)];
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
           if(i==1 || i==3)
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
        UpgradeRandomAttribues(3);
        UpdateInfo();
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

    public void LoadDialogues() {
        //Frist dialogues    
        firstDialogue.Add("I am very strong, I want to kill monsters... I want a mission! Give the mission to me!");
        firstDialogue.Add("Hello! I am the strongest adventurer in the world, and one day all the girls will scream when they hear my name! Give me a mission worthy of my strength!");
        firstDialogue.Add("There is no one braver and stronger than me in this region! I need a mission to prove how strong I am!");
        firstDialogue.Add("Hi... I am an adventurer from the neighboring county... Do you have any mission for me?");
        firstDialogue.Add("Good morning... I work as an adventurer in the neighboring county, do you have anything for me?");
        firstDialogue.Add("What a shabby place... Oh, I apologize for the comment. In my house, my servants don't let common areas get so dirty. I am the youngest son of a noble family. I am starting my journey as an adventurer. Do you have a mission for me?");
        firstDialogue.Add("I am the fifth son of a wealthy and noble dynasty of noble warriors! I am an adventurer seeking glory! Do you have a mission worthy of my wealth? Please, do not associate me with the common rabble!");
        firstDialogue.Add("I don't have time to explain myself, don't ask me about my goals... Do you have a mission? I need quick money.");
        firstDialogue.Add("Be quick, give me a mission right away, or I will treat you as I will treat those I seek.");
        firstDialogue.Add("The voices inside my head told me that this would be the perfect place to continue my work... It's a pleasure to meet you. Do you have a mission for someone who is not afraid to get their hands dirty?");
        firstDialogue.Add("Hello... I heard that you have some quite chaotic missions... but chaos can be so stimulating... Hehehe, nice to meet you... Do you have any mission for someone like me?");
        firstDialogue.Add("Hello! I heard that this guild is one of the most respected in the region, and its adventurers are highly rewarded for their services! Since this is my first time here, I bet you could assign me a mission requested by a wealthy and powerful family!");
        firstDialogue.Add("Well, well, what do we have here? One of the finest guilds I've ever seen! Do you happen to have a mission for escorting wealthy caravans with valuable items? Those are the ones I enjoy the most.");
        firstDialogue.Add("Hi! Good morning! It's my first time here, nice to meet you! I have good experience in all types of jobs. I'm in need of a mission, which one would you recommend to me?");
        firstDialogue.Add("Hello, guild leader. I am an excellent strategist, with the opportunity to lead decisive battles, plan stealthy incursions, and find intelligent solutions to complex conflicts. Do you have any mission for someone like me?");
        firstDialogue.Add("Nice to meet you! I'm looking for adventures that require a high level of strategic knowledge. Could you recommend a mission for me?");
        firstDialogue.Add("Greetings, guild leader! I possess knowledge of the laws that govern this world. With my magic, I am certain to make your life and the lives of everyone else happier... but until then, I need money to buy more books... Do you have a mission for me?");
        firstDialogue.Add("I greet you with reverence, master of the guild! Do you happen to have a mission for this humble yet powerful connoisseur of mystical arts? I will astonish you with my majestic tricks.");
        firstDialogue.Add("Hmm... hello... uh... do you have... a mission?... I'm an adventurer, you know?");
        firstDialogue.Add("Ehhh... are you... the guild leader?... It's just that... it's my first time here... hmmm... do you have a mission for me... and one that isn't too difficult?");
        //Future Dialogues
        futureDialogue.Add("I am too strong for that mission! I want another one!");
        futureDialogue.Add("HAHAHA! That mission you gave me is nowhere near a match for my strength! Give me another one that is more challenging than the previous!!!");
        futureDialogue.Add("I have arrived! Give me a new mission because beating things up is what I do best!");
        futureDialogue.Add("Hello again! I think I'll stick around here for a while longer! The missions here are really good! Could you recommend another one for me?");
        futureDialogue.Add("I must say, I'm impressed by how challenging the missions are around here. Do you have another mission for me?");
        futureDialogue.Add("Indeed, this guild knows how to treat its adventurers! I would gladly accept a new mission to stay in this region!");
        futureDialogue.Add("As the heir to great fortunes and strength, I didn't even break a sweat in the last mission. Give me another one worthy of the wealth and power of my family!");
        futureDialogue.Add("I must admit, you made a mistake in judging me. After all, who would suspect that beneath these refined garments lies a warrior with a punch that can crack skulls? Therefore, give me a more challenging mission.");
        futureDialogue.Add("With these missions, I'm sure I'll earn enough money to seek my revenge... Give me another mission, but this time with a higher reward.");
        futureDialogue.Add("With each mission, I feel my hatred growing... I need this to fulfill my objective... another mission, please!");
        futureDialogue.Add("I heard that when you kill, your sleep gets shorter and shorter due to remorse... But for me, my dear, we wouldn't even close our eyes...HAHAHAHA. Give me a more thrilling mission!");
        futureDialogue.Add("Hello, guild leader! I'm eager for another opportunity to venture. I bet the mission you're about to give me will explore more my... peculiar side.");
        futureDialogue.Add("Justice is a beautiful word, but it doesn't fill my pockets. Could you arrange a more... intriguing mission for me?");
        futureDialogue.Add("People love to hear the lies that are convenient for them... I simply ask for money in return. How about a mission to escort a wealthy family?");
        futureDialogue.Add("Hello again! The last mission was quite good, I must say, and I learned a lot. I was eagerly awaiting to ask for a new mission from you. What do you recommend for me?");
        futureDialogue.Add("Hi, good morning! Man, I loved the mission you gave me... I didn't know that venturing like this could be so much fun. Do you have another similar one?");
        futureDialogue.Add("My strategic skills were crucial in ensuring my safe return from the last mission... but my mind craves more challenges. Do you have another mission for me?");
        futureDialogue.Add("The complexity of the missions you have assigned is truly delightful! I couldn't stop thinking about different approaches for a second, even after completing them! I would like another mission, please!");
        futureDialogue.Add("The brilliance that is inherent in me allowed me to use the elements around me to overcome the difficulties. Could you grant me the honor of taking on another mission, guild leader?");
        futureDialogue.Add("Being intelligent is like walking for me, but with style... and I used that style to my advantage once again. The previous mission was accomplished, but I still desire more. Do you have another mission for me?");
        futureDialogue.Add("Ah... hello again! I'm doing well as you can see... Um... do you have another mission?");
        futureDialogue.Add("Hmm... Hello... I'm back, do you remember me?... I requested a mission here the other day... Could you... Um... recommend another one for me?");
    }
}