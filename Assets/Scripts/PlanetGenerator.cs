using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.IsolatedStorage;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] Tile tilePrefab;
    [SerializeField] Planet planetPrefab;

    [Header("Generate")]
    [SerializeField] OreProfile[] ores;
    [SerializeField] OreProfile surfaceOre;
    [SerializeField] OreProfile stoneOre;
    [SerializeField] S_TileList planetList;

    private void Start()
    {
        Generate(10, 0, 0, 0);
    }

    public void Generate(int points, int extraOrePoints, int extraSurfacePoints, int extraSizePoints)
    {

        //Give initial points
        int surfacePoints = Mathf.FloorToInt(points / Random.Range(5,7));
        points -= surfacePoints;

        int orePoints = Mathf.FloorToInt(points / Random.Range(5, 7));
        points -= orePoints;

        int sizePoints = Mathf.FloorToInt(points / Random.Range(5, 7));
        points -= sizePoints;

        //Divide rest, between 2/8 and 5/8
        while (points > 0)
        {
            float rnd = Random.value;
            if (rnd < 0.33f)
            {
                surfacePoints++;
            }
            else if(rnd < 0.66)
            {
                orePoints++;
            }
            else
            {
                sizePoints++;
            }
            points--;
        }

        //Add extra points
        surfacePoints += extraSurfacePoints;
        orePoints += extraOrePoints;
        sizePoints += extraSizePoints;

        print("Ore: " + orePoints + ", surface: " + surfacePoints + ", size: " + sizePoints);

        //Assign surface points logarithmically
        float initialStep = 0.025f;
        float currentStep = 0;
        for (int i = 0; i < surfacePoints; i++)
        {
            currentStep += initialStep;
            initialStep *= 0.97f;
        }

        float minSurface = 0.35f;
        float maxSurface = 1;
        float surfaceEnd = Mathf.Lerp(minSurface, maxSurface, currentStep);
        print("Lerp: " + currentStep);

        //Assign size logarithmically
        float tempRadius = 5;
        float logMultiplier = 0.99f;
        float add = 1f;
        for (int i = 0;i < sizePoints; i++)
        {
            tempRadius += add;
            add *= logMultiplier;
        }
        int radius = Mathf.RoundToInt(tempRadius);

        //Assign ores
        int maxOres = 4;
        List<OreProfile> selectedOres = new List<OreProfile>();
        selectedOres.Add(stoneOre);
        while (selectedOres.Count < maxOres) {
            OreProfile toAdd = ores[Random.Range(0, ores.Length)];
            if (!selectedOres.Contains(toAdd))
            {
                selectedOres.Add(toAdd);
            }
        }

        //Assign ore weight
        List<int> oreWeights = new List<int>();
        List<int> oreWeightsImmutable = new List<int>();
        foreach (OreProfile profile in selectedOres)
        {
            oreWeights.Add(profile.baseWeight);
            oreWeightsImmutable.Add(profile.baseWeight);
        }
        while (orePoints > 0)
        {
            //Ikke ta med nr0, stein
            int index = 0;
            while (index == 0)
            {
                index = RandomBias(oreWeightsImmutable);
            }
            oreWeights[index]++;
            orePoints -= selectedOres[index].price;
        }

        Planet planet = Instantiate(planetPrefab, gameObject.transform);
        PlanetProfile pp = ScriptableObject.CreateInstance<PlanetProfile>();
        pp.surfaceTile = surfaceOre;
        pp.radius = radius;
        pp.surfaceEnd = surfaceEnd;
        pp.fillOres = selectedOres;
        pp.oreWeights = oreWeights;
        planet.Generate(pp, tilePrefab, planetList);
    }

    private int RandomBias(List<int> selectFrom)
    {
        int weightSum = 0;
        int[] cdf = new int[selectFrom.Count];

        //Hver weight i oreWeights
        for (int i = 0; i < selectFrom.Count; i++)  
        {
            weightSum += selectFrom[i];
            cdf[i] = weightSum;
        }

        int res = Random.Range(0, weightSum+1);
        int returnIndex = 0;
        for (int i = 0; i < cdf.Length; i++)
        {
            int num = cdf[i];
            if (num <= res)
            {
                returnIndex = i;
            }
        }
        return returnIndex;
    }
}
