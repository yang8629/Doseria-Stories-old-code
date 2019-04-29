using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    public float minHorizontal;
    public float maxHorizontal;
    public float minVertical;
    public float maxVertical;

    void Update () {
        Camera_Position();
        transform.position = offset;//讓畫面跟隨玩家移動
        //transform.LookAt(player.transform.position + Vector3.up * pitch);
	}

    void Camera_Position()
    {
        //offset = player.transform.position;
        offset.z = -10;
        offset.x = Mathf.Clamp(player.transform.position.x, minHorizontal, maxHorizontal);
        offset.y = Mathf.Clamp(player.transform.position.y, minVertical, maxVertical);
    }
}
