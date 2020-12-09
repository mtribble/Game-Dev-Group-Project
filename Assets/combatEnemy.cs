using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        Animator am = gameObject.GetComponent<Animator>();
        if(am != null){
            Debug.Log("seting enemy animaor");
            am.runtimeAnimatorController = PlayerManager.Instance.enemy.animator;
        } 
        if(sr != null){
            Debug.Log("seting enemy sprite");
            sr.sprite = PlayerManager.Instance.enemy.sprite;
        } 
    }

}
