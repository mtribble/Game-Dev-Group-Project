using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signpost : MonoBehaviour
{
    public GameObject TextBox;
    public Text Text;
    public string dialog;
    bool inFocus;
    
    // Start is called before the first frame update
    void Start()
    {
        inFocus = false;
        TextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inFocus){ //TODO: add interact button check
            TextBox.SetActive(true);
            Text.text = dialog;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            inFocus = true;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            inFocus = false;
            TextBox.SetActive(false);
        }   
    }
}
