using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using TMPro;

public class Excavator : MonoBehaviour
{
    [SerializeField] S_TileList planet;
    [SerializeField] int excavateDamage;
    [SerializeField] int exavationsPerMinute = 60;
    [SerializeField] int queuedExcavations;
    [SerializeField] int maxQueuedExcavations;
    //[SerializeField] Slider queuedSlider;
    private Tile tile;


    private float timeSinceLastExcavate = 0;
    private void Update()
    {
        if (timeSinceLastExcavate > (exavationsPerMinute/60) && queuedExcavations > 0)
        {
            if (tile == null || tile.GetHP() <= 0)
            {
                tile = FindNewTile();
            }

            if (tile != null)
            {
                timeSinceLastExcavate = 0;
                queuedExcavations--;
                UpdateUI();
                tile.TakeDamage(excavateDamage);
            }
        }
        timeSinceLastExcavate += Time.deltaTime;

    }

    public void Queue()
    {
        if (queuedExcavations < maxQueuedExcavations)
        {
            queuedExcavations++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        //queuedSlider.maxValue = maxQueuedExcavations;
        //queuedSlider.value = queuedExcavations;
    }

    private Tile FindNewTile()
    {
        for (int i = 0 ; i < planet.CurrentValue.Count; i++)
        {
            if (planet.CurrentValue[i].GetHP() > 0)
            {   
                return planet.CurrentValue[i];
            }
        }
        return null;
    }

    public void UpgradeDMG()
    {
        excavateDamage++;
    }
    public void UpgradeASP()
    {
        exavationsPerMinute++;
    }
}
