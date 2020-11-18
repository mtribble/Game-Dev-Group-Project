using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Equipment
{
    private List<Item> equipedItems = new List<Item>();

    public List<Item> GetItems(){
        return equipedItems;
    }

    //try to equip item. return true if successful 
    public bool EquipItem(Item item){
        foreach(Item equiped in equipedItems){
            if(equiped.itemType == item.itemType) return false;
        }
        equipedItems.Add(item);
        return true;
    }

    public bool UnequipItem(Item item){
        return equipedItems.Remove(item);
        
    }

    public Stats GetStats(){
        Stats total = new Stats(0);
        foreach(Item item in equipedItems){
            total += item.stats;
        }
        return total;
    }
}
