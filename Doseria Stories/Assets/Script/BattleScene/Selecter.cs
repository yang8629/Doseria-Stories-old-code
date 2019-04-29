using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter : MonoBehaviour {

    public GameObject enemy;
    public GameObject top_camera;
    public GameObject cancel_button;
    public GameObject attactcontroller;
    
    void OnMouseDown()
    {
        top_camera.SetActive(false);
        cancel_button.SetActive(false);
        BattleInfo.attact_target = enemy;
        for (int i = 0; i < BattleInfo.enemies_gameobject.Count; i++)
        {
            BattleInfo.enemies_gameobject[i].SendMessage("Switchselecter");
        }
        enemy.SendMessage("SetAttactTargetInfo");
        Instantiate(attactcontroller).SetActive(true);
        BattleInfo.attact_character.SendMessage("Switchattacter");
        Time.timeScale = 1;
    }
}
