using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "I_", menuName = "new Int")]
public class S_Int : ScriptableObject
{
    public int DefaultValue;
    public int currentValue;

    public int CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    private void OnEnable()
    {
        currentValue = DefaultValue;
    }
}