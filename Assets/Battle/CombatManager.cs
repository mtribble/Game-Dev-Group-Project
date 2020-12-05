using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;



public class CombatManager : MonoBehaviour

    //Separate classes into different files
{

    //to be included when finished elsewhere: enemy AI for choosing attacks)
    Character enemy;

    //I'm not sure what we'll put in here that's unique for a player; probably equipment 
    Character player;

    Equipment playerEquipment;


    void Start(){
        player = PlayerManager.Instance.player;
        enemy = PlayerManager.Instance.enemy;
        player.stat.hp = player.stat.maxhp;
        enemy.stat.hp = enemy.stat.maxhp;
        playerEquipment = PlayerManager.Instance.equipment;
    }
    
    public bool run = false;

    public void combatStarter (List <Character> players, List<Character> enemies) {

    }

    public int combat (List <Character> players, List <Character> enemies) {
        //render players and enemies

        List<Character> alivePlayers = players;
        List<Character> aliveEnemies = enemies;

        while (run == false || alivePlayers.Count == 0 || aliveEnemies.Count == 0) {
            List<Character> order = turnOrder(alivePlayers, aliveEnemies);

            for (int i = 0; i < order.Count; i++) {
                Character current = order[i];

                //have the player or the enemy take their turn 


            }


        }

        if (run == false || alivePlayers.Count == 0) return 0;
        else return 1;

    }

    public List<Character> turnOrder (List <Character> players, List <Character> enemies) {
        List <Character> allSides = players.Concat<Character>(enemies).ToList();
        List <Character> order = new List<Character>();
        while (allSides.Count != 0) {
            int highSpeed = 0;
            int location = 1;
            for (int i = 0; i > allSides.Count; i++) {
                int current = allSides[i].stat.speed;
                if (current > highSpeed) {
                    highSpeed = allSides[i].stat.speed;
                    location = i;
                }
            }
            order.Add(allSides[location]);
            allSides.RemoveAt(location);
        }
        return order;
    }

    public void damageStep (Attack move, Stats attacker, Stats defender) {
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
        int damage;
        if (move.power + atk - def < 0 && move.power > 0) { damage = 0; }
        else if (move.power + atk - def > 0 && move.power < 0) { damage = 0; }
        else { damage = move.power + atk - def; }
        defender.hp = defender.hp - damage;
    }



    public void Run(){
        player.stat.hp = 0;
    }

    public void Attack(){
        Attack sword = new Attack(false, 65);
        damageStep(sword, player.stat, enemy.stat);
    }

    public void Heal(){

    }

    public void MagicAttack(){

    }

    public void test() {

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


        combatStarter(allPlayers, allEnemies);


    }
}
