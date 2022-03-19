using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{

    public TextMeshProUGUI nombres;
    public TextMeshProUGUI puntajes;

    public string loquesea;

    void Start()
    {
        for (int i = 0; i < HighScore.highScore.aka.Count; i++)
        {
            nombres.text += HighScore.highScore.aka[i];
        }

        for (int i = 0; i < HighScore.highScore.puntos.Length; i++)
        {
            puntajes.text += HighScore.highScore.puntos[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
