using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//遊戲初始生成敵人與玩家角色
public class BattleSceneSpawning : MonoBehaviour {

    public List<IEnemy> Allenemies = new List<IEnemy>();
    public List<IEnemy> spawnenemy = new List<IEnemy>();
    public List<Transform> Allspawnpoint = new List<Transform>();
    public GameObject hpcontroller;
    public GameObject enemy_gameobject;
    public GameObject character_gameobject;
    public int enemies_inbattleamount;

    GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        foreach (Transform child in transform)//取得所有生成點
        {
            Allspawnpoint.Add(child.transform);
        }
        Spawncharacter();
        for (int i = 0; i < enemies_inbattleamount; i++)//生成敵人
        {
            Spawnenemy();
        }
        hpcontroller.SetActive(true);
    }

    void Spawnenemy()//生成敵人
    {
        int eneytype = Random.Range(0, Allenemies.Count);//隨機敵人種類
        int spawnpoint = Random.Range(0, Allspawnpoint.Count);//隨機生成點
        Debug.Log("召喚敵人" + Allenemies[eneytype].name);
        Enemy_Object.enemy_type = Allenemies[eneytype];//將敵人資訊丟入敵人中
        spawnenemy.Add(Allenemies[eneytype]);
        Vector3 position = new Vector3(Allspawnpoint[spawnpoint].position.x, 1, Allspawnpoint[spawnpoint].position.z);
        Instantiate(enemy_gameobject, position, Quaternion.identity).SetActive(true);//生成敵人
        Allspawnpoint.Remove(Allspawnpoint[spawnpoint]);//將用過的生成點刪掉
    }

    void Spawncharacter()//生成角色
    {
        int spawnpoint;
        int length = gameManager.roles.Length;//取得隊伍中人數
        for (int i = 0; i < length; i++)//將隊伍中角色設定進 BattleInfo.characters_inbattle
        {
            spawnpoint = Random.Range(0, Allspawnpoint.Count);//隨機生成點
            BattleInfo.characters_inbattle.Add(gameManager.roles[i]);
            Character_Object.character_type = gameManager.roles[i];//將角色資訊丟入角色中
            Instantiate(character_gameobject, Allspawnpoint[spawnpoint].position, Quaternion.identity).SetActive(true);//生成角色
            Debug.Log("召喚角色" + BattleInfo.characters_inbattle[i].Name);
            Allspawnpoint.Remove(Allspawnpoint[spawnpoint]);//將用過的生成點刪掉
        }
    }
}
