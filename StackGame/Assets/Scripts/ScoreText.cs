using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI[] texts;
    private TextMeshProUGUI text;

    private void Start()
    {
        texts = GetComponents<TextMeshProUGUI>();
        Debug.Log("Texts Lengts: ");
        GameManager.OnCubeSpawned += GameManager_OnCubeSawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSawned;
    }

    private void GameManager_OnCubeSawned()
    {
        score++;
        text.text = "Score: " + score;
    }
}
