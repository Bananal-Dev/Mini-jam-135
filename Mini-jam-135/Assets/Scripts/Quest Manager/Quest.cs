using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Mechanic/Quest")]
public class Quest : ScriptableObject
{
    public enum questAttributes{cha, inte, str, dex};
    public enum questLevels{basic, adventurer, hero};

    public string questDescription;
    public questAttributes querstAttribute;
    public questLevels questLevel;
}