using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource start;

    private void Start() {
        DontDestroyOnLoad(gameObject);

        void onUnloaded(Scene arg0) {
            music.Stop();
            start.Play();
            SceneManager.sceneUnloaded -= onUnloaded;
        }

        SceneManager.sceneUnloaded += onUnloaded;
    }

    private void Update() {
        if (!start.isPlaying && !music.isPlaying) Destroy(gameObject);
    }
}
