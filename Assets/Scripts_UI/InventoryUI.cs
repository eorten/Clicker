using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] S_Inventory playerInventory;
    [SerializeField] Transform content;
    [SerializeField] GameObject InventoryItemPrefab;
    public void UpdateUI()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in playerInventory.currentValue)
        {
            GameObject newItem = Instantiate(InventoryItemPrefab, content);
            newItem.GetComponent<Image>().color = item.Key.color;
            newItem.GetComponentInChildren<TextMeshProUGUI>().text = item.Value + "";
        }
    }
    
}
