using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Mechanic/Quest")]
public class Quest : ScriptableObject
{
    public enum questAttributes{cha, inte, str, dex};
    public enum questLevels{basic, adventurer, hero};

    public string questDescription;
    public questAttributes questAttribute;
    public questLevels questLevel;
    public int questTipo;
    public static Quest Create(string thisDescription, questAttributes thisAttribute, questLevels thisLevel, int thisTipo) {
        Quest questToReturn = CreateInstance<Quest>();
        questToReturn.questDescription = thisDescription;
        questToReturn.questAttribute = thisAttribute;
        questToReturn.questLevel = thisLevel;
        questToReturn.questTipo = thisTipo;
        return questToReturn;
    }
}