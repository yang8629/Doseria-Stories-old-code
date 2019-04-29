using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//紀錄探索畫面敵人的位置&資料
public class Firstspawn{

    public static bool first = true;
    public static string name_buffer;
    public static Vector3 player_position;
    public static bool victory = false;

    public struct enemy
    {
        public string enemy_name;
        public Vector3 enemy_position;       
    }

    public static List<enemy> Enemies =new List<enemy>();

    public static void Showenemy()
    {
        int length = Enemies.Count;
        for (int i = 0; i < length; i++)
        {
            Debug.Log(Enemies[i].enemy_name);
        }
    }

    public static void Set(string name, Vector3 position)
    {
        enemy buffer;
        buffer.enemy_name = name;
        Debug.Log("Set " + buffer.enemy_name);
        buffer.enemy_position = position;
        Enemies.Add(buffer);
    }

    public static void Remove(string name)
    {
        int length = Enemies.Count;
        for (int i = 0; i < length; i++)
        {
            if (name == Enemies[i].enemy_name)
            {
                Debug.Log("刪除Enemys:" + Enemies[i].enemy_name);
                Enemies.Remove(Enemies[i]);
                return;
            }
        }
        Debug.Log("ERROR");
    }

    public static void Reset()
    {
        first = true;
    }
}
