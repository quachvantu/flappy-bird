using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] private Sprite[] numberSprites;
    [SerializeField] private Image[] digitImages;
    private const string BEST_SCORE_KEY = "BestScore";
    private int score = 0;
    private static int bestScore = 0;
    private void Awake()
    {
        Instance = this;
        bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);

    }
    private void Start()
    {
        Bird.Instance.OnPassedPipe += Bird_OnPassedPipe;
        for (int i = 0; i < digitImages.Length; i++)
        {
            digitImages[i].gameObject.SetActive(false);
            if (i == 0)
            {
                digitImages[i].gameObject.SetActive(true);
            }
        }
    }
    private void OnDestroy()
    {
        Bird.Instance.OnPassedPipe -= Bird_OnPassedPipe;
    }
    private void Bird_OnPassedPipe(object sender, EventArgs e)
    {
        AddScore();
    }
    public void AddScore()
    {
        score++;
        string scoreString = score.ToString();
        for (int i = 0; i < scoreString.Length; i++)
        {
            digitImages[i].gameObject.SetActive(true);
            digitImages[i].sprite = numberSprites[scoreString[i] - '0'];
        }
    }
    public void ResetBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(BEST_SCORE_KEY, bestScore);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public int GetBestScore()
    {
        return bestScore;
    }
}
