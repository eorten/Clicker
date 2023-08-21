using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "F_", menuName = "new Float")]
public class S_Float : ScriptableObject
{
    public float DefaultValue;
    public float currentValue;

    public float CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    private void OnEnable()
    {
        currentValue = DefaultValue;
    }
}