using System;
using TMPro;
using UnityEngine;

public class ScoreManager: Singleton<ScoreManager>
{
    private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        EventBus.Subscribe(GameEvents.CAT_COLLECTED, OnCatCollected);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(GameEvents.CAT_COLLECTED, OnCatCollected);
    }

    private void OnCatCollected(object _pointToAdd)
    {
        int scoreToAdd = (int)_pointToAdd;
        score += scoreToAdd;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}