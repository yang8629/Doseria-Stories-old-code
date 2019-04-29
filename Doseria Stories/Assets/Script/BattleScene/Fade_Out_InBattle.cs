using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_Out_InBattle : MonoBehaviour {

    public Image image_bg;
    public Image image_logo;
    public GameObject Spawning;
    public GameObject Bottom_Infomation;
    public int waittime;

    int time;
    float alpha = 1;

    void Start()
    {
        time = waittime;
        InvokeRepeating("CountDown", 1f, 1f);
    }

    void Alpha0_To_1()
    {
        if (alpha <= 1)
        {
            alpha -= Time.deltaTime * 2;
            image_bg.color= new Color(0, 0, 0, alpha);
            image_logo.color = new Color(1, 1, 1, alpha);
        }
        if (alpha < 0)
        {
            CancelInvoke("Alpha0_To_1");
            Spawning.SetActive(true);
            Bottom_Infomation.SetActive(true);
            Destroy(image_logo.gameObject);
            Destroy(image_bg.gameObject);
        }
    }

    void CountDown()
    {
        time--;
        if (time == 0)
        {
            CancelInvoke("CountDown");
            InvokeRepeating("Alpha0_To_1", 0.1f, 0.1f);
        }
    }
}
