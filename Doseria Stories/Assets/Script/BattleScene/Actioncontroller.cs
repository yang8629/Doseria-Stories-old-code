using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//角色行動的計算
//紀錄攻擊的方式與當前行動者
public class Actioncontroller : MonoBehaviour {

    public Camera maincamera;//主攝影機
    public GameObject battlering;//戰鬥環
    public GameObject attactcontroller;//攻擊物件
    public GameObject attact_character;//當前攻擊角色
    public static float[] character_timer;//角色行動值
    public static bool[] character_moving;//角色是否在移動
    public static bool battlering_active = false;//戰鬥環是否啟動，防止兩個角色同時跑完條鏡頭跳到後者
    public static string action_type;//當前攻擊方式
    public static bool[] character_dead;//角色是否在移動

    private float[] player_Ag ;//角色靈敏值系數
    private int length;
    Actionbar actionbar;
    Character_Object character;

    void Awake() {
        actionbar = GetComponent<Actionbar>();
        SetValue();
    }
    private void Start()
    {
        actionbar.enabled = true;
    }

    void FixedUpdate () {
        Timer();
        Activebattlering();
	}

    void Timer()//行動值計算
    {
        if (BattleInfo.inbattle)
        {
            for (int i = 0; i < length; i++)
            {
                if (character_moving[i] == false && character_dead[i] == false)
                {
                    character_timer[i] += Time.deltaTime * player_Ag[i];
                }
            }
        }
    }
    
    void Activebattlering()//判斷是否能行動
    {
        for (int i = 0; i < length; i++)
        {
            if ( character_timer[i] > 5 && battlering_active == false && character_moving[i] == false)
            {
                Time.timeScale = 0;//選擇行動時時間暫停
                attact_character = BattleInfo.characters_gameobject[i];
                character = attact_character.GetComponent<Character_Object>();
                //maincamera.transform.position = (BattleInfo.characters_gameobject[i].transform.position + Vector3.up) + new Vector3(0, 0.5f, -1.5f);
                //maincamera.transform.LookAt(new Vector3(0, 0, 0) + Vector3.up);
                BattleInfo.attact_character = attact_character;
                battlering.SetActive(true);
                battlering_active = true;
                character.SendMessage("Switchattacter");//打開攻擊者頭上提示
                //battlering.SetActive(true);
            }
        }
    }

    void SetValue()
    {
        length = BattleInfo.characters_inbattle.Count;
        Debug.Log("Actioncontroller SetValue " + length);
        player_Ag = new float[length];
        character_timer = new float[length];
        character_moving = new bool[length];
        character_dead = new bool[length];
        for (int i = 0; i < length; i++)
        {
            player_Ag[i] = BattleInfo.characters_inbattle[i].AG.Ag;
            character_dead[i] = false;
        }
    }


    public void Attacking()//生成攻擊移動的物件
    {
        Instantiate(attactcontroller).SetActive(true);
    }
}
