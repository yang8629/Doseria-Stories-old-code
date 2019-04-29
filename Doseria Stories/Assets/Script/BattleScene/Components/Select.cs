using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{

    public GameObject Topcamera;
    public GameObject attacter1;
    public GameObject attacter2;
    
    void OnMouseDown()                                                              //按下之後動作
    {                                                                               //關掉空中攝影機、敵人選擇
        //Debug.Log(transform.position);                                            //開啟戰鬥環、時間繼續
        Topcamera.SetActive(false);
        attacter1.SetActive(false);
        attacter2.SetActive(false);
        Actioncontroller.battlering_active = false;
        Time.timeScale = 1;
    }
}
