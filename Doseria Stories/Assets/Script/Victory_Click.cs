using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory_Click : MonoBehaviour {
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Game_Over()
    {
        gameManager.BacktoTitle();
    }
}
