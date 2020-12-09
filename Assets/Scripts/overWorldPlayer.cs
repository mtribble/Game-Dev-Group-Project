using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overWorldPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Animator animator;

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
        Vector3 newVel = new Vector3 (mH * speed, mV * speed, 0);
        rb.velocity = Vector3.ClampMagnitude(newVel,speed);

        animator.SetFloat("Horizontal", mH);
        animator.SetFloat("Vertical", mV);
        animator.SetFloat("Speed", speed);
    }
    

    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "Item"){
            int itemID = col.gameObject.GetComponent<OverWorldItem>().ItemID;
            PlayerManager.Instance.inventory.AddItem(itemID);
            PlayerManager.Instance.inventory.debugPrint();
            SceneController.Instance.AddToManifest(col.transform.position);
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Enemy"){
            Debug.Log("Starting Battle");
            SceneController.Instance.SetCurrentEnemy(col.transform.position);
            Destroy(col.gameObject);
            SceneController.Instance.LoadScene("Test_Battle", rb.velocity);
        }
    }


}
