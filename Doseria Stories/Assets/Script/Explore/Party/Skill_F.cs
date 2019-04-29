using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_F : Tapcontroller {

    public void Change()
    {
        party.active = false;
        backpag.active = false;
        equip.active = false;
        skill.active = true;
        change = true;
    }
}
