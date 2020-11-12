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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        button.onClick.AddListener(EquipItem);
    }

    public void EquipItem()
    {
        Debug.Log("removing item");
        if (PlayerManager.Instance.inventory.RemoveItem(item))
        {
            Destroy(this.gameObject);
        }
    }
}
