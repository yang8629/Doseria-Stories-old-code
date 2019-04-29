using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour                                             //重攻擊
{
    public GameObject now_camera;
    public GameObject battlering;
    public GameObject top_camera;
    public GameObject cancel;
    public float offset = 0;
    public float distance;
    public Battlering battlering_set;

    SphereCollider ActionSphereCollider;

    void Awake()
    {
        ActionSphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        now_camera = battlering_set.now_camera;
        distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(now_camera.transform.position.x, 0, now_camera.transform.position.z));
        if (distance < offset)//圓形攻擊按鈕 距離攝影機offset以內的話啟動點擊  以外關閉點擊
        {
            ActionSphereCollider.enabled = true;
        }
        else
        {
            ActionSphereCollider.enabled = false;
        }
    }

    void OnMouseDown()                                                              //按下之後動作
    {
        Debug.Log("按下");
    }
}
