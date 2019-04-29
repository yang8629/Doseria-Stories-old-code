using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//敵人行動的計算
//隨機做出 行動 選擇敵人
public class EnemyActioncontroller : MonoBehaviour {

    public GameObject enemyattactcontroller;
    public float[] enemies_Ag;
    public static float[] enemies_timer;
    public static bool[] enemies_moving;
    public static string attact_type;
    public static GameObject attact_enemy;
    public static GameObject attact_target;

    private int length;

    void Start()
    {
        SetValue();
    }

    void FixedUpdate()
    {
        Timer();
        Action();
    }
    
    void Action()
    {
        for (int i = 0; i < length; i++)
        {
            if (enemies_timer[i] > 5 && !enemies_moving[i])                                                             //e1攻擊
            {
                attact_enemy = BattleInfo.enemies_gameobject[i];
                SetRandomTarget();
                Attacting();
                Debug.Log("Call Action");
            }
        }        
    }

    void SetValue()
    {
        length = BattleInfo.enemies_inbattle.Count;
        enemies_moving = new bool[length];
        enemies_timer = new float[length];
        enemies_Ag = new float[length];
        for (int i = 0; i < length; i++)
        {
            enemies_moving[i] = false;
            enemies_timer[i] = 0;
            enemies_Ag[i] = BattleInfo.enemies_inbattle[i].Ag;
        }
    }

    void Timer()
    {
        length = BattleInfo.enemies_inbattle.Count;
        for (int i = 0; i < length; i++)
        {
            if (enemies_timer[i] < 5)
            {
                enemies_timer[i] += Time.deltaTime * enemies_Ag[i];
            }
        }
    }

    void SetRandomTarget()
    {
        attact_target = BattleInfo.characters_gameobject[Random.Range(0, BattleInfo.characters_gameobject.Count)];
        attact_type = "Attact";
    }

    void Attacting()
    {
        Instantiate(enemyattactcontroller).SetActive(true);
    }
}
