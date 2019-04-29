using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_F : Tapcontroller {

    public void Change()
    {
        party.active = false;
        backpag.active = false;
        equip.active = true;
        skill.active = false;
        change = true;
    }
}
