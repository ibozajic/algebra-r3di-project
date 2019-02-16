using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static int score = 0;
    public static int level = 1;
    public Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        GameManager.OnCubeSpawned += GameManager_OnCubeSawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSawned;
    }

    private void GameManager_OnCubeSawned()
    {
        score++;

        if(score > 0 && (score % 10) == 0)
        {
            level++;     
        }

        text.text = "Score: " + score + " | Level: " + level;
    }
}
