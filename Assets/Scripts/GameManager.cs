using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Enemie;
    public static GameManager gM;

    public int maxenemies = 2;
    public int currentEnemies = 0;
    public float gameTime;
    public int limitTime;
    public GameObject endGame;
    public GameObject scoreTable;

    public int score;

    public TextMeshProUGUI textscore;
    public TextMeshProUGUI times;
    public TMP_InputField aliass;



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
            scoreTable.SetActive(true);
        }

        times.text = Mathf.RoundToInt(gameTime) + " / " + limitTime;

        textscore.text = "Score: " + score.ToString();
    }

    void CreateEnemie()
    {
        Vector3 enemipos = new Vector3(Random.Range(-45, 45), 1, Random.Range(-45, 45));
        Instantiate(Enemie, enemipos, Quaternion.identity);
        currentEnemies++;

    }

    public void buttonalias()
    {
        if (aliass.text != null)
        {
            HighScore.highScore.aka.Add(aliass.text);
            HighScore.highScore.puntos[0] = score.ToString();
            SceneManager.LoadScene("ScoreTable");
        }

    }


}
