using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Object : MonoBehaviour {

    public static GameManager.Character character_type;
    public GameObject character_camera;
    public GameObject attacter;
    public GameObject this_model;
    public Animator animator;
    SetCharacterCamera setCharacterCamera;

    void Awake()
    {
        gameObject.name = character_type.Name;
        this_model = Instantiate(character_type.characterObj, transform);
        animator = this_model.GetComponent<Animator>();
        BattleInfo.characters_gameobject.Add(gameObject);
        this_model.transform.LookAt(new Vector3(0, 0, 0));
        setCharacterCamera = this_model.GetComponent<SetCharacterCamera>();
        character_camera = setCharacterCamera.character_camera;
    }

    void Switchattacter()//開關攻擊者提示
    {
        character_camera.SetActive(attacter.activeInHierarchy ? false : true);
        attacter.SetActive(attacter.activeInHierarchy ? false : true);
    }
}
