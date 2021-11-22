using System;
using UnityEngine;

public class Soul : MonoBehaviour {
    [SerializeField] private float speed = 10;
    [NonSerialized] public Weapon target;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = target.color;
    }

    private void Update() {
        transform.position =
            Vector2.MoveTowards(transform.position, target.soulTarget.position, Time.deltaTime * speed);
        if (transform.position == target.soulTarget.position) {
            Destroy(gameObject);
        }

        var spriteRendererColor = spriteRenderer.color;
        spriteRendererColor.a = Mathf.Clamp01(Vector2.Distance(transform.position, target.soulTarget.position) * .2f);
        spriteRenderer.color = spriteRendererColor;
    }
}
