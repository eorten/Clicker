using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    [SerializeField] private S_TileList tileList;
    [SerializeField] private float destroyDelay = 0.3f;
    [SerializeField] private int destroyDamage = 1;
    [SerializeField] private int destroyQueueAmount = 1;

    private bool isDestroying = false;
    private S_Float destroyQueue;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDestroying)
            {
                destroyQueue.CurrentValue += destroyQueueAmount;
            }
        }
    }

}
