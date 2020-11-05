using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overWorldPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    private string lastDir;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        handleMovement();
    }

    void handleMovement() {
        float mH = Input.GetAxis ("Horizontal");
        float mV = Input.GetAxis ("Vertical");
        if(mH != 0){
            if(mH > 0){
                lastDir = "UP";
            }
            else{
                lastDir = "DOWN";
            }
        }
        if(mV != 0){
            if(mV > 0){
                lastDir = "RIGHT";
            }
            else{
                lastDir = "LEFT";
            }
        }
        rb.velocity = new Vector3 (mH * speed, mV * speed, 0);
    }
    

    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "Item"){
            int itemID = col.gameObject.GetComponent<OverWorldItem>().ItemID;
            PlayerManager.Instance.player.inventory.debugPrint();
            PlayerManager.Instance.player.inventory.AddItem(itemID);
            PlayerManager.Instance.player.inventory.debugPrint();
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Enemy"){
            Debug.Log("Starting Battle");
            SceneController.Instance.LoadScene("Test_Battle");
            Destroy(col.gameObject);
        }
    }


}
