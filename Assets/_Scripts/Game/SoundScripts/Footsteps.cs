using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Header("Footstep sounds when walking")]
    public AudioClip[] walkingClips;

    [Header("Footstep sounds when running")]
    public AudioClip[] runningClips;

    private static Footsteps instance;
    private AudioSource audioSource;
    private bool isMoving = false;

    // Use this for initialization
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        instance = this;
    }

    private AudioClip GetRandomWalkingClips()
    {
        return walkingClips[Random.Range(0, walkingClips.Length)];
    }

    private AudioClip GetRandomRunningClips()
    {
        return runningClips[Random.Range(0, runningClips.Length)];
    }

    private void WalkingFootstepsInstance()
    {
        isMoving = !isMoving;
        if (audioSource.isPlaying)
            return;

        if (isMoving)
        {
            audioSource.clip = GetRandomWalkingClips();
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public static void WalkingFootsteps()
    {
        instance.WalkingFootstepsInstance();
    }

    public static void RunningFootsteps()
    {
        instance.RunningFootstepsInstance();
    }

    public static void StopFootsteps()
    {
        instance.StopFootstepsInstance();
    }

    private void RunningFootstepsInstance()
    {
        isMoving = !isMoving;
        if (audioSource.isPlaying)
            return;

        if (isMoving)
        {
            audioSource.clip = GetRandomRunningClips();
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void StopFootstepsInstance()
    {
        audioSource.Stop();
    }
}