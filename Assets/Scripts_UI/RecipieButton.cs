using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecipieButton : MonoBehaviour
{
    [SerializeField] S_Inventory playerInventory;
    [SerializeField] List<OreProfile> ores;
    [SerializeField] List<int> oreAmount;

    [SerializeField] GameObject InventoryElement;

    [SerializeField] Transform content;

    [SerializeField] UnityEvent Response;



    private void Start()
    {
        for (int i = 0; i < ores.Count; i++)
        {
            OreProfile oreProfile = ores[i];
            int oreProfileAmount = oreAmount[i];
            GameObject newItem = Instantiate(InventoryElement, content);

            newItem.GetComponent<Image>().color = oreProfile.color;
            newItem.GetComponentInChildren<TextMeshProUGUI>().text = oreProfileAmount + "";
        }
    }

    public void Clicked()
    {
        for (int i = 0; i < ores.Count; i++)
        {
            OreProfile oreProfile = ores[i];
            int oreProfileAmount = oreAmount[i];

            if (!(playerInventory.currentValue.ContainsKey(oreProfile) && playerInventory.currentValue[oreProfile] >= oreProfileAmount))
            {
                return;
            }
        }
        Response.Invoke();
    }
}
