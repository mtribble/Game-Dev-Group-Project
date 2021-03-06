﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public delegate void Notify();
    public Notify onInventoryChange;

    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();
    }

    public void AddItem(Item item){
        itemList.Add(item);
    }

    public void AddItem(int id){
        itemList.Add(ItemDatabase.Instance.GetItem(id));
        onInventoryChange?.Invoke();
    }

    public List<Item> GetItems(){
        return itemList;
    }

    public bool RemoveItem(Item item)
    {
        return itemList.Remove(item);
    }

    public bool RemoveItem(int id)
    {
        bool retVal = itemList.Remove(ItemDatabase.Instance.GetItem(id));
        onInventoryChange?.Invoke();
        return retVal;
    }

    public void debugPrint(){
        string s = "Inventory: ";

        foreach (Item i in itemList)
        {
            s += "\n" + i.name + ": ";

            //foreach (KeyValuePair<string, int> stat in ItemDatabase.Instance.GetItem(i.name).stats)
            //{
            //    s += stat.Key + ": " + stat.Value.ToString() + " ";
            //}
        }
        //Debug.Log(s);
    }
}
