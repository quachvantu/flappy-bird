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
                animator.enabled = false;
                PipeSpawner.Instance.StopSpawning();
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    SetState(State.Playing);
                    StartScreenUI.SetActive(false);
                    SoundManager.Instance.PlaySwooshClip();
                }
                break;
            case State.Playing:

                Bird.Instance.EnableGravity();
                animator.enabled = true;
                PipeSpawner.Instance.StartSpawning();
                if (!Bird.Instance.GetIsAlive())
                {
                    SetState(State.GameOver);
                }
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
    }
}

