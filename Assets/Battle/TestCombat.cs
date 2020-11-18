using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombat : MonoBehaviour
{
    public void test()
    {

        int damageStep(Attack move, Stats attacker, Stats defender)
        {
            int atk;
            int def;
            if (move.type == false)
            {
                atk = attacker.str;
                def = defender.def;
            }
            else
            {
                atk = attacker.mag;
                def = defender.magdef;
            }
            int damage = move.power * atk - def;
            defender.hp = defender.hp - damage;
            if (defender.hp > defender.maxhp) defender.hp = defender.maxhp;

            return defender.hp;

        }

        //For testing purposes, to be deleted later
        Attack sword = new Attack(false, 65);

        Attack bash = new Attack(false, 50);
        Attack ignite = new Attack(true, 40);
        //in combat, be able to target yourself. Has the side effect that magic defense reduces healing, but that can be a feature. 
        Attack heal = new Attack(true, -40);

        List<Attack> TestEnemyAttacks = new List<Attack>();
        TestEnemyAttacks.Add(bash);

        List<Attack> TestPlayerAttacks = new List<Attack>();
        TestEnemyAttacks.Add(sword);
        TestEnemyAttacks.Add(ignite);
        TestEnemyAttacks.Add(heal);

        Character testenemy = new Character(100, 100, 15, 10, 1, 5, 10, TestEnemyAttacks);
        Character testplayer = new Character(100, 100, 20, 5, 20, 5, 15, TestPlayerAttacks);

        List<Character> allPlayers = new List<Character>();
        allPlayers.Add(testplayer);

        List<Character> allEnemies = new List<Character>();
        allEnemies.Add(testenemy);

        Stats basicAttack(Stats attacker, Stats defender)
        {
            defender.hp = damageStep(sword, attacker, defender);
            return defender;
        }

        Stats fireball(Stats attacker, Stats defender)
        {
            defender.hp = damageStep(ignite, attacker, defender);
            return defender;
        }

        Stats recover(Stats attacker)
        {
            attacker.hp = damageStep(heal, attacker, attacker);
            return attacker;
        }

    }
}
