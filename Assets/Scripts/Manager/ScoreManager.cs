using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] private Sprite[] numberSprites;
    [SerializeField] private Image[] digitImages;

    private int score = 0;
    private static int bestScore = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < digitImages.Length; i++)
        {
            digitImages[i].gameObject.SetActive(false);
            if (i == 0)
            {
                digitImages[i].gameObject.SetActive(true);
            }
        }
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
