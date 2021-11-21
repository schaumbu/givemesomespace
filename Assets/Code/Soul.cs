using System;
using UnityEngine;

public class Soul : MonoBehaviour {
    [NonSerialized]
    public Weapon target;

    public float speed = 10;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = target.color;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.soulTarget.position, Time.deltaTime * speed);
        if (transform.position == target.soulTarget.position) {
            Destroy(gameObject);
        }

        var spriteRendererColor = spriteRenderer.color;
        spriteRendererColor.a = Mathf.Clamp01(Vector2.Distance(transform.position, target.soulTarget.position) * .2f);
        spriteRenderer.color = spriteRendererColor;
    }
}
