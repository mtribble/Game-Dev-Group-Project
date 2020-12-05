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
                new Item(0, "Axe", "A large axe. It's large enough to block some attacks, but also makes it more difficult to move quickly and cast spells", 
                new Stats (0,0,20,5,-5,0,-10), Item.EquipmentType.Weapon),

                //Club
                new Item(1, "Club", "A club. It's quick to bash something with, but not very powerful", 
                new Stats (0,0,10,0,0,0,5), Item.EquipmentType.Weapon),

                //Spear
                new Item(2, "Spear", "The spear's reach provides a mix of offense and defense", 
                new Stats (0,0,15,5,0,0,0), Item.EquipmentType.Weapon),

                //Staff
                new Item(3, "Staff", "Boosts magical attack power, and the innate magic protects from enemy's magic", 
                new Stats (0,0,5,0,20,10,0), Item.EquipmentType.Weapon),

                //Sword
                new Item(4, "Sword", "The sword acts as a conduit for magic, increasing physical and magical offense", 
                new Stats (0,0,15,0,10,0,0), Item.EquipmentType.Weapon),

                //Teir 0 Shirt
                new Item(5, "Leather Armor", "Leather armor that's quick to move in, but provides little extra defense", 
                new Stats(0,0,0,5,0,0,5), Item.EquipmentType.Chest),

                //Tier 0 Legs
                new Item(6, "Pants", "A plain pair of leggings that provides some protection", 
                new Stats(0,0,0,5,0,0,0), Item.EquipmentType.Legs),

                //Tier 0 Feet
                new Item(7, "Shoes", "Boots that provide traction, stabalizing your footing while blocking and charging", 
                new Stats(0,0,0,0,0,0,15), Item.EquipmentType.Feet),

                //Tier 1 Helmet
                new Item(8, "Magic Hood", "A basic hood infused with magic", 
                new Stats(0,0,0,0,0,5,0), Item.EquipmentType.Head),

                //Teir 1 Shirt
                new Item(9, "Cloak", "A cloak woven with magic. Disrupts magic from affecting your body, including healing magic",
                new Stats(0,0,0,0,15,0,0), Item.EquipmentType.Chest),

                //Tier 1 Legs
                new Item(10, "Magical Skirt", "Naturally, your magic power goes up by changing into a skirt. That's just science, or in this case magic",
                new Stats(0,0,0,0,5,10,0), Item.EquipmentType.Legs),
                //Tier 1 Feet
                new Item(11, "Magic shoes", "Shoes that provide magic protection. Enough protection to make your Fireball stronger, by kicking it at the enemy",
                new Stats(0,0,0,0,5,5,0), Item.EquipmentType.Feet),

                //Tier 2 Helmet
                new Item(12, "Iron Helmet", "A hard helmet that blocks damage",
                new Stats(0,0,0,10,0,0,0), Item.EquipmentType.Head),

                //Teir 2 Shirt
                new Item(13, "Iron Armor", "Heavy armor that provides suitable defenses, but slows you down",
                new Stats(0,0,0,15,0,5,-10), Item.EquipmentType.Chest),

                //Tier 2 Legs
                new Item(14, "Iron Leggings", "Blocks attacks, but the weight makes it harder to move",
                new Stats(0,0,0,10,0,0,-5), Item.EquipmentType.Legs),

                //Tier 2 Feet
                new Item(15, "Iron Boots", "Strapping metal to your feet... good luck swiming",
                new Stats(0,0,0,5,0,0,-15), Item.EquipmentType.Feet),

                //Tier 3 Helmet
                new Item(16, "Berserker Helm", "A helmet that boosts your attack",
                new Stats(10,10,5,-5,0,-5,0), Item.EquipmentType.Head),

                //Teir 3 Shirt
                new Item(17, "Berserker Plate", "A chestplate that allows for large bursts of damage, but reduces your defenses",
                new Stats(25,25,15,-15,-5,-15,5), Item.EquipmentType.Chest),

                //Tier 3 Legs
                new Item(18, "Berserker Pants", "Pants that improve your speed at the cost of defense",
                new Stats(20,20,5,-10,0,-15,10), Item.EquipmentType.Legs),

                //Tier 3 Feet
                new Item(19, "Berserker Boots", "Boots that help you kick things real good",
                new Stats(5,5,5,0,-5,0,10), Item.EquipmentType.Feet),

                //Tier 4 Helmet
                new Item(20, "Hero Helm", "A heroic helmet that improves physical and magical resistances",
                new Stats(0,0,0,5,0,5,0), Item.EquipmentType.Head),

                //Teir 4 Shirt
                new Item(21, "Hero Plate", "A sturdy chestplate that provides balanced stats",
                new Stats(5,5,0,10,0,5,0), Item.EquipmentType.Chest),

                //Tier 4 Legs
                new Item(22, "Hero Pants", "Defensive armor that also improves vitality",
                new Stats(10,10,0,5,0,5,0), Item.EquipmentType.Legs),

                //Tier 4 Feet
                new Item(23, "Hero Boots", "Boots that provide defense without slowing you down",
                new Stats(0,0,0,5,0,5,5), Item.EquipmentType.Feet)

        };
        doneBuilding = true;
    }

}
