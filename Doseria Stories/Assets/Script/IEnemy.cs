using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character",menuName = "Characters/Enemy")]
public class IEnemy : ScriptableObject{

    public new string name;
    public GameObject enemyObj;
    public float Hp;
    public float Def;
    public float At;
    public float Ag;
}
