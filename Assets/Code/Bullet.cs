using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Debug = System.Diagnostics.Debug;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour {
    [FormerlySerializedAs("maxFlightTime")] [SerializeField] private float flightTime;
    [FormerlySerializedAs("stretch")] [SerializeField] private float stretchMultiplication = 1f;
    [SerializeField] private AnimationCurve travelDistance = new();
    [SerializeField] private AnimationCurve bulletSize = new();
    [SerializeField] private GameObject laserParticle = null!;
    [SerializeField] private GameObject bulletSound = null!;
    
    private Vector2 start;
    private Vector2 target;
    private float liveTime;

    private Vector2 direction => target - start;

    public void init(Vector2 target) {
        this.target = target;
    }

    private void Awake() {
        Assert.IsNotNull(laserParticle);
        Assert.IsNotNull(bulletSound);
    }

    private void Start() {
        start = transform.position;
        Instantiate(bulletSound);
        Instantiate(laserParticle, start, Quaternion.AngleAxis(Random.Range(-5f, 5f), Vector3.forward));
        Destroy(gameObject, flightTime);
    }

    private void Update() {
        liveTime += Time.deltaTime / flightTime;
        
        var stretch = Mathf.Max(Vector2.Distance(start, target) * stretchMultiplication, 1);
        
        transform.position = Vector2.Lerp(start, target, travelDistance.Evaluate(liveTime));
        transform.localScale = new Vector3(1 / stretch, stretch, 1) * bulletSize.Evaluate(liveTime);
        transform.rotation = Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, direction), Vector3.forward);
    }
}
