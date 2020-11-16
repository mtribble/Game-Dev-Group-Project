using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{
    private Item item;
    private Image icon;
    private Sprite defaultSprite;
    private Button button;

    public string slotType;
    private Item.EquipmentType type;

    void Awake()
    {   
        type = (Item.EquipmentType) Enum.Parse(typeof(Item.EquipmentType), slotType, true);
        icon = transform.Find("Icon").GetComponent<Image>();
        defaultSprite = icon.sprite;
        button = transform.GetComponent<Button>();
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        button.onClick.AddListener(UnquipItem);
    }

    public void UnquipItem()
    {
        Item temp = item;
        if(PlayerManager.Instance.equipment.UnequipItem(item)){
            button.onClick.RemoveListener(UnquipItem);
            icon.sprite = defaultSprite;
            PlayerManager.Instance.inventory.AddItem(temp);
            transform.parent.GetComponentInParent<InventoryUI>().Refresh();
        }
    }

    public Item.EquipmentType GetItemType(){
        return type;
    }
}
