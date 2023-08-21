using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TiL_", menuName = "new TileList")]
public class S_TileList : ScriptableObject
{
    public List<Tile> DefaultValue = new List<Tile>();
    public List<Tile> currentValue;

    public List<Tile> CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }
    private void OnEnable()
    {
        currentValue = DefaultValue;
    }

    public void Add(Tile tile)
    {
        if (!CurrentValue.Contains(tile)) {
            CurrentValue.Add(tile);
        }
    }

    public void Remove(Tile tile)
    {
        CurrentValue.Remove(tile);
    }
}
