using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sprite List", menuName = "Lists/Sprite List")]
public class AssetList : ScriptableObject
{
    public List<Sprite> assets = new List<Sprite>();
}