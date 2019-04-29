using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapcontroller : MonoBehaviour {

    [System.Serializable]
    public struct Tap
    {
        public bool active;
        public GameObject T;
        public GameObject F;
        public GameObject content;
    }

    public Tap party, backpag, equip, skill;
    public bool change = false;

    void Awake()
    {
        party.active = true;
        backpag.active = false;
        equip.active = false;
        skill.active = false;
    }

    void Update()
    {
        if (change == true)
        {
            SetAllActive();
            change = false;
        }
    }

    public void Setactive(Tap buffer)
    {
        buffer.T.SetActive(buffer.active);
        buffer.content.SetActive(buffer.active);
    }

    public void SetAllActive()
    {
            Debug.Log("SetAllActive");
            Setactive(party);
            Setactive(backpag);
            Setactive(equip);
            Setactive(skill);
    }  
}
