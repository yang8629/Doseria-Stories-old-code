using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancel_B : MonoBehaviour {

    public GameObject top_camera;
    public GameObject battlering;

    public void canael()
    {
        top_camera.SetActive(false);
        battlering.SetActive(true);
        gameObject.SetActive(false);
    }
}
