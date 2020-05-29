﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] soundtracks;
	private AudioSource musicSource;

	// Use this for initialization
	void Start () {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = false;
	}

	private AudioClip GetRandomClip() {
		return soundtracks[Random.Range(0, soundtracks.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if (!musicSource.isPlaying) {
            musicSource.clip = GetRandomClip();
            musicSource.Play();
		}
	}
	public void ShuffleTrack () {
		if (musicSource.isPlaying) {
            musicSource.clip = GetRandomClip();
            musicSource.Play();

            SFXController.PlaySound("UIClick");
		}
    }
}
