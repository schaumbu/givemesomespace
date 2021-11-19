using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 target;
    public Vector2 start;
    public float timer;
    public float maxFlightTime;
    public float sqrtPower;
    public float bulletStartSize;
    public float bulletEndSize;
    
    private void Start()
    {
        start = transform.position;
        timer = 0f;
    }
    void Update()
    {
        if (timer > maxFlightTime)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        var flightTime = timer / maxFlightTime;
        transform.position = Vector2.Lerp(start, target, Mathf.Pow(flightTime, sqrtPower));
        transform.localScale = Vector3.one * Mathf.Lerp(bulletStartSize, bulletEndSize, Mathf.Pow(flightTime, sqrtPower));
    }
}