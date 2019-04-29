using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    
    public float alpha = 1;
    Login login;
    public void Awake()
    {
        Debug.Log("Login Awake");
        login = GetComponent<Login>();
    }
    public void Start()
    {
        InvokeRepeating("countdown", 0.1f, 0.1f);
    }
    void countdown()
    {
        alpha -= Time.deltaTime;
        Debug.Log(alpha);
        if (alpha < 0)
        {
            alpha = 1;
            login.enabled = true;
            CancelInvoke("countdown");
        }
    }
    public void GotoTalk()
    {
        SceneManager.LoadScene("Talk");
    }
}
