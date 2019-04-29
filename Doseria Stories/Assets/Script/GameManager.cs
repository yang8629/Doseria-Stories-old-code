 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    #region
    [System.Serializable]
    public struct HPstaff
    {
        public float Hp;
        public float MaxHp;
        public void Set(float i)
        {
            Debug.Log("Set Hp" + i);
            Hp = i;
        }
    }
    [System.Serializable]
    public struct MPstaff
    {
        public float Mp;
        public float MaxMp;
    }
    [System.Serializable]
    public struct ATstaff
    {
        public float At;
        public float MaxAt;
    }
    [System.Serializable]
    public struct Agile
    {
        public float Ag;
    }
    [System.Serializable]
    public struct Character
    {
        public string Name;
        public GameObject characterObj;
        public HPstaff HP;
        public MPstaff MP;
        public ATstaff AT;
        public Agile AG;
    }
    #endregion

    public Character[] roles;
    public List<ICharacter> Allcharacters=new List<ICharacter>();//記錄所有角色
    public List<ICharacter> characters_inparty = new List<ICharacter>();//現在隊伍中有的角色
    
    public int monsteramount = 0;
    public GameObject spawn;
    
    void Awake()                                                            //在各個場景中唯一存在
    {
        if (instance == null)                                               //判斷是否為第一個
        {                                                                   //如果是 建立第一個
            instance = this;
            DontDestroyOnLoad(this);
            name = "GameManager";
            //Initialchar(Allcharacters, role);                                       //設定P1P2初始數值
            for (int i = 0; i < Allcharacters.Count; i++)
            {
                Addcharacter(Allcharacters[i]);
            }
            Initialchar(characters_inparty);
            //spawn.SetActive(true);
        }
        else if (this != instance)                                          //如果不是 刪掉新的
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("刪除場景 " + sceneName + " 的 " + name);
            Destroy(gameObject);
        }
    }

    public void Initialchar(List<ICharacter> icharacters)//設定角色資料
    {        
        Character role = new Character();
        if (roles.Length == 0)//第一次設定
        {
            roles = new Character[icharacters.Count];
            for (int i = 0; i < icharacters.Count; i++)
            {
                role.Name = icharacters[i].name;
                role.characterObj = icharacters[i].characterObj;
                role.HP.Hp = icharacters[i].Hp;
                role.AT.At = icharacters[i].At;
                role.AG.Ag = icharacters[i].Ag;
                roles[i] = role;
            }
        }
        else
        {
            Character[] buffer = new Character[roles.Length];
            buffer = roles;
            roles = new Character[icharacters.Count];
            Debug.Log("Reset roles");
            for (int i = 0; i < icharacters.Count; i++)
            {
                if (i <= buffer.Length)
                {
                    role.Name = buffer[i].Name;
                    role.characterObj = buffer[i].characterObj;
                    role.HP.Hp = buffer[i].HP.Hp;
                    role.AT.At = buffer[i].AT.At;
                    role.AG.Ag = buffer[i].AG.Ag;
                    roles[i] = role;
                }
                else
                {
                    role.Name = icharacters[i].name;
                    role.characterObj = icharacters[i].characterObj;
                    role.HP.Hp = icharacters[i].Hp;
                    role.AT.At = icharacters[i].At;
                    role.AG.Ag = icharacters[i].Ag;
                    roles[i] = role;
                }
            }
        }
    }

    public void SetHp()
    {
        int length=roles.Length;
        for (int i = 0; i < length; i++)
        {
            roles[i].HP.Set(BattleInfo.characters_hp[i]);
        }
    }

    public void Addcharacter(ICharacter character)
    {
        characters_inparty.Add(character);
        Debug.Log("Add " + character.name);
    }

    public void Removecharacter(ICharacter character)
    {
        characters_inparty.Remove(character);
    }

    public void BacktoExplore()
    {
        BattleInfo.Reset();
        SceneManager.LoadScene("Explore");
    }

    public void BacktoTitle()
    {
        Firstspawn.Reset();
        BattleInfo.Reset();
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    public void GotoExplore()
    {
        Debug.Log("LoadScene(Explore");
        SceneManager.LoadScene("Explore");
    }
}