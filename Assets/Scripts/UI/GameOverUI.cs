using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statsTextMesh;
    [SerializeField] private Button button;
    [SerializeField] private GameObject scoreUI;
    private void Awake()
    {
        Bird.Instance.OnBirdDied += GameOverUI_OnBirdDied;
        button.onClick.AddListener(() =>
        {
        });
    }
    private void Start()
    {
        Debug.Log("Start");
        Hide();
    }
    private void GameOverUI_OnBirdDied(object sender, EventArgs e)
    {
        ScoreManager.Instance.ResetBestScore();
        statsTextMesh.text = ScoreManager.Instance.GetScore().ToString() + "\n" + ScoreManager.Instance.GetBestScore().ToString();
        scoreUI.SetActive(false);
        Show();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
