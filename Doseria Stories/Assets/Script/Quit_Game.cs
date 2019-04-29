using UnityEngine;
using System.Collections;

public class Quit_Game : MonoBehaviour
{
    // public
    public int windowWidth;
    public int windowHight;
    public GameObject Start_Game;

    // private
    Rect windowRect;
    int windowSwitch = 0;
    float alpha = 0;

    void GUIAlphaColor_0_To_1()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }

    // Init
    void Awake()
    {
        windowRect = new Rect((Screen.width - windowWidth) / 2, (Screen.height - windowHight) / 2, windowWidth, windowHight);
    }

    public void Click()
    {
        Start_Game.SetActive(false);
        //Time.timeScale = 0;
        windowSwitch = 1;
        alpha = 0; // Init Window Alpha Color
    }

    void OnGUI()
    {
        if (windowSwitch == 1)
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, QuitWindow, "結束視窗");
        }
    }

    void QuitWindow(int windowID)
    {
        GUI.Label(new Rect(100, 50, 300, 30), "確定要離開遊戲?");

        if (GUI.Button(new Rect(40, 110, 80, 20), "Quit"))
        {
            Debug.Log("Quit_Game");
            Application.Quit();
        }
        if (GUI.Button(new Rect(180, 110, 80, 20), "Cancel"))
        {
            windowSwitch = 0;
            Start_Game.SetActive(true);
        }

        GUI.DragWindow();
    }

}
