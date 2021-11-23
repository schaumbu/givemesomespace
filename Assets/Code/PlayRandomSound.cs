using UnityEngine;

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
