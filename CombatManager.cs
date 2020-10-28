using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Policy;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public class stats (int hp, int maxhp, int str, int def, int mag, int magdef);

                    //Type false for physical, true for magic
    public class attack (bool type, int power);

    public void combat (attack move, stats attacker, stats defender) {
        int atk;
        int def;
        if (move.type == false) {
            atk = attacker.str;
            def = defender.def;
        }
        else {
            atk = attacker.mag;
            def = defender.magdef;
        }
        int damage = move.power * atk - def;
        defender.hp = defender.hp - damage;
    }

    //to be included when finished elsewhere: enemy AI for choosing attacks)
    public class enemy (stats stat, List<attack> moves);

    //I'm not sure what we'll put in here that's unique for a player; probably equipment 
    public class player (stats stat, List<attack> moves);










    //For testing purposes, to be deleted later
    attack sword(false, 65);
    attack bash(false, 50);
    attack ignite(true, 40);
    //in combat, be able to target yourself. Has the side effect that magic defense reduces healing, but that can be a feature. 
    attack heal(true, -40);

    enemy testenemy( (100, 100, 15, 10, 1, 5), {bash} );
    player testplayer( (100, 100, 20, 5, 20, 5), {sword, ignite, heal} );
}
