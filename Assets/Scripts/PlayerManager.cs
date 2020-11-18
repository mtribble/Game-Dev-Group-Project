using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is a singleton (like objects in scala)
// it holds data about the player and when nessesary, about the enemy character
public class PlayerManager : MonoBehaviour
{
    public Character player, enemy;
    public Inventory inventory;
    public Equipment equipment;


    #region Singleton
    private static PlayerManager _instance;

    public static PlayerManager Instance 
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
        
        enemy = new Character(100, 100, 15, 10, 1, 5, 10);
        player = new Character(100, 100, 20, 5, 20, 5, 15);
        inventory = new Inventory();
        equipment = new Equipment();
    } 

    #endregion

}
