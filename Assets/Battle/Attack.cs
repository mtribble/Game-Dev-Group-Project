using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    //Type false for physical, true for magic
     public bool type; public int power;

    public Attack(bool type, int power)
    {
        this.type = type;
        this.power = power;
    }
}
