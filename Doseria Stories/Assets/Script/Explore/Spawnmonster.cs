using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmonster : MonoBehaviour {
    public List<Transform> spawnpoints;
    public GameObject monster;
    public int maxmonster;
    public float spawntime;

    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        if (Firstspawn.first == true)
        {
            Debug.Log("Spawnmonster Start");
            InvokeRepeating("FirstSpawn", spawntime, spawntime);
        }
        else
        {
            ReSpawn();
        }
    }
    
    void FirstSpawn()
    {
        int position = Random.Range(0, spawnpoints.Count);
        gameManager.monsteramount++;
        Instantiate(monster, spawnpoints[position].position, spawnpoints[position].rotation).SetActive(true);
        spawnpoints.Remove(spawnpoints[position]);
        if (gameManager.monsteramount == maxmonster)
        {
            CancelInvoke("FirstSpawn");
            Firstspawn.first = false;
        }
    }

    void ReSpawn()
    {
        int length = Firstspawn.Enemies.Count;
        Debug.Log(length);
        if (length > 0)
        {
            for (int i = 0; i < length; i++)
            {
                Debug.Log("ReSpawn " + Firstspawn.Enemies[i].enemy_name);
                Firstspawn.name_buffer = Firstspawn.Enemies[i].enemy_name;
                Instantiate(monster, Firstspawn.Enemies[i].enemy_position, Quaternion.identity).SetActive(true);
            }
        }
    }
}
