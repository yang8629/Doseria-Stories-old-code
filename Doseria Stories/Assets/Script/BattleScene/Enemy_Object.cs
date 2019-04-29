using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Object : MonoBehaviour {

    public static IEnemy enemy_type;
    public GameObject selecter;
    public GameObject this_model;
    public Animator animator;

    IEnemy enemy_this;

    void Awake () {
        enemy_this = enemy_type;
        gameObject.name = enemy_this.name;//命名敵人
        this_model = Instantiate(enemy_type.enemyObj, transform);
        animator = this_model.GetComponent<Animator>();
        this_model.transform.LookAt(new Vector3(0, 0, 0));
        BattleInfo.enemies_gameobject.Add(gameObject);//將此物件加到 BattleInfo.enemies_gameobject
        BattleInfo.enemies_inbattle.Add(enemy_type);//將敵人資訊丟入 BattleInfo.enemies_inbattle
    }
	
    public void SetAttactTargetInfo()
    {
        BattleInfo.attact_targetinfo = enemy_this;
        Debug.Log("SetEnemyType " + enemy_type.name);
    }

    public void Switchselecter()//開關供玩家選擇攻擊對象的物件 可點擊
    {
        selecter.SetActive(selecter.activeInHierarchy ? false : true);
    }
}
