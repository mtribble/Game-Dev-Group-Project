﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is a singleton (like objects in scala)
// it holds data about the player and when nessesary, about the enemy character
public class PlayerManager : MonoBehaviour
{
    public Charater player, enemy;


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
        player = new Charater();
        enemy = new Charater();
    } 

    #endregion

}
