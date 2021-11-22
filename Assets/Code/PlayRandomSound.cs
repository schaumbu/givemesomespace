using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayRandomSound : MonoBehaviour {
    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip[] audioClips;

    private void Awake() {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
        source.PlayOneShot(source.clip);
    }

    private void Update() {
        if (!source.isPlaying)
            Destroy(gameObject);
    }
}
