using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionbar : MonoBehaviour {

    public GameObject ActionbarP1;
    public GameObject ActionbarP2;
    public GameObject ActionbarE1;
    public GameObject ActionbarE2;

    void Awake()
    {
        ActionbarP1.SetActive(true);
        ActionbarP2.SetActive(true);
        ActionbarE1.SetActive(true);
        ActionbarE2.SetActive(true);
    }

    void FixedUpdate () {
        ActionbarP1.transform.localPosition = new Vector3(-250 + 400 * (Actioncontroller.character_timer[0] / 5), 0.0f, 0.0f);
        ActionbarP2.transform.localPosition = new Vector3(-250 + 400 * (Actioncontroller.character_timer[1] / 5), 0.0f, 0.0f);
        ActionbarE1.transform.localPosition = new Vector3(-250 + 400 * (EnemyActioncontroller.enemies_timer[0] / 5), 0.0f, 0.0f);
        ActionbarE2.transform.localPosition = new Vector3(-250 + 400 * (EnemyActioncontroller.enemies_timer[1] / 5), 0.0f, 0.0f);
    }
}
