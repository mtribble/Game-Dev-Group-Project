using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Policy;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public class stats (int hp, int maxhp, int str, int def, int mag, int magdef, int speed);

                    //Type false for physical, true for magic
    public class attack (bool type, int power);

    public class Character (stats stat, List<attack>);

    //to be included when finished elsewhere: enemy AI for choosing attacks)
    public class enemy:Character;

    //I'm not sure what we'll put in here that's unique for a player; probably equipment 
    public class player : Character {

    };

    Public bool run = false;

    public void combat (List <player> players, List <enemy> enemies) {
        //render players and enemies

        List<player> alivePlayers = players;
        List<enemy> aliveEnemies = enemies;

        while (run == false || alivePlayers.Count == 0 || aliveEnemies == 0) {
            List order = turnOrder(alivePlayers, aliveEnemies);

            for (int i == 0; i < order.Count; i++) {
                current = order(i);

                //have the player or the enemy take their turn 
            }


        }

        if (run == false || alivePlayers.Count == 0) return 0;
        else return 1;

    }

    public void turnOrder (List <player> players, List <enemy> enemies) {
        List <Character> allSides = players.Concat(enemies);
        List <Character> order;
        while (allSides.Count != 0) {
            int highSpeed = 0;
            int location = 1;
            for (int i = 0; i > allSides.Count; i++) {
                int current = allSides(i).stats.speed
                if (current > highSpeed) {
                    highSpeed = allSides(i).stats.speed;
                    location = i;
                }
            }
            order.Add(allSides.location);
            allSides.Remove(location);
        }
    }

    public void damageStep (attack move, stats attacker, stats defender) {
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

   










    //For testing purposes, to be deleted later
    attack sword(false, 65);
    attack bash(false, 50);
    attack ignite(true, 40);
    //in combat, be able to target yourself. Has the side effect that magic defense reduces healing, but that can be a feature. 
    attack heal(true, -40);

    enemy testenemy( (100, 100, 15, 10, 1, 5, 10), {bash} );
    player testplayer( (100, 100, 20, 5, 20, 5, 15), {sword, ignite, heal} );
}
