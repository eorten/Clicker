using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class ExcavatorManager : MonoBehaviour
{
    [SerializeField] private S_Int queuedBlocks;
    [SerializeField] S_ExcavatorList excavatorList;
    [SerializeField] S_TileList planet;

    private void Start()
    {
        StartCoroutine(Execute());
    }

    private IEnumerator Execute()
    {
        if (queuedBlocks.CurrentValue > 0)
        {
            foreach (Excavator excav in excavatorList.CurrentValue)
            {
                for (int i = 0; i < planet.CurrentValue.Count; i++)
                {

                }
            }
        }
        yield return null;
        yield return null;
    }


}
