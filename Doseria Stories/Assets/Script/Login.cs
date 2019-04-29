using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public GameObject quit_game;
    public GameObject start_chat;
    public GameObject title_word;
    public Image title_logo;
    public Image image;
    public float alpha = 0;
    public bool first = true;
    public void Awake()
    {
        Debug.Log("Login Awake");
        image = GetComponent<Image>();
    }
    public void Start_Title()
    {
        InvokeRepeating("alpha_0to1", 0.1f, 0.1f);
    }
    void alpha_0to1()
    {
        alpha += Time.deltaTime * 2;
        //if (first)
        //{
        //    image.color = new Color(1, 1, 1, alpha);
        //    if (alpha > 1)
        //    {
        //        first = false;
        //        alpha = 0;
        //    }
        //}
        //else
        //{
            title_logo.color = new Color(1, 1, 1, alpha);
            if (alpha > 1)
            {
                first = true;
                alpha = 0;
                start_chat.SetActive(true);
                quit_game.SetActive(true);
                CancelInvoke("alpha_0to1");
                enabled = false;
            }
        //}
    }
}
