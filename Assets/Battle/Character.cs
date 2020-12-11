using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public Stats stat;
    Stats baseStats;
    public bool isBoss = false;
    public List<Attack> attacks;

    public Sprite sprite = null;
    public RuntimeAnimatorController animator = null;

    public Character (Stats stats, List <Attack> attacks, Sprite sprite = null, RuntimeAnimatorController animator = null)
    {
        this.stat = stats;
        baseStats =stats;
        this.sprite = sprite;
        this.animator = animator;
        this.attacks = attacks;
    }

    public Character (int hp, int maxhp, int str, int def, int mag, int magdef, int speed, List <Attack> attacks)
    {
        stat = new Stats(hp, maxhp, str, def, mag, magdef, speed);
        this.attacks = attacks;
        baseStats = stat;
    }

    public Character (int hp, int maxhp, int str, int def, int mag, int magdef, int speed)
    {
        stat = new Stats(hp, maxhp, str, def, mag, magdef, speed);
        this.attacks = new List<Attack>();
        baseStats = stat;
    }
    
    public Character ()
    {
        stat = new Stats(10);
        this.attacks = new List<Attack>();
        baseStats = stat;
    }
    public void AddEquipToStats(Equipment equipment){
        stat = baseStats + equipment.GetStats();
        stat.hp = stat.maxhp;
    }
}
