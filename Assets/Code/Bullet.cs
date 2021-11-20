using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [NonSerialized] public Vector2 target;
    [NonSerialized] public Vector2 start;
    public float maxFlightTime;
    public AnimationCurve travelDistance;
    public AnimationCurve bulletSize;
    public bool hitting = false;
    private float timer = 0;

    private Vector2 direction => target - start;

    private void Start() {
        start = transform.position;
    }

    void Update() {
        if (timer > maxFlightTime) {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
        var flightTime = timer / maxFlightTime;
        transform.position = Vector2.Lerp(start, target, travelDistance.Evaluate(flightTime));
        transform.localScale = Vector3.one * bulletSize.Evaluate(flightTime);
        transform.rotation = Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, direction), Vector3.forward);
    }
}
