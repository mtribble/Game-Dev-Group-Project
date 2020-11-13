<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public Stats stat; 
    public List<Attack> attacks; 

    public Character (int hp, int maxhp, int str, int def, int mag, int magdef, int speed, List <Attack> attacks)
    {
        stat = new Stats(hp, maxhp, str, def, mag, magdef, speed);
        this.attacks = attacks;
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public Stats stat; 
    public List<Attack> attacks; 

    public Character (int hp, int maxhp, int str, int def, int mag, int magdef, int speed, List <Attack> attacks)
    {
        stat = new Stats(hp, maxhp, str, def, mag, magdef, speed);
        this.attacks = attacks;
    }

    public Character ()
    {
        stat = new Stats();
        this.attacks = new List<Attack>();
    }
}
>>>>>>> b2776738083d1d7d69afade37851a27604d6029c
