using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentItem : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] RectTransform tooltipRectTransform;
    private ToolTipUI toolTip;
    private Item item;
    private Image icon;
    private Sprite defaultSprite;
    private Button button;
    private bool mouseOver;
    public string slotType;
    private Item.EquipmentType type;

    void Awake()
    {   
        toolTip = tooltipRectTransform.GetComponent<ToolTipUI>();
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

    private void OnDisable()
    {
        if(mouseOver){
            tooltipRectTransform.gameObject.SetActive(false);
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null){
            mouseOver = true;
            StartCoroutine(DisplayToolTip());
        }
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        if(item != null) mouseOver = false;
    }

    IEnumerator DisplayToolTip(){
        yield return new WaitForSecondsRealtime(0.2f);
        while(mouseOver){
            tooltipRectTransform.gameObject.SetActive(true);
            string toolTipText = item.name + "\n<color=#00ff00>" + item.stats.ToString() + "</color>";
            toolTip.SetText(toolTipText);
            yield return new WaitForSecondsRealtime(0.2f);
        }
        tooltipRectTransform.gameObject.SetActive(false);
    }
}
