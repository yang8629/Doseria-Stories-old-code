using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//紀錄戰鬥畫面中的資訊
//紀錄血量
public class BattleInfo {
    public static bool inbattle = true;
    public static List<IEnemy> enemies_inbattle =new List<IEnemy>();//敵人資訊
    public static List<GameObject> enemies_gameobject = new List<GameObject>();//敵人物件
    public static List<GameManager.Character> characters_inbattle = new List<GameManager.Character>();//角色資訊
    public static List<GameObject> characters_gameobject = new List<GameObject>();//角色物件

    public static List<float> enemies_hp = new List<float>();//敵人血量
    public static List<float> characters_hp = new List<float>();//角色血量

    public static GameObject attact_target;//以玩家視角攻擊對象
    public static IEnemy attact_targetinfo;
    public static GameObject attact_character;

    public static void Reset()//Reset BattleInfo
    {
        inbattle = true;
        enemies_hp.Clear();
        characters_hp.Clear();
        enemies_inbattle.Clear();
        enemies_gameobject.Clear();
        characters_inbattle.Clear();
        characters_gameobject.Clear();
        Actioncontroller.character_timer = null;
        Actioncontroller.character_moving = null;
        Actioncontroller.battlering_active = false;
        EnemyActioncontroller.enemies_moving = null;
        EnemyActioncontroller.enemies_timer = null;
    }
}
