using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour {
    [NonSerialized] public Vector2 target;
    [NonSerialized] public Vector2 start;
    public float maxFlightTime;
    public AnimationCurve travelDistance;
    public AnimationCurve bulletSize;
    public GameObject laserParticle = null;
    public float stretch = 1f;
    public GameObject bulletSound;
    private float timer;

    private Vector2 direction => target - start;

    private void Start() {
        start = transform.position;
        Instantiate(bulletSound);
        Instantiate(laserParticle, transform.position, Quaternion.AngleAxis(Random.Range(-5f, 5f), Vector3.forward));
    }

    void Update() {
        if (timer > maxFlightTime) {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
        var flightTime = timer / maxFlightTime;
        transform.position = Vector2.Lerp(start, target, travelDistance.Evaluate(flightTime));
        var speed = Vector2.Distance(start, target) * stretch;
        speed = Mathf.Max(speed, 1);
        transform.localScale = new Vector3(1/speed, speed, 1) * bulletSize.Evaluate(flightTime);
        transform.rotation = Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, direction), Vector3.forward);
    }
}
