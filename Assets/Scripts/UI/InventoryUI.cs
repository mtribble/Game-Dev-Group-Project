using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public int rows, columns;
    public float xPadding, yPadding;
    private Transform itemsBackground, equipmentBackground, tooltipTransform;
    private Transform prefab;

    public Transform weaponSlot, helmetSlot, chestSlot, legsSlot, feetSlot;

    private EquipmentItem weapon, helmet, chest, legs, feet;



    void Awake(){
        weapon = weaponSlot.GetComponent<EquipmentItem>();
        helmet = helmetSlot.GetComponent<EquipmentItem>();
        chest = chestSlot.GetComponent<EquipmentItem>();
        legs = legsSlot.GetComponent<EquipmentItem>();
        feet = feetSlot.GetComponent<EquipmentItem>();
        itemsBackground = transform.Find("ItemsBackground");
        equipmentBackground = transform.Find("EquipmentBackground");
        prefab = itemsBackground.Find("ItemUIPrefab");
        SceneController.Instance.onInventoryDisplay += DrawInventory;
        SceneController.Instance.onInventoryClear += clear;
    }

    private void OnDestroy()
    {
        SceneController.Instance.onInventoryDisplay -= DrawInventory;
        SceneController.Instance.onInventoryClear -= clear;
    }

    public void clear(){
        foreach (Transform child in itemsBackground) {
            if(child.gameObject.activeInHierarchy){
                GameObject.Destroy(child.gameObject);
            }
        }
        itemsBackground.gameObject.SetActive(false);
        equipmentBackground.gameObject.SetActive(false);
    }
    public void DrawInventory(){
        itemsBackground.gameObject.SetActive(true);
        equipmentBackground.gameObject.SetActive(true);
        List<EquipmentItem> slots = new List<EquipmentItem>(){weapon, helmet, chest, legs, feet};
        foreach(Item item in PlayerManager.Instance.equipment.GetItems()){
            EquipmentItem slot = slots.Find(s => s.GetItemType() == item.itemType);
            if(slot == null){
                Debug.Log("Cannot find slot");
            }
            else{
                slot.SetItem(item);
            }
        }

        int x = 0;
        int y = 0;
        
        foreach (Item item in PlayerManager.Instance.inventory.GetItems())
        {
            RectTransform itemRectTransform = Instantiate(prefab, itemsBackground).GetComponent<RectTransform>();
            itemRectTransform.gameObject.SetActive(true);
            itemRectTransform.anchoredPosition = new Vector2(x * (itemRectTransform.rect.width + xPadding) , -1 * y * (itemRectTransform.rect.height + yPadding));
            InventoryItem invItem = itemRectTransform.GetComponent<InventoryItem>();
            invItem.SetItem(item);

            x++;
            if(x > columns){
                x = 0;
                y++;
                if(y > rows){
                    Debug.Log("Too many items in inventory to display");
                    break;
                }
            }
        }   
    }


    public void Refresh(){
        clear();
        DrawInventory();
    }
}
