using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public Stats stat; 
    public List<Attack> attacks;
    public List<Item> Equipment;

    public Sprite sprite = null;
    public RuntimeAnimatorController animator = null;

    public Character (Stats stats, List <Attack> attacks, Sprite sprite = null, RuntimeAnimatorController animator = null)
    {
        this.stat = stats;
        this.sprite = sprite;
        this.animator = animator;
        this.attacks = attacks;
        Equipment = new List<Item>();
    }

    public Character (int hp, int maxhp, int str, int def, int mag, int magdef, int speed, List <Attack> attacks)
    {
        stat = new Stats(hp, maxhp, str, def, mag, magdef, speed);
        this.attacks = attacks;
        Equipment = new List<Item>();
    }

    public Character (int hp, int maxhp, int str, int def, int mag, int magdef, int speed)
    {
        stat = new Stats(hp, maxhp, str, def, mag, magdef, speed);
        this.attacks = new List<Attack>();
        Equipment = new List<Item>();
    }
    
    public Character ()
    {
        stat = new Stats(10);
        this.attacks = new List<Attack>();
        Equipment = new List<Item>();
    }

    //use 1 to add stats together, use -1 to reduce stats
    public Character changeStats (Character player, Stats stats, int modifier) {
        player.stat.hp = player.stat.hp + stats.hp * modifier;
        player.stat.maxhp = player.stat.maxhp + stats.maxhp * modifier;
        player.stat.str = player.stat.str + stats.str * modifier;
        player.stat.def = player.stat.def + stats.def * modifier;
        player.stat.mag = player.stat.mag + stats.mag * modifier;
        player.stat.magdef = player.stat.magdef + stats.magdef * modifier;
        player.stat.speed = player.stat.speed + stats.speed * modifier;

        return player;
    }

    public Character ChangeEquipment(Character player, Item equipment) {
        Item.EquipmentType itemType = equipment.itemType;
        Item toChange = null;

        for (int i = 0; i < Equipment.Count && toChange != null; i++)
        {
            if (Equipment[i].itemType == itemType) { 
                toChange = Equipment[i];
                player.Equipment.RemoveAt(i);
            }
        }

        if (toChange != null) player = changeStats(player, toChange.stats, -1);
        player = changeStats(player, equipment.stats, 1);
        player.Equipment.Add(equipment);

        return player;
    }
}
