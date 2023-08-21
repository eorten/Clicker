using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetProfile : ScriptableObject
{
    public OreProfile surfaceTile;
    public int radius;
    public float surfaceEnd;
    public List<OreProfile> fillOres;
    public List<int> oreWeights;
}
