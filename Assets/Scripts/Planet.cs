using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private int radius;
    private int maxTileWeight;
    private List<OreProfile> fillOres = new List<OreProfile>();
    S_TileList planet;


    public void Generate(PlanetProfile profile, Tile tilePrefab, S_TileList planet)
    {
        planet.currentValue.Clear();
        SetMaxTileWeight(profile);
        SetFillTiles(profile);

        PrintInfo(profile);

        radius = profile.radius;

        for (int y = radius; y >= -radius; y--)
        {
            for (int x = -radius; x < radius; x++)
            {
                Vector2 current = new Vector2(x, y);
                float distToCurrent = (current - Vector2.zero).magnitude;
                if (distToCurrent < radius)
                {
                    float depth = distToCurrent / radius;
                    float surfaceWeight = depth / profile.surfaceEnd - profile.surfaceEnd;
                    OreProfile selectedOre = SelectRandomOre(profile, surfaceWeight);
                    Tile temp = Instantiate(tilePrefab, current, Quaternion.identity, gameObject.transform);
                    temp.Initialize(selectedOre);
                    planet.currentValue.Add(temp);
                }
            }
        }
    }


    private void PrintInfo(PlanetProfile profile)
    {
        print("Creating planet. Radius: " +  profile.radius + ", Surface: " + profile.surfaceEnd);

        for (int i = 0; i < profile.fillOres.Count; i++)
        {
            print("" + profile.fillOres[i] + ":" + profile.oreWeights[i]);
        }
    }

    private void SetFillTiles(PlanetProfile profile)
    {
        for (int i = 0; i < profile.fillOres.Count; i++)
        {
            OreProfile ore = profile.fillOres[i];
            int weight = profile.oreWeights[i];

            for (int j = 0; j < weight; j++)
            {
                fillOres.Add(ore);
            }
        }
    }

    private void SetMaxTileWeight(PlanetProfile profile)
    {
        foreach (int i in profile.oreWeights)
        {
            maxTileWeight += i;
        }
    }

    private OreProfile SelectRandomOre(PlanetProfile profile, float weight)
    {
        bool surfaceTile = UnityEngine.Random.value < weight;
        if (surfaceTile)
        {
            return profile.surfaceTile;
        }

        int tileIndex = UnityEngine.Random.Range(0, maxTileWeight);
        return fillOres[tileIndex];
    }
}
