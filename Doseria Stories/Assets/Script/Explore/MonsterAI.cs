using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAI : MonoBehaviour {

    public GameObject player;
    public float speed = 0;
    public float tracedistance;
    public string gototheScene;
    public bool touch;

    public int number;

    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        number = gameManager.monsteramount;
        if (Firstspawn.first)
        {
            gameObject.name = ("Monster" + number);
        }
        else
        {
            gameObject.name = Firstspawn.name_buffer;
        }
    }

    void FixedUpdate () {
        if (Getdistance() <= tracedistance)
        {
            Traceplayer();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Firstspawn.victory)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                touch = true;
                SceneManager.LoadScene(gototheScene);
            }
        }
    }

    void OnDestroy()
    {
        if (!touch)
        {
            Debug.Log("Save project " + gameObject.name);
            Firstspawn.Set(gameObject.name, gameObject.transform.position);
        }
        else
        {
            Debug.Log(gameObject.name +" Destroy by player");
            Firstspawn.Remove(gameObject.name);
        }
    }

    float Getdistance()
    {
        float distance = 0;
        distance = Vector3.Distance(transform.position, player.transform.position);
        return distance;
    }

    void Traceplayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0), speed);
        //transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), speed);
        //speed = Newspeed();
    }
}
