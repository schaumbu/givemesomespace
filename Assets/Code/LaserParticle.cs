using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LaserParticle : MonoBehaviour {
    [SerializeField] private float after = .1f;
    private SpriteRenderer ren;
    private Color start;
    private float timer;

    private void Start() {
        ren = GetComponent<SpriteRenderer>();
        start = ren.color;
        Destroy(gameObject, after);
    }

    private void Update() {
        timer += 1 / after * Time.deltaTime;
        ren.color = new Color(start.r, start.g, start.b, 1 - timer);
    }
}
