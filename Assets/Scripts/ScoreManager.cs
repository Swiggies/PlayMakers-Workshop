using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : IGameService
{
    public int Score;

    public Action OnScoreAdded;

    public ScoreManager()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    private void ActiveSceneChanged(Scene arg0, Scene arg1)
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
        OnScoreAdded?.Invoke();
    }
}
