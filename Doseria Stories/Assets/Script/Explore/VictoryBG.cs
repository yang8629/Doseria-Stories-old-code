using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryBG : MonoBehaviour {
    public Image victoryBG;
    float i = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            victoryBG.gameObject.SetActive(true);
            Firstspawn.victory = true;
            InvokeRepeating("Show_BG", 0.1f, 0.1f);
        }
    }

    void Show_BG()
    {
        i += Time.deltaTime * 3;
        victoryBG.color = new Color(0, 0, 0, i);
        if (i > 1)
        {
            CancelInvoke("Show_BG");
            i = 1;
        }
    }
}
