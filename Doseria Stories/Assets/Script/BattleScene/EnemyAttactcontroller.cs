using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//往目標移動
//攻擊
public class EnemyAttactcontroller : MonoBehaviour
{
    public GameObject attact_enemy;
    public GameObject attact_target;
    public float speed = 0.01f;//移動速度

    private float AT;
    private float firstmove;//紀錄第一次移動的距離
    private int now_enemy;
    private int now_target;
    private string now_action;

    Hpcontroller hpcontroller;

    void Awake()
    {
        attact_enemy = EnemyActioncontroller.attact_enemy;//當前攻擊的敵人
        for (int i = 0; i < BattleInfo.enemies_gameobject.Count; i++)
        {
            if (attact_enemy == BattleInfo.enemies_gameobject[i])
            {
                now_enemy = i;
                break;
            }
        }
                SwitchEnemyMoving();
        hpcontroller=FindObjectOfType<Hpcontroller>();
        now_action = EnemyActioncontroller.attact_type;
        attact_target = EnemyActioncontroller.attact_target;//當前攻擊的目標
        for (int i = 0; i < BattleInfo.characters_inbattle.Count; i++)
        {
            if (attact_target.name == BattleInfo.characters_inbattle[i].Name)
            {
                now_target = i;
                Debug.Log("now_target:" + i);
                break;
            }
        }
        firstmove = Vector3.Distance(attact_enemy.transform.position, new Vector3(attact_target.transform.position.x, 1, attact_target.transform.position.z)) * speed * 0.01f;
        speed = speed * 0.01f;
        gameObject.name = attact_enemy.name + " " + now_action + " " + attact_target.name;
    }

    void FixedUpdate()
    {
        if (CheckTarget())
            {
            if (Getdistance() >= 3)
            {
                Move();
                speed = NewSpeed();
            }
            else
            {
                Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private float NewSpeed()
    {
        float distance = Getdistance();                                              //取得 player 和 enemy 的距離 
        if (distance <= 3)                                                           //當距離為0的時候，就代表已經移動到目的地了
            return distance = 0;
        else
            return (firstmove / distance);
    }

    void Move()
    {
        attact_enemy.transform.position = Vector3.Lerp(attact_enemy.transform.position, new Vector3(attact_target.transform.position.x, 1, attact_target.transform.position.z), speed);
    }

    float Getdistance()
    {
        float distance = 0;
        distance = Vector3.Distance(attact_enemy.transform.position, new Vector3(attact_target.transform.position.x, 1, attact_target.transform.position.z));
        return distance;
    }

    void SwitchEnemyMoving()
    {
        EnemyActioncontroller.enemies_moving[now_enemy] = EnemyActioncontroller.enemies_moving[now_enemy] ? false : true;
    }

    void Resettimer()
    {
        EnemyActioncontroller.enemies_timer[now_enemy] = 0;
    }

    void Damage()
    {
        if (CheckTarget())
        {
            switch (now_action)
            {
                case "Attact":
                    BattleInfo.characters_hp[now_target] -= BattleInfo.enemies_inbattle[now_enemy].At * 10;
                    break;
                case "Hattact":
                    //if (EnemyActioncontroller.enemies_moving[enemy])
                    //{
                    //    EnemyActioncontroller.enemies_timer[enemy] = 0;
                    //    EnemyActioncontroller.enemies_moving[enemy] = false;
                    //    Debug.Log("enemies_timer[" + enemy + "] 歸零");
                    //}
                    //BattleInfo.characters_inbattle[now_target].Hp -= BattleInfo.characters_inbattle[now_enemy].At * 10;
                    break;
                default:
                    Debug.Log("error5");
                    break;
            }
        }
        else
        {
            Debug.Log("找不到目標");
        }
        for (int i = 0; i < BattleInfo.characters_inbattle.Count; i++)
        {
            Debug.Log("剩餘血量 : " + BattleInfo.characters_inbattle[i].Name + " " + BattleInfo.characters_hp[i]);
        }
        Resettimer();
        SwitchEnemyMoving();
        hpcontroller.SendMessage("Death");
    }

    bool CheckTarget()
    {
        for (int i = 0; i < BattleInfo.characters_gameobject.Count; i++)
        {
            if (attact_target == BattleInfo.characters_gameobject[i])
            {
                return true;
            }
        }
        return false;
    }
}
