using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Features List", menuName = "Lists/Body Features List")]
public class BodyFeaturesList : ScriptableObject
{
    public List<Sprite> Body = new List<Sprite>();
    public List<Sprite> Head = new List<Sprite>();
    public List<Sprite> Mouth = new List<Sprite>();
    public List<Sprite> Nose = new List<Sprite>();
    public List<Sprite> Eye = new List<Sprite>();
    public List<Sprite> Hair = new List<Sprite>();

    public List<Sprite> GetRandomSprites()
    {
        List<Sprite> featuresReturned = new List<Sprite>();
        featuresReturned.Add(Body[UnityEngine.Random.Range(0, Body.Count-1)]);
        featuresReturned.Add(Head[UnityEngine.Random.Range(0, Head.Count-1)]);
        featuresReturned.Add(Mouth[UnityEngine.Random.Range(0, Mouth.Count-1)]);
        featuresReturned.Add(Nose[UnityEngine.Random.Range(0, Nose.Count-1)]);
        featuresReturned.Add(Eye[UnityEngine.Random.Range(0, Eye.Count-1)]);
        featuresReturned.Add(Hair[UnityEngine.Random.Range(0, Hair.Count-1)]);
        return(featuresReturned);
    }
}