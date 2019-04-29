using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpcontroller : MonoBehaviour {

    public GameObject actioncontroller;
    public GameObject enemyspawn;
    public GameObject victory_background;
    
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyspawn.SetActive(true);
    }

    void Start()
    {
        SetCharactersHp();
        SetEnemiesHp();
        actioncontroller.SetActive(true);
    }

    void SetCharactersHp()
    {
        int length = gameManager.roles.Length;
        for (int i = 0; i < length; i++)
        {
            BattleInfo.characters_hp.Add(gameManager.roles[i].HP.Hp);
        }
    }

    void SetEnemiesHp()
    {
        int length = BattleInfo.enemies_inbattle.Count;
        for (int i = 0; i < length; i++)
        {
            BattleInfo.enemies_hp.Add(BattleInfo.enemies_inbattle[i].Hp);
        }
    }

    void Victory()
    {
        //bool victory = true;
        //for (int i = 0; i < BattleInfo.enemies_inbattle.Count; i++)
        //{
        //    if (BattleInfo.enemies_inbattle[i].Hp > 0)
        //    {
        //        victory = false;
        //        break;
        //    }
        //}
        //if (victory)
        //{
        //    int length = gameManager.characters_inparty.Count;
        //    for (int i = 0; i < length; i++)
        //    {
        //        gameManager.characters_inparty[i] = BattleInfo.characters_inbattle[i];
        //    }
        //    gameManager.BacktoExplore();
        //}
        if (BattleInfo.enemies_gameobject.Count == 0 || BattleInfo.characters_gameobject.Count == 0)
        {
            BattleInfo.inbattle = false;
            for (int i = 0; i < BattleInfo.characters_hp.Count; i++)
            {
                gameManager.roles[i].HP.Set(BattleInfo.characters_hp[i]);
            }
            victory_background.SetActive(true);
        }
    }

    public void Death()
    {
        for (int i = 0; i < BattleInfo.enemies_hp.Count; i++)
        {
            if (BattleInfo.enemies_hp[i] <= 0)
            {
                Destroy(BattleInfo.enemies_gameobject[i]);
                Debug.Log(BattleInfo.enemies_inbattle[i].name + " 死亡");
                BattleInfo.enemies_inbattle.Remove(BattleInfo.enemies_inbattle[i]);
                BattleInfo.enemies_gameobject.Remove(BattleInfo.enemies_gameobject[i]);
                BattleInfo.enemies_hp.Remove(BattleInfo.enemies_hp[i]);
            }
        }
        for (int i = 0; i < BattleInfo.characters_hp.Count; i++)
        {
            if (BattleInfo.characters_hp[i] <= 0)
            {
                for (int j = 0; j < BattleInfo.characters_gameobject.Count; j++)
                {
                    if (BattleInfo.characters_inbattle[i].Name == BattleInfo.characters_gameobject[j].name)
                    {
                        Destroy(BattleInfo.characters_gameobject[j]);
                        Debug.Log(BattleInfo.characters_gameobject[j].name + " 死亡");
                        Actioncontroller.character_dead[i] = true;
                        BattleInfo.characters_gameobject.Remove(BattleInfo.characters_gameobject[j]);
                        break;
                    }
                }
                //BattleInfo.characters_inbattle.Remove(BattleInfo.characters_inbattle[i]);
                //BattleInfo.characters_hp.Remove(BattleInfo.characters_hp[i]);
                //for (int j = 0; j < gameManager.roles.Count; j++)
                //{
                //    if (BattleInfo.characters_inbattle[i].Name == gameManager.roles[i].Name)
                //    {
                //        gameManager.roles[j].HP.Set(0);
                //        break;
                //    }
                //}
            }
        }
        Victory();
    }

    public void Back()
    {
        gameManager.BacktoExplore();
    }
}
