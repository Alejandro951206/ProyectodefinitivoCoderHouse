using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject Enemie;
    public static GameController gM;

    public int maxenemies = 2;
    public int currentEnemies = 0;
    public float gameTime;
    public int limitTime;
    public GameObject endGame;

    public TextMeshProUGUI times;

    // Start is called before the first frame update
    void Start()
    {
        gM = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies < maxenemies)
        {
            CreateEnemie();
        }

        gameTime += Time.deltaTime;
        if (gameTime > limitTime)
        {
            endGame.SetActive(true);
        }

        times.text = Mathf.RoundToInt (gameTime) + " / "+limitTime;
    }

    void CreateEnemie()
    {
        Vector3 enemipos = new Vector3(Random.Range(-45,45),1,Random.Range(-45,45));
        Instantiate(Enemie, enemipos, Quaternion.identity);
        currentEnemies++;

    }
}
