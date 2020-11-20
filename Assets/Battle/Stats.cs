using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public Stats()
    {
        this.hp = 10;
        this.maxhp = 10;
        this.str = 10;
        this.def = 10;
        this.mag = 10;
        this.magdef = 10;
        this.speed = 10;
    }

    public Stats(int allStats)
    {
        this.hp = allStats;
        this.maxhp = allStats;
        this.str = allStats;
        this.def = allStats;
        this.mag = allStats;
        this.magdef = allStats;
        this.speed = allStats;
    }


    public static Stats operator +(Stats a, Stats b)
    {
        return new Stats(
            a.hp + b.hp, 
            a.maxhp + b.maxhp, 
            a.str + b.str, 
            a.def + b.def, 
            a.mag + b.mag,
            a.magdef + b.magdef,
            a.speed + b.speed);
    }
    public static Stats operator -(Stats a, Stats b)
    {
        return new Stats(
            a.hp - b.hp, 
            a.maxhp - b.maxhp, 
            a.str - b.str, 
            a.def - b.def, 
            a.mag - b.mag,
            a.magdef - b.magdef,
            a.speed - b.speed);
    }
    public static Stats operator *(Stats a, Stats b)
    {
        return new Stats(
            a.hp * b.hp, 
            a.maxhp * b.maxhp, 
            a.str * b.str, 
            a.def * b.def, 
            a.mag * b.mag,
            a.magdef * b.magdef,
            a.speed * b.speed);
    }
    public static Stats operator /(Stats a, Stats b)
    {
        if (b.hp == 0 || b.maxhp == 0 || b.str == 0 || b.def == 0 || b.mag == 0 || b.magdef == 0 || b.speed == 0)
        {
            throw new DivideByZeroException();
        }
        return new Stats(
            a.hp / b.hp, 
            a.maxhp / b.maxhp, 
            a.str / b.str, 
            a.def / b.def, 
            a.mag / b.mag,
            a.magdef / b.magdef,
            a.speed / b.speed);
    }

    public override string ToString()
    {
        String format = "";

        if(hp != 0){
            format += "HP: {0}\n";
        }
        if(maxhp != 0){
            format += "MaxHP: {1}\n";
        }
        if(str != 0){
            format += "Str: {2}\n";
        }
        if(def != 0){
            format += "Def: {3}\n";
        }
        if(mag != 0){
            format += "Mag: {4}\n";
        }
        if(magdef != 0){
            format += "MagDef: {5}\n";
        }
        if(speed != 0){
            format += "Speed: {6}";
        }
        return String.Format(format, hp, maxhp, str, def, mag, magdef, speed);
    }
}
