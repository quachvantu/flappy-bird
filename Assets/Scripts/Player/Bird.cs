using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }
    public static bool isAlive = true;
    public event EventHandler OnBirdDied;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (!isAlive)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), 5f * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (isAlive)
        {
            isAlive = false;
        }
        OnBirdDied?.Invoke(this, EventArgs.Empty);
    }
    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        ScoreManager.Instance.AddScore();
    }
}
