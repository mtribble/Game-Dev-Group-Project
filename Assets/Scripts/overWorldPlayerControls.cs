using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overWorldPlayerControls : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        float mH = Input.GetAxis ("Horizontal");
        float mV = Input.GetAxis ("Vertical");
        rb.velocity = new Vector3 (mH * speed, mV * speed, 0);
    }
}
