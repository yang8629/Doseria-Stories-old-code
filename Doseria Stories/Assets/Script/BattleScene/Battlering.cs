using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlering : MonoBehaviour {

    public float speed = 0.01f;
    public float first_angle;
    public float now_rotate;
    public float buffer;
    public GameObject button; //五個按鈕
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject now_camera;
    public static bool iscancel = false;

    private float distance = 6;                                                            //滑鼠點擊距離
    private Vector3 firstPosition;
    private Vector3 dragPosition;
    Character_Object character;

    void OnEnable()
    {
        character = BattleInfo.attact_character.GetComponent<Character_Object>();
        now_camera = character.character_camera;
        Vector3 position = character.character_camera.transform.position;
        Vector3 rotat = character.character_camera.transform.rotation.eulerAngles;
        position.y += 0.4f;
        position.z += 7;
        transform.position = position;
        //transform.LookAt(character.character_camera.transform.position);
        transform.RotateAround(character.character_camera.transform.position, Vector3.up, rotat.y);
        first_angle = transform.rotation.eulerAngles.y;
    }

    void OnDisable()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        button.transform.rotation = new Quaternion(0, 0, 0, 0);
        button1.transform.rotation = new Quaternion(0, 0, 0, 0);
        button2.transform.rotation = new Quaternion(0, 0, 0, 0);
        button3.transform.rotation = new Quaternion(0, 0, 0, 0);
        button4.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void OnMouseDown()                                                                      //滑鼠按下 設定初始位置
    {
        Vector3 mouse = Input.mousePosition;
        firstPosition = mouse;
    }

    void OnMouseDrag()                                                                      //根據拖曳距離方向 旋轉圓環
    {
        Vector3 mouse = Input.mousePosition;
        float angle = 0.0f;
        mouse.z = distance;
        dragPosition = mouse;
        angle = dragPosition.x - firstPosition.x;

        transform.Rotate(0, -angle * speed, 0);
        button.transform.Rotate(0, angle * speed, 0);//旋轉每個按鈕 持續正面朝向鏡頭
        button1.transform.Rotate(0, angle * speed, 0);
        button2.transform.Rotate(0, angle * speed, 0);
        button3.transform.Rotate(0, angle * speed, 0);
        button4.transform.Rotate(0, angle * speed, 0);        
    }

    private void OnMouseUp()
    {
        now_rotate = transform.rotation.eulerAngles.y;
        if (now_rotate >= 180)
        {
            now_rotate -= 360;
        }
        buffer = first_angle - now_rotate;
        if (buffer > 360)
        {
            buffer -= 360;
        }
        else if (buffer < 0)
        {
            buffer += 360;
        }
        if (buffer > 0 && buffer < 72)
        {
            Rotate();
        }
        else if (buffer > 72 && buffer < 144)
        {
            buffer -= 72;
            Rotate();
        }
        else if (buffer > 144 && buffer < 216)
        {
            buffer -= 144;
            Rotate();
        }
        else if (buffer > 216 && buffer < 288)
        {
            buffer -= 216;
            Rotate();
        }
        else if (buffer > 288 && buffer < 360)
        {
            buffer -= 288;
            Rotate();
        }        
    }

    void Rotate()
    {
        if (buffer < 36)
        {
            Min_Rotate();
        }
        else if (buffer > 36)
        {
            buffer = 72 - buffer;
            Max_Rotate();
        }
    }

    void Min_Rotate()
    {
        transform.Rotate(0, buffer, 0);
        button.transform.Rotate(0, -buffer, 0);//旋轉每個按鈕 持續正面朝向鏡頭
        button1.transform.Rotate(0, -buffer, 0);
        button2.transform.Rotate(0, -buffer, 0);
        button3.transform.Rotate(0, -buffer, 0);
        button4.transform.Rotate(0, -buffer, 0);
    }

    void Max_Rotate()
    {
        transform.Rotate(0, -buffer, 0);
        button.transform.Rotate(0, buffer, 0);//旋轉每個按鈕 持續正面朝向鏡頭
        button1.transform.Rotate(0, buffer, 0);
        button2.transform.Rotate(0, buffer, 0);
        button3.transform.Rotate(0, buffer, 0);
        button4.transform.Rotate(0, buffer, 0);
    }

    public void InCancel()
    {
        iscancel = true;
    }
}
