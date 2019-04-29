using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class party_background : MonoBehaviour {

    public GameObject floaing_joystick;

    private void OnEnable()
    {
        floaing_joystick.SetActive(false);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        floaing_joystick.SetActive(true);
        Time.timeScale = 1;
    }
}
