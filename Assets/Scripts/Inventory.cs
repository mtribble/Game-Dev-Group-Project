using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();
    }

    public void addItem(Item item){
        itemList.Add(item);
    }

    public void debugPrint(){
        string s = "Inventory: ";
        foreach (Item i in itemList)
        {
            s += i.name + " ";
        }
        Debug.Log(s);
    }
}
