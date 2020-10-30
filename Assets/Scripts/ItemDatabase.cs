using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
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

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        buildDB();
    } 

   public List<Item> items = new List<Item>();

    public Item GetItem(int id){
        return items.Find(item => item.id == id);
    }
    public Item GetItem(string itemName){
        return items.Find(item => item.name == itemName);
    }
    void buildDB(){
        items = new List<Item>{
                //Axe
                new Item(0, "Axe", "this is the axe weapon description", 
                new Dictionary<string, int>{
                    {"Type", (int) Item.AttackTypes.Normal},
                    {"Attack", 10},
                    {"Defence", 5}
                }),

                //Club
                new Item(1, "Club", "this is the club weapon description", 
                new Dictionary<string, int>{
                    {"Type", (int) Item.AttackTypes.Normal},
                    {"Attack", 15},
                    {"Defence", 0}
                }),

                //Spear
                new Item(2, "Spear", "this is the spear weapon description", 
                new Dictionary<string, int>{
                    {"Type", (int) Item.AttackTypes.Normal},
                    {"Attack", 12},
                    {"Defence", 5}
                }),

                //Staff
                new Item(3, "Staff", "this is the staff weapon description", 
                new Dictionary<string, int>{
                    {"Type", (int) Item.AttackTypes.TestType},
                    {"Attack", 10},
                    {"TypeAttack", 5},
                    {"Defence", 0}
                }),

                //Sword
                new Item(4, "Sword", "this is the sword weapon description", 
                new Dictionary<string, int>{
                    {"Type", (int) Item.AttackTypes.Normal},
                    {"Attack", 10},
                    {"Defence", 10}
                })
        };
    }

}
