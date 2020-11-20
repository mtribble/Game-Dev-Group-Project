using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] RectTransform tooltipRectTransform;
    private ToolTipUI toolTip;
    private Item item;
    private Image icon;
    private Button button;

    private bool mouseOver;


    void Awake()
    {
        toolTip = tooltipRectTransform.GetComponent<ToolTipUI>();
        icon = transform.Find("Icon").GetComponent<Image>();
        button = transform.GetComponent<Button>();
    }

    public void SetItem(Item newItem)
    {
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

    private void OnDestroy()
    {
        if(mouseOver){
            tooltipRectTransform.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        StartCoroutine(DisplayToolTip());
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
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
