using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip wingClip;
    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip swooshClip;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        Bird.Instance.OnPassedPipe += Bird_OnPassedPipe;
        Bird.Instance.OnBirdDied += Bird_OnBirdDied;
    }
    private void OnDestroy()
    {
        Bird.Instance.OnPassedPipe -= Bird_OnPassedPipe;
        Bird.Instance.OnBirdDied -= Bird_OnBirdDied;
    }
    private void Bird_OnBirdDied(object sender, EventArgs e)
    {
        PlayHitClip();
        PlayDieClip();
    }
    private void Bird_OnPassedPipe(object sender, EventArgs e)
    {
        PlayPointClip();
    }

    private void PlayDieClip()
    {
        audioSource.PlayOneShot(dieClip);
    }
    public void PlayWingClip()
    {
        audioSource.PlayOneShot(wingClip);
    }
    private void PlayPointClip()
    {
        audioSource.PlayOneShot(pointClip);
    }
    private void PlayHitClip()
    {
        audioSource.PlayOneShot(hitClip);
    }
    public void PlaySwooshClip()
    {
        audioSource.PlayOneShot(swooshClip);
    }
}
