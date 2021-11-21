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

        void onUnloaded(Scene arg0) {
            music.Stop();
            start.Play();
            SceneManager.sceneUnloaded -= onUnloaded;
        }

        SceneManager.sceneUnloaded += onUnloaded;
    }

    private void Update() {
        if (!start.isPlaying && !music.isPlaying) {
            Destroy(gameObject);
        }
    }
}
