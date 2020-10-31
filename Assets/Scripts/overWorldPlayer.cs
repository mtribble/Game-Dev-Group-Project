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



    private void FixedUpdate()
    {
        handleMovement();
    }

    void handleMovement() {
        float mH = Input.GetAxis ("Horizontal");
        float mV = Input.GetAxis ("Vertical");
        rb.velocity = new Vector3 (mH * speed, mV * speed, 0);
    }


    void OnTriggerEnter2D(Collider2D col){

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
