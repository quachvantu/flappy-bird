using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private State state;
    [SerializeField] private GameObject StartScreenUI;
    public enum State
    {
        WaitingToStart,
        Playing,
        GameOver
    }
    private void Start()
    {
        Instance = this;
        state = State.WaitingToStart;
        HandleState();
    }
    private void Update()
    {
        HandleState();
    }
    private void HandleState()
    {
        switch (state)
        {
            case State.WaitingToStart:
                Bird.Instance.DisableGravity();
                PipeSpawner.Instance.StopSpawning();
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    SetState(State.Playing);
                }
                break;
            case State.Playing:
                StartScreenUI.SetActive(false);
                Bird.Instance.EnableGravity();
                PipeSpawner.Instance.StartSpawning();
                if (!Bird.Instance.GetIsAlive())
                {
                    SetState(State.GameOver);
                }
                break;
            case State.GameOver:
                PipeSpawner.Instance.StopSpawning();
                break;
            default:
                break;
        }
    }

    public void SetState(State state)
    {
        this.state = state;
    }
}

