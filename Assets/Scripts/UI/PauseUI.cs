using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = transform.Find("PauseText").GetComponent<Text>();
        SceneController.Instance.onPauseDisplay += Display;
        SceneController.Instance.onPauseDisplayClear += Clear;
    }

    private void OnDestroy()
    {
        SceneController.Instance.onPauseDisplay -= Display;
        SceneController.Instance.onPauseDisplayClear -= Clear;
    }

    void Display()
    {
        text.gameObject.SetActive(true);
    }

    void Clear()
    {
        text.gameObject.SetActive(false);
    }

}
