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
    //public Stats stats;
    //public ItemType type;

    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string name, string description, Dictionary<string, int> stats){
        this.id = id;
        this.name = name;
        this.description = description;
        this.stats = stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + name);
    }

    //copy constuctor
    public Item(Item item){
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.stats = item.stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.name);
    }
}
