using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overWorldPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
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
        Debug.Log("Collison with:" + col.gameObject.tag);

        if(col.gameObject.tag == "Item"){
            Item item = col.gameObject.GetComponent<OverWorldItem>().getItem();
            BattleManager.Instance.inventory.addItem(item);
            BattleManager.Instance.inventory.debugPrint();
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Enemy"){
            Debug.Log("Starting Battle");
            Destroy(col.gameObject);
        }
    }


}
