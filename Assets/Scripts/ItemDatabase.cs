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
                new Item(0, "Axe", "A large axe. It's large enough to block some attacks, but also makes it more difficult to move quickly and cast spells",
                new Stats (0,0,20,5,-5,0,-10),
                1
                ),
                
                //Club
                new Item(1, "Club", "A club. It's quick to bash something with, but not very powerful",
                new Stats (0,0,10,0,0,0,5),
                1                   
                ),

                //Spear
                new Item(2, "Spear", "The spear's reach provides a mix of offense and defense",
                new Stats (0,0,15,5,0,0,0),
                1
                ),

                //Staff
                new Item(3, "Staff", "Boosts magical attack power, and the innate magic protects from enemy's magic",
                new Stats (0,0,5,0,20,10,0),
                1                  
                ),

                //Sword
                new Item(4, "Sword", "The sword acts as a conduit for magic, increasing physical and magical offense",
                new Stats (0,0,15,0,10,0,0),
                1
                ),

                //Iron Armor
                new Item(5, "Iron Armor", "Iron Armor Description", 
                new Stats (0,0,0,15,0,0,-5),
                2
                ),

                //Leather Armor
                new Item(6, "Leather Armor", "Leather Armor Description",
                new Stats (0,0,0,5,0,0,5),
                2
                ),

                //Cloak
                new Item(6, "Cloak", "Cloak Desctiption", 
                new Stats (0,0,0,0,10,10,0),
                2
                )
        };
    }

}
