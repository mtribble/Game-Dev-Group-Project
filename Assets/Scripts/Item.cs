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

    //Do not change order, used as index for Item array in equipment class
    public enum EquipmentType
    {
        Weapon,
        Head,
        Chest,
        Legs,
        Feet,
        None
    }

    public int id;
    public EquipmentType itemType;
    public string name;
    public string description;
    public Sprite icon;

    //temp name till task to move items to stats is pushed
    public Stats stats;

    public Item(int id, string name, string description, Stats stats, EquipmentType itemType = EquipmentType.None){
        this.id = id;
        this.name = name;
        this.description = description;
        this.stats = stats;
        if(itemType == Item.EquipmentType.Weapon){
            this.icon = Resources.Load<Sprite>("Sprites/Items/" + name);
        }
        else{
            this.icon = Resources.Load<Sprite>("Sprites/Items/id" + id.ToString());
        }
        this.itemType = itemType;
    }

    //copy constuctor
    public Item(Item item){
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.stats = item.stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.name);
        this.itemType = item.itemType;
    }
}
