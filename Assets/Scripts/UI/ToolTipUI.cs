using UnityEngine;
using TMPro;

public class ToolTipUI : MonoBehaviour
{
    private RectTransform rectTransform, backgroundRectTransform;
    [SerializeField] private RectTransform canvasRectTransform;
    private TextMeshProUGUI textMeshProUGUI;

    void Awake(){
        rectTransform = transform.GetComponent<RectTransform>();
        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        textMeshProUGUI = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string newText){
        textMeshProUGUI.SetText(newText);
        textMeshProUGUI.ForceMeshUpdate();

        Vector2 size = textMeshProUGUI.GetRenderedValues(false);

        backgroundRectTransform.sizeDelta = size;
    }

    private void Update(){
        Vector2 offset = new Vector2(10,10);
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        anchoredPosition += offset;
        if(anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width){
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if(anchoredPosition.x < 0){
            anchoredPosition.x = 0;
        }
        if(anchoredPosition.y + backgroundRectTransform.rect.height > canvasRectTransform.rect.height){
            anchoredPosition.y = canvasRectTransform.rect.height - backgroundRectTransform.rect.height;
        }
        if(anchoredPosition.y < 0){
            anchoredPosition.y = 0;
        }
        rectTransform.anchoredPosition = anchoredPosition;
    }

}
