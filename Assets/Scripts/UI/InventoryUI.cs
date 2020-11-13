using System.Collections;
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
        prefab = background.Find("ItemUIPrefab");
<<<<<<< HEAD:Assets/Scripts/UI/InventoryUI.cs
<<<<<<< HEAD:Assets/Scripts/InventoryUI.cs
=======
        prefab = background.Find("InventoryItem");
=======
>>>>>>> 0d66609d2a9a9d6efdec8beeec075cfccceb3510:Assets/Scripts/UI/InventoryUI.cs
        SceneController.Instance.onInventoryDisplay += DrawInventory;
        SceneController.Instance.onInventoryClear += clear;
    }

    private void OnDestroy()
    {
        SceneController.Instance.onInventoryDisplay -= DrawInventory;
        SceneController.Instance.onInventoryClear -= clear;
<<<<<<< HEAD:Assets/Scripts/InventoryUI.cs
>>>>>>> Stashed changes:Assets/Scripts/UI/InventoryUI.cs
=======
>>>>>>> 0d66609d2a9a9d6efdec8beeec075cfccceb3510:Assets/Scripts/UI/InventoryUI.cs
=======
>>>>>>> b2776738083d1d7d69afade37851a27604d6029c:Assets/Scripts/InventoryUI.cs
    }


    public void clear(){
        foreach (Transform child in background) {
            if(child.gameObject.activeInHierarchy){
                GameObject.Destroy(child.gameObject);
            }
        }
        background.gameObject.SetActive(false);
    }
    public void DrawInventory(){
        background.gameObject.SetActive(true);

        int x = 0;
        int y = 0;
        
        foreach (Item item in PlayerManager.Instance.inventory.GetItems())
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
