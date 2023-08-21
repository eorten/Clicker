using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "In_", menuName = "new Inventory")]
public class S_Inventory : ScriptableObject
{
    public Dictionary<OreProfile, int> DefaultValue = new Dictionary<OreProfile, int>();
    public Dictionary<OreProfile, int> currentValue;

    public Dictionary<OreProfile, int> CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }
    private void OnEnable()
    {
        currentValue = DefaultValue;
    }


    public void Add(OreProfile profile, int amount)
    {
        if (CurrentValue.ContainsKey(profile)) { CurrentValue[profile] += amount; }
        else
        {
            CurrentValue.Add(profile, amount);
        }
    }

    public void Remove(OreProfile profile, int amount) {
        //Reduce
        CurrentValue[profile] -= amount;

        //If 0, remove entry from inventory
        if(CurrentValue[profile] == 0)
        {
            CurrentValue.Remove(profile);
        }
    }
}
