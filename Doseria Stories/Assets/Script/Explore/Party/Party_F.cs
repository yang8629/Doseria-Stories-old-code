using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party_F : Tapcontroller {

    public void Change()
    {
        party.active = true;
        backpag.active = false;
        equip.active = false;
        skill.active = false;
        change = true;
    }
}
