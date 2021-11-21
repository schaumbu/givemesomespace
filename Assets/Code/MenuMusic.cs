using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {
    public AudioSource music;
    public AudioSource start;
    void Start() {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneUnloaded += arg0 => {
            music.Stop();
            start.Play();
        };
    }

    private void Update() {
        if (!start.isPlaying && !music.isPlaying) {
            Destroy(gameObject);
        }
    }
}
