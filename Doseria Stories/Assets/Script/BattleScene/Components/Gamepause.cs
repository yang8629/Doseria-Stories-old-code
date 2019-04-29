using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamepause : MonoBehaviour {

    public GameObject pause_background;
    bool pause = false;
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause = true;
        }
        pause_background.SetActive(true);
    }

    public void Resume()
    {
        if (pause)
        {
            Time.timeScale = 1;
        }
        pause_background.SetActive(false);
    }
}
