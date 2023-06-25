using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    public List<GameObject> cardsTableObject = new List<GameObject>();
    public List<GameObject> currentHeroes;
    public int currentHero;
    public GameObject heroPrefab;
    public GameObject questprefab;
    public List<Quest> basicQuests = new List<Quest>();
    public List<Quest> adventurerQuests = new List<Quest>();
    public List<Quest> heroQuests = new List<Quest>();
    public List<Quest> questPerHero = new List<Quest>();
    public List<Quest> questsOnTable = new List<Quest>();
    public int maxHeroes = 5;
    public int maxQuestOnTable = 4;
    public int basicChance = 10;
    public int adventurerChance = 20;
    public int heroChance = 30;

    void Start()
    {
        LoadQuests();
        StartDay();
    }

    public void StartDay()
    {
        questsOnTable.Clear();
        FillTable();
        while(currentHeroes.Count < maxHeroes)
        {
            currentHeroes.Add(Instantiate(heroPrefab, new Vector2(0f, -0.93f), Quaternion.identity));
            currentHeroes[currentHeroes.Count-1].SetActive(false);
            currentHeroes[currentHeroes.Count-1].GetComponent<HeroManager>().onClick.AddListener(NextHero);
        }
        currentHeroes[0].SetActive(true);
        currentHero = 0;
    }

    public void EndDay() {

    }

    public void NextHero()
    {
        if(currentHero == maxHeroes-1) {
            EndDay();
            return;
        }
        currentHeroes[currentHero].SetActive(false);
        currentHero++;
        currentHeroes[currentHero].SetActive(true);
    }
    public void AddQuestToTable()
    {
        if(questsOnTable.Count < maxQuestOnTable) {
            questsOnTable.Add(GetRandomQuest());
            UpdateTable();
        }
    }

    public void FillTable() {
        while(questsOnTable.Count < maxQuestOnTable)
            AddQuestToTable();
    }

    public void UpdateTable() {
        foreach(GameObject card in cardsTableObject) {
            DestroyImmediate(card);
        }
        cardsTableObject.Clear();
        for(int i = 0; i < questsOnTable.Count; i++) {
            GameObject quest = Instantiate(questprefab, new Vector3(-6.3f + i*2.5f, -0.28f, 0f), Quaternion.identity);
            cardsTableObject.Add(quest);
            quest.GetComponent<QuestManager>().myQuest = questsOnTable[i];
            quest.GetComponent<QuestManager>().UpdateQuestCards();
        }
    }
    public Quest GetRandomQuest()
    {
        int maxChance = basicChance + adventurerChance + heroChance;
        int choosenChance = UnityEngine.Random.Range(0, maxChance);
        if(choosenChance < (basicChance + adventurerChance)) {
            return basicQuests[UnityEngine.Random.Range(0, basicQuests.Count)];
        }
        else if(choosenChance > basicChance && choosenChance <= (basicChance + adventurerChance)) {
            return adventurerQuests[UnityEngine.Random.Range(0, adventurerQuests.Count)];
        }
        else {
            return heroQuests[UnityEngine.Random.Range(0, heroQuests.Count)];
        }
    }
    public void SelectQuest(Quest selectedQuest)
    {
        questPerHero.Add(selectedQuest);
        AddQuestToTable();
        NextHero();
    }
    public void LoadQuests()
    {
        //Basic Quests
        basicQuests.Add(Quest.Create("Plant 300 potatoes for Mrs. Thompson.", Quest.questAttributes.str, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Plant 280 carrots for Mrs. Jenkins.", Quest.questAttributes.str, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Prepare the soil in Mr. Davis' farm for bean planting.", Quest.questAttributes.str, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Assist Mr. Murphy in moving his carpentry equipment to the warehouse.", Quest.questAttributes.str, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Deal with the locusts in Mr. Johnson's crops.", Quest.questAttributes.inte, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Help the Valentine family's children build a new plow for the farm.", Quest.questAttributes.inte, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Assist the Millers in assembling a new carriage for the family.", Quest.questAttributes.inte, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Help the Johnson family manage their farmland and harvest space.", Quest.questAttributes.inte, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Hunt 3 rabbits for the Smith family.", Quest.questAttributes.dex, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Hunt a goose for the Silva family.", Quest.questAttributes.dex, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Catch 50 trouts for Mr. Peterson.", Quest.questAttributes.dex, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Catch 20 salmons for Mr. Roberts.", Quest.questAttributes.dex, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Take care of the animals at the Wilson family's farm for 3 days.", Quest.questAttributes.cha, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Attend to Mr. Rodriguez's cattle for one week.", Quest.questAttributes.cha, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Help Mrs. Stevens' cat come down from the tree.", Quest.questAttributes.cha, Quest.questLevels.basic, 1));
        basicQuests.Add(Quest.Create("Take Mrs Anna's children to the teacher's house.", Quest.questAttributes.cha, Quest.questLevels.basic, 1));
        //Adventurer Quests
        adventurerQuests.Add(Quest.Create("Defend the walls of Castlebrook against the relentless siege of Morgrim's army.", Quest.questAttributes.str, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Assist the left flank of the Battle of Valiant's Ridge and protect the alliance between the kingdoms.", Quest.questAttributes.str, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Join the vanguard forces on the ambush mission in Darkholm.", Quest.questAttributes.str, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Lead a squad on a surprise attack against the invaders of Oakhurst, approaching from the north.", Quest.questAttributes.str, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Challenge the Champion of the Dwarves, a cunning warrior with excellent axe skills.", Quest.questAttributes.str, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Fight against the mighty warrior Samuel, the champion in the last challenge in the capital.", Quest.questAttributes.str, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Defeat the violent goblin who has been terrorizing travelers in the Foreign Mountains.", Quest.questAttributes.str, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Challenge Gigabyte, a stone giant who enjoys studying magic.", Quest.questAttributes.str, Quest.questLevels.adventurer, 2));adventurerQuests.Add(Quest.Create("Uncover the secret identity of a thief who attempted to steal items from Lord William's house.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Solve the mystery of the murder of a monk from the Windschurch.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Investigate the disappearance of several people from the neighboring village.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Gather information from the members of the court to discover if there is an infiltrated servant.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Protect the renowned wizard, Master Aldric, during his journey to the Tower of Wisdom.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Escort the young Lady Genevieve to the Mansion of Lilies, protecting her from possible threats.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Escort the valuable supply shipment of Count Lancaster to Ironpeak Fortress.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Protect the Travelers' Caravan from Oakshire during their crossing through the dangerous Wolf Forest.", Quest.questAttributes.inte, Quest.questLevels.adventurer, 2));adventurerQuests.Add(Quest.Create("Explore the Whisper Castle, long abandoned, to recover the legendary Sword of Eternity.", Quest.questAttributes.dex, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Venture through the Maze of Lost Souls and find the legendary Crystal Sphere of Divination.", Quest.questAttributes.dex, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Enter the Cursed Catacombs beneath Ravenshadow to retrieve a treasure map forgotten by the enemy kingdom", Quest.questAttributes.dex, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Embark on an expedition to the Isle of Wonders, rumored to house ancient relics and countless riches", Quest.questAttributes.dex, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Infiltrate the castle while the guards are on patrol and steal the Sun Crown for the ritual of the monks.", Quest.questAttributes.dex, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Attack the mercenaries' camp and recover a powerful magical freezing artifact.", Quest.questAttributes.dex, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Invade the smugglers' den in Crimson Harbor and seize the stolen treasures of the city.", Quest.questAttributes.dex, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Search the bandits' fortress in Thunderpeak and recover the forgotten treasure of Eldoria Vale.", Quest.questAttributes.dex, Quest.questLevels.adventurer, 2));adventurerQuests.Add(Quest.Create("Become friends with the leader of the Stormcity gang and report the plan for the next raid to the royal authorities.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Be accepted as a member of the court of the Prince of Vastland and discover what resources this kingdom has to offer.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Infiltrate as a librarian in the Temple of the Ancient Sages and copy the riddle from the forbidden spellbook.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Sneak into enemy lines during the upcoming battle in the east and uncover the weaknesses of the opposing army.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 1));
        adventurerQuests.Add(Quest.Create("Go to the meeting of traders in the capital and establish a beneficial trade alliance for Oakhurst.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Talk to the king of Minorain and convince him to withdraw the armies near Thornhill.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Travel to Seaford and negotiate maritime border agreements to expand the influence of our kingdom.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 2));
        adventurerQuests.Add(Quest.Create("Participate in the diplomatic council in the neutral land of Havenbrook and help resolve conflicts between elves and humans.", Quest.questAttributes.cha, Quest.questLevels.adventurer, 2));
        //Hero Quests
        heroQuests.Add(Quest.Create("Capture the traitor who defeated the unstoppable army commander and fled the kingdom in the last judgment.", Quest.questAttributes.str, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Find and exterminate the witch of the seven spirits who cast a curse upon the prince of Ironcidge. Bring her head to the king.", Quest.questAttributes.str, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Capture the powerful necromancer who is raising an army of undead to attack the kingdom of Emberfield.", Quest.questAttributes.str, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Exterminate the colony of trolls in the Dark Mountains who have been assaulting and killing travelers and soldiers in the region.", Quest.questAttributes.str, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("The Seven Souls Witches used Celestial Griffon Eggs to curse the King of Wakeland. Go to the castle and purify the king's corrupted soul", Quest.questAttributes.inte, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("The beast that guards Ravenshadow's fearsome prison has been wounded by a deadly spell, and the safety of the realm is shaken. Neutralize the beast's curse and restore the peace.", Quest.questAttributes.inte, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("The Ancient Oracle has foretold a dark plague that is consuming the enchanted forest. Travel to the heart of the forest and purify the source of this frightening curse.", Quest.questAttributes.inte, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("The legendary sword of light has been cursed and now corrupts whoever wields it. Follow the clues of the wise elders and undo this dark curse.", Quest.questAttributes.inte, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Hunt the great magic dragon that guards the moon's treasure and recover that lost treasure.", Quest.questAttributes.dex, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Neutralize a horde of night fairies heading towards their spawning grounds. If they spawn, it will be too late.", Quest.questAttributes.dex, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Find and eliminate without a second thought the vampires who invaded the capital and took children to grow them for food.", Quest.questAttributes.dex, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Rumor has it that a direwolf has been prowling the Oakhurst borders. Wherever he goes, there is only despair and destruction. Hunt and eliminate this deadly beast.", Quest.questAttributes.dex, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Rescue the princess of Thornhill who was locked up by a grouchy and grumpy ogre. Some heroes have tried, but the ogre will only give in to the one who makes him laugh 3 times.", Quest.questAttributes.cha, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("Tenderville's enchanted elf, who has entertained the populace for centuries, has fallen into a depression and refuses to come back. Talk to him and restore the joy of the people of this land.", Quest.questAttributes.cha, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("A malevolent sorceress has kidnapped the heroes' mentor, imprisoning his mind in the illusion of a world without goodness. Rescue the hero and show him the joys he can still live.", Quest.questAttributes.cha, Quest.questLevels.hero, 1));
        heroQuests.Add(Quest.Create("The inhabitants of a village were captured to be slaves of the most menacing nation of Elvera. Convince the king to abolish slavery and free the inhabitants.", Quest.questAttributes.cha, Quest.questLevels.hero, 1));
    }
}