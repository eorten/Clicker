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
    [SerializeField] List<int> oreAmountChange;

    [SerializeField] GameObject InventoryElement;

    [SerializeField] Transform content;

    [SerializeField] UnityEvent Response;

    [SerializeField] PriceRaiseType priceRaiseType;

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

        for (int i = 0;i < oreAmount.Count; i++) {
            switch (priceRaiseType)
            {
                case PriceRaiseType.Add:
                    oreAmount[i] += oreAmountChange[i];
                    break;
                case PriceRaiseType.Multiply:
                    oreAmount[i] *= oreAmountChange[i];
                    break;
            }
        }

        Response.Invoke();
    }
}

public enum PriceRaiseType
{
    Add, Multiply
}