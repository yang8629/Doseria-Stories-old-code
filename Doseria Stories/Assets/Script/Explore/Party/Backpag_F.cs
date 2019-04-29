using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpag_F : Tapcontroller {

    public void Change()
    {
        party.active = false;
        backpag.active = true;
        equip.active = false;
        skill.active = false;
        change = true;
    }
}
