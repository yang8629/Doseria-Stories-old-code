using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour {

    public GameObject hp_p1;
    public GameObject hp_p2;

	void FixedUpdate () {
        if (BattleInfo.characters_hp[0] >= 0)
        {
            hp_p1.gameObject.transform.localPosition = new Vector3((-160 + 106 * BattleInfo.characters_hp[0] / 100), 0, 0);
        }
        if (BattleInfo.characters_hp[1] >= 0)
        {
            hp_p2.gameObject.transform.localPosition = new Vector3((-160 + 106 * BattleInfo.characters_hp[1] / 100), 0, 0);
        }
    }
}
