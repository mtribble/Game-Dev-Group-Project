using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
   public int hp, maxhp, str, def, mag, magdef, speed;

    public Stats(int hp, int maxhp, int str, int def, int mag, int magdef, int speed)
    {
        this.hp = hp;
        this.maxhp = maxhp;
        this.str = str;
        this.def = def;
        this.mag = mag;
        this.magdef = magdef;
        this.speed = speed;
    }
}
