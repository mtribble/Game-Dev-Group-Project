using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private bool doneBuilding;
    private static ItemDatabase _instance;

    public static ItemDatabase Instance 
    { 
        get { return _instance; } 
    } 

    private void Awake() 
    { 
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }
        doneBuilding = false;
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        buildDB();
    } 

   public List<Item> items = new List<Item>();

    public Item GetItem(int id){
        while(doneBuilding == false){

        }
        return items.Find(item => item.id == id);
    }
    public Item GetItem(string itemName){
        while(doneBuilding == false){
            
        }
        return items.Find(item => item.name == itemName);
    }
    void buildDB(){
        items = new List<Item>{
                //Axe
                new Item(0, "Axe", "this is the axe weapon description", 
                new Stats (0,0,20,5,-5,0,-10), Item.EquipmentType.Weapon),

                //Club
                new Item(1, "Club", "this is the club weapon description", 
                new Stats (0,0,10,0,0,0,5), Item.EquipmentType.Weapon),

                //Spear
                new Item(2, "Spear", "this is the spear weapon description", 
                new Stats (0,0,15,5,0,0,0), Item.EquipmentType.Weapon),

                //Staff
                new Item(3, "Staff", "this is the staff weapon description", 
                new Stats (0,0,5,0,20,10,0), Item.EquipmentType.Weapon),

                //Sword
                new Item(4, "Sword", "this is the sword weapon description", 
                new Stats (0,0,15,0,10,0,0), Item.EquipmentType.Weapon),

                //Teir 0 Shirt
                new Item(5, "Shirt", "this is a plain shirt", 
                new Stats(0), Item.EquipmentType.Chest),

                //Tier 0 Legs
                new Item(6, "Pants", "this is a plain pair of pants", 
                new Stats(0), Item.EquipmentType.Legs),

                //Tier 0 Feet
                new Item(7, "Shoes", "this is a plain pair of sandles", 
                new Stats(0), Item.EquipmentType.Feet),

                //Tier 1 Helmet
                new Item(8, "Tier 1 helmet", "this is a a helmet", 
                new Stats(0), Item.EquipmentType.Head)

                //Teir 1 Shirt

                //Tier 1 Legs

                //Tier 1 Feet

                //Tier 2 Helmet

                //Teir 2 Shirt

                //Tier 2 Legs

                //Tier 2 Feet

                //Tier 3 Helmet

                //Teir 3 Shirt

                //Tier 3 Legs

                //Tier 3 Feet

                //Tier 4 Helmet

                //Teir 4 Shirt

                //Tier 4 Legs

                //Tier 4 Feet

        };
        doneBuilding = true;
    }

}
