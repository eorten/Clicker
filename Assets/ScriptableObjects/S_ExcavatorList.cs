using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExL_", menuName = "new ExcavatorList")]
public class S_ExcavatorList : ScriptableObject
{
    public List<Excavator> DefaultValue = new List<Excavator>();
    public List<Excavator> currentValue;

    public List<Excavator> CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }
    private void OnEnable()
    {
        currentValue = DefaultValue;
    }

    public void Add(Excavator item)
    {
        if (!CurrentValue.Contains(item))
        {
            CurrentValue.Add(item);
        }
    }

    public void Remove(Excavator item)
    {
        CurrentValue.Remove(item);
    }
}
