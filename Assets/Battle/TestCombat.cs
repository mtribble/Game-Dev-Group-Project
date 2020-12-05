using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombat : MonoBehaviour
{
    Character player, enemy;

    private void Start()
    {
        player = PlayerManager.Instance.player;
        enemy = PlayerManager.Instance.enemy;
    }

    int damageStep(Attack move, Stats attacker, Stats defender)
        {
            int atk;
            int def;
            if (move.type == false)
            {
            Debug.Log("detected as physical attack");
            atk = attacker.str;
            def = defender.def;
            }
            else
            {
            Debug.Log("Detected as magic attack");
                atk = attacker.mag;
                def = defender.magdef;
            }
        Debug.Log("Saved atk and def");
        int damage;
        if (move.power + atk - def < 0 && move.power > 0) { Debug.Log("Damage dealt was negative"); damage = 0; }
        else if (move.power + atk - def > 0 && move.power < 0) { Debug.Log("Heal was negative"); damage = 0; }
        else { damage = move.power + atk - def; }
        Debug.Log("Calculated damage " + damage.ToString());
        defender.hp = defender.hp - damage;
        Debug.Log("New hp: " + defender.hp.ToString());
        if (defender.hp > defender.maxhp) defender.hp = defender.maxhp;

            return defender.hp;

        }

        //For testing purposes, to be deleted later
        Attack sword = new Attack(false, 65);

        Attack bash = new Attack(false, 50);
        Attack ignite = new Attack(true, 40);
        //in combat, be able to target yourself. Has the side effect that magic defense reduces healing, but that can be a feature. 
        Attack heal = new Attack(true, -40);

        

        public Character testenemy = new Character(100, 100, 15, 10, 1, 5, 10);
        public Character testplayer = new Character(100, 100, 20, 5, 20, 5, 15);

       

        public void basicAttack()
        {
        Debug.Log("Basic attack selected");
        enemy.stat.hp = damageStep(sword, player.stat, enemy.stat);
            counter();
     
        }

        public void fireball()
        {
        Debug.Log("Fireball selected");
        enemy.stat.hp = damageStep(ignite, player.stat, enemy.stat);
            counter();
        }

        public void recover()
        {
        Debug.Log("Heal selected");
        player.stat.hp = damageStep(heal, player.stat, player.stat);
            counter();
        }

        public void counter()
        {
        if (enemy.stat.hp < 0) { }
        else
        {
            Debug.Log("Starting Enemy's Attack");
            player.stat.hp = damageStep(bash, enemy.stat, player.stat);
        }
        }

    
}
