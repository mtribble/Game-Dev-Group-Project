using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum AttackTypes
    {
        Normal,
        TestType
    }

    public int id;
    public string name;
    public string description;
    public Sprite icon;
<<<<<<< HEAD
    //public Stats stats;
    //public ItemType type;

    public Dictionary<string, int> stats = new Dictionary<string, int>();
=======
    //public Dictionary<string, int> stats = new Dictionary<string, int>();
    public Stats stats;
    public int type;
>>>>>>> b2776738083d1d7d69afade37851a27604d6029c

    public Item(int id, string name, string description, Stats stats, int type){
        this.id = id;
        this.name = name;
        this.description = description;
        this.stats = stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + name);
        this.type = type;
    }

    //copy constuctor
    public Item(Item item){
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.stats = item.stats;
        this.type = item.type;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.name);
    }
}
