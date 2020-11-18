using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Item item;
    private Image icon;
    private Button button;


    void Awake()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        button = transform.GetComponent<Button>();
    }

    public void SetItem(Item newItem)
    {
        Debug.Log("Setting item");
        item = newItem;
        icon.sprite = item.icon;
        button.onClick.AddListener(EquipItem);
    }

    public void EquipItem()
    {
        if(PlayerManager.Instance.equipment.EquipItem(item)){
            PlayerManager.Instance.inventory.RemoveItem(item);
            transform.parent.GetComponentInParent<InventoryUI>().Refresh();
            Destroy(this.gameObject);
        }
        
        
    }
}
