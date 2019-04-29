using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attactcontroller : MonoBehaviour
{
    public GameObject attact_character;
    public GameObject attact_target;
    public float speed ;//移動速度

    private int ENEMY;
    private float AT;
    private float firstmove;//紀錄第一次移動的距離
    public int now_character;
    private string ACTION;

    Hpcontroller hpcontroller;
    Character_Object character;

    void Awake()
    {
        hpcontroller = FindObjectOfType<Hpcontroller>();
        ACTION = Actioncontroller.action_type;
        attact_character = BattleInfo.attact_character;
        attact_target = BattleInfo.attact_target;
        gameObject.name = attact_character.name + " " + ACTION + " " + attact_target.name;
        character = attact_character.GetComponent<Character_Object>();
        for (int i = 0; i < BattleInfo.characters_gameobject.Count; i++)
        {
            if (attact_character == BattleInfo.characters_gameobject[i])
            {
                now_character = i;
                break;
            }
        }
        firstmove = Vector3.Distance(attact_character.transform.position, new Vector3(attact_target.transform.position.x, 0.5f, attact_target.transform.position.z)) * speed * 0.01f;
        Actioncontroller.battlering_active = false;
        SwitchCharacterMoving();
        character.this_model.transform.LookAt(new Vector3(attact_target.transform.position.x, 0, attact_target.transform.position.z));
        character.animator.CrossFade("AngierWalk", 0.1f);
        character.animator.SetBool("isWalking", true);
        character.animator.SetBool("isIdle", false);
        //speed = NewSpeed();
    }

    void FixedUpdate()
    {
        if (CheckTarget())
            {
            if (Getdistance() > 3)
            {
                Move();
                //speed = NewSpeed();
            }
                else
            {
                Damage();
                Resettimer();
                SwitchCharacterMoving();
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("敵人消失");
            Resettimer();
            SwitchCharacterMoving();
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
        //attact_character.transform.position = Vector3.Lerp(attact_character.transform.position, new Vector3(attact_target.transform.position.x, 0.5f, attact_target.transform.position.z), speed);
        attact_character.transform.position = Vector3.MoveTowards(attact_character.transform.position, new Vector3(attact_target.transform.position.x, 0.5f, attact_target.transform.position.z), speed);
    }

    float Getdistance()
    {
        float distance = 0;
        distance = Vector3.Distance(attact_character.transform.position, new Vector3(attact_target.transform.position.x, 0.5f, attact_target.transform.position.z));
        return distance;
    }

    bool SetTargetInfo()
    {
        for (int i = 0; i < BattleInfo.enemies_gameobject.Count; i++)
        {
            if (attact_target == BattleInfo.enemies_gameobject[i])
            {
                ENEMY = i;
                return true;
            }
        }
        return false;
    }

    bool CheckTarget()
    {
        for (int i = 0; i < BattleInfo.enemies_gameobject.Count; i++)
        {
            if (attact_target == BattleInfo.enemies_gameobject[i])
            {
                return true;
            }
        }
        return false;
    }

    void SwitchCharacterMoving()
    {
        Actioncontroller.character_moving[now_character] = Actioncontroller.character_moving[now_character] ? false : true;
    }

    void Resettimer()
    {
        Actioncontroller.character_timer[now_character] = 0;
    }

    void Damage()
    {
        character.animator.CrossFade("AngierIdle", 0.1f);
        character.animator.SetBool("isIdle", true);
        character.animator.SetBool("isWalking", false);
        //character.animator.SetBool("isAttact", true);
        //character.animator.Play("AngierIdle");
        if (SetTargetInfo())
        {
            switch (ACTION)
            {
                case "Attact":
                    //character.animator.Play("AngierAttact");
                    BattleInfo.enemies_hp[ENEMY] -= BattleInfo.characters_inbattle[now_character].AT.At * 10;
                    Debug.Log(BattleInfo.characters_inbattle[now_character].AT.At * 10);
                    break;
                case "Hattact":
                    if (EnemyActioncontroller.enemies_moving[ENEMY])
                    {
                        EnemyActioncontroller.enemies_timer[ENEMY] = 0;
                        EnemyActioncontroller.enemies_moving[ENEMY] = false;
                        Debug.Log("enemies_timer[" + ENEMY + "] 歸零");
                    }
                    else
                    {
                        EnemyActioncontroller.enemies_timer[ENEMY] -= 1;
                    }
                    BattleInfo.enemies_hp[ENEMY] -= BattleInfo.characters_inbattle[now_character].AT.At / 2 * 10;
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
        for (int i = 0; i < BattleInfo.enemies_hp.Count; i++)
        {
            Debug.Log("剩餘血量 : " + BattleInfo.enemies_inbattle[i].name + " " + BattleInfo.enemies_hp[i]);
        }
        hpcontroller.SendMessage("Death");
    }
}
