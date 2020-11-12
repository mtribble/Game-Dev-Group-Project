﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public int rows, columns;
    public float xPadding, yPadding;
    private Transform background;
    private Transform prefab;



    void Awake(){
        background = transform.Find("Background");
<<<<<<< Updated upstream:Assets/Scripts/InventoryUI.cs
        prefab = background.Find("ItemUIPrefab");
=======
        prefab = background.Find("InventoryItem");
        SceneController.Instance.onInventoryDisplay += DrawInventory;
        SceneController.Instance.onInventoryClear += clear;
    }

    private void OnDestroy()
    {
        SceneController.Instance.onInventoryDisplay -= DrawInventory;
        SceneController.Instance.onInventoryClear -= clear;
>>>>>>> Stashed changes:Assets/Scripts/UI/InventoryUI.cs
    }


    public void clear(){
        foreach (Transform child in background) {
            if(child.gameObject.activeInHierarchy){
                GameObject.Destroy(child.gameObject);
            }
        }
    }
    public void DrawInventory(){
        int x = 0;
        int y = 0;
        
        foreach (Item item in PlayerManager.Instance.player.inventory.GetItems())
        {
            RectTransform itemRectTransform = Instantiate(prefab, background).GetComponent<RectTransform>();
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


}
