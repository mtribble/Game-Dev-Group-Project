using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signpost : MonoBehaviour
{
    public string dialog;

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            SceneController.Instance.DisplayDialog(dialog);
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            SceneController.Instance.ClearDialog();
        }   
    }
}
