using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private State state;
    [SerializeField] private GameObject StartScreenUI;
    [SerializeField] private Animator animator;
    public enum State
    {
        WaitingToStart,
        Playing,
        GameOver
    }
    private void Start()
    {
        Bird.Instance.OnBirdDied += GameManager_OnBirdDied;
        state = State.WaitingToStart;
        HandleState();
    }
    private void Awake()
    {
        Instance = this;

    }
    private void Update()
    {
        if (state == State.WaitingToStart)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                SetState(State.Playing);
                StartScreenUI.SetActive(false);
                Movement.Instance.Jump();
                SoundManager.Instance.PlaySwooshClip();
            }
        }
    }
    private void GameManager_OnBirdDied(object sender, EventArgs e)
    {
        SetState(State.GameOver);
    }

    private void HandleState()
    {
        switch (state)
        {
            case State.WaitingToStart:
                Bird.Instance.DisableGravity();
                animator.enabled = false;
                PipeSpawner.Instance.StopSpawning();
                break;
            case State.Playing:
                Bird.Instance.EnableGravity();
                animator.enabled = true;
                PipeSpawner.Instance.StartSpawning();
                break;
            case State.GameOver:
                PipeSpawner.Instance.StopSpawning();
                animator.enabled = false;
                break;
            default:
                break;
        }
    }

    public void SetState(State state)
    {
        this.state = state;
        HandleState();
    }
    public State GetState()
    {
        return state;
    }
}

