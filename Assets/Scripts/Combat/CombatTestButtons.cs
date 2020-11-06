using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestButtons : MonoBehaviour
{
    Charater player, enemy;

    private void Start()
    {
        player = PlayerManager.Instance.player;
        enemy = PlayerManager.Instance.enemy;
    }


    void SetHealth(int newHP){
        player.hp = newHP;
    }
    
    public void randAttack()
    {
        int playerDamage = Random.Range(0, 3);
        int enemyDamage = Random.Range(0, 3);
        if(Time.timeScale != 0)// this should be replaced
        {
            player.hp -= playerDamage;
            enemy.hp -= enemyDamage;
        }
        
    }
}
