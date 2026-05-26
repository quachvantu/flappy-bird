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

    public void PlayDieClip()
    {
        audioSource.PlayOneShot(dieClip);
    }
    public void PlayWingClip()
    {
        audioSource.PlayOneShot(wingClip);
    }
    public void PlayPointClip()
    {
        audioSource.PlayOneShot(pointClip);
    }
    public void PlayHitClip()
    {
        audioSource.PlayOneShot(hitClip);
    }
    public void PlaySwooshClip()
    {
        audioSource.PlayOneShot(swooshClip);
    }
}
