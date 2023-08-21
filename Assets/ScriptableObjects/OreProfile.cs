using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new OreProfile", menuName = "Ore Profile")]
public class OreProfile : ScriptableObject
{
    public int hp;
    public string oreName;
    public int price;
    public Color32 color;
    public int baseWeight;
}
