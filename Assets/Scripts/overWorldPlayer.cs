using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overWorldPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    Inventory inventory;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
    }

    void Update () {
        handleMovement();
        handlePopups();
    }

    void handleMovement() {
        float mH = Input.GetAxis ("Horizontal");
        float mV = Input.GetAxis ("Vertical");
        rb.velocity = new Vector3 (mH * speed * Time.deltaTime, mV * speed * Time.deltaTime, 0);
    }

    void handlePopups() {
        if (Input.GetKey("i"))
        {
            Debug.Log("toggle inventory");
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Item"){
            Item item = col.gameObject.GetComponent<OverWorldItem>().getItem();
            this.inventory.addItem(item);
            this.inventory.debugPrint();
            Destroy(col.gameObject);
        }
    }


}
