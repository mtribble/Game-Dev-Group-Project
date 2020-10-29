using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldItem : MonoBehaviour
{
    private Item item;

    public int ItemID = 0;
    
    private void Start(){
        item = new Item(ItemDatabase.Instance.GetItem(ItemID));
    }
    public Item getItem(){
        return item;
    }

}
