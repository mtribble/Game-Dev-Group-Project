using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    private Transform textBoxTransform;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        textBoxTransform = transform.Find("TextBox");
        text = transform.Find("Text").GetComponent<Text>();
        SceneController.Instance.onDialogDisplay += Display;
        SceneController.Instance.onDialogDisplayClear += Clear;
    }

    private void OnDestroy()
    {
        SceneController.Instance.onDialogDisplay -= Display;
        SceneController.Instance.onDialogDisplayClear -= Clear;
    }

    private void Display(string dialog)
    {
        textBoxTransform.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = dialog;
    }


    private void Clear()
    {
        text.gameObject.SetActive(false);
        textBoxTransform.gameObject.SetActive(false);
    }
}
