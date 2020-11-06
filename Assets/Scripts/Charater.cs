using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater
{
    public Sprite battleSprite;
    public Inventory inventory;
    public int hp, maxhp, str, def, mag, magdef, speed;

    public Charater(){
        hp = 10;
        maxhp = 10;
        str = 10;
        mag = 10;
        magdef = 10;
        speed = 10;
        inventory = new Inventory();
    }
}
