using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayRandomSound : MonoBehaviour {
    
    public AudioSource source;

    public AudioClip[] audioClips;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    void Start() {
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
        source.PlayOneShot(source.clip);
    }
    
    private void Update() {
        if(!source.isPlaying)
            Destroy(gameObject);
    }
}
