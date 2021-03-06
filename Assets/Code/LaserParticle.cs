using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LaserParticle : MonoBehaviour {
    public float after = .1f;
    private float timer = 0;
    private Color start;
    private SpriteRenderer ren;

    void Start() {
        ren = GetComponent<SpriteRenderer>();
        start = ren.color;
        Destroy(gameObject, after);
    }

    private void Update() {
        timer += (1 / after) * Time.deltaTime;
        ren.color = new Color(start.r, start.g, start.b, (1 - timer));
    }
}
