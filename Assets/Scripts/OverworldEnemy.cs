using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldEnemy : MonoBehaviour
{
    [SerializeField] int hp =  0, maxhp = 0, str = 0, def = 0, mag = 0, magdef = 0, speed = 0;
    [SerializeField] bool hasSwordAtack = false, hasBashAttack = true, hasIgniteAttack = false, hasHealAttack = false;
    public Character character;
    Attack sword = new Attack(false, 65);
    Attack bash = new Attack(false, 50);
    Attack ignite = new Attack(true, 40); 
    Attack heal = new Attack(true, -40);

    // Start is called before the first frame update
    void Start()
    {
        List<Attack> attacks = new List<Attack>();
        if(hasSwordAtack){
            attacks.Add(sword);
        }
        if(hasBashAttack){
            attacks.Add(bash);
        }
        if(hasIgniteAttack){
            attacks.Add(ignite);
        }
        if(hasHealAttack){
            attacks.Add(heal);
        }
        SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
        Animator am = gameObject.GetComponent<Animator>();
        if(sp != null){
            if(am != null){
                character = new Character(new Stats(hp,maxhp,str,def,mag,magdef,speed), attacks, sp.sprite, am.runtimeAnimatorController);
            }

            else{
                character = new Character(new Stats(hp,maxhp,str,def,mag,magdef,speed), attacks, sp.sprite);
            }
        }

        else{
             Debug.Log("cannot find sprite");
        }
            
    }

}
