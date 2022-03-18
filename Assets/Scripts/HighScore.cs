using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScore : MonoBehaviour
{
    public static HighScore highScore;

    public List<string> aka;
    public string[] scorehigh;


    void Awake()
    {
        
        if (highScore == null)
        {
            highScore = this;
            DontDestroyOnLoad(highScore);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
}
