using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviourTwist : Enemy {
    private int direction;
    private Vector3 move = Vector3.up;
    private float rotAngle;
    public override void Start() {
        base.Start();
        var cameraBounds = Camera.main.orthographicBounds();
        direction = Random.Range(0, 2) == 1 ? -1 : 1;
        var y = Mathf.Sign(direction) > 0
            ? cameraBounds.min.y - spawnBounds.size.y / 2
            : cameraBounds.max.y + spawnBounds.size.y / 2;
        var xMin = cameraBounds.min.y + spawnBounds.size.y / 2;
        var xMax = cameraBounds.max.y - spawnBounds.size.y / 2;
        transform.position = new Vector3(Random.Range(xMin, xMax), y) + transform.position - spawnBounds.center;
        rotAngle = Random.Range(1.5f, 2.5f);
        if ((direction == -1 && transform.position.x > cameraBounds.center.x) ||
            (direction == 1 && transform.position.x <= cameraBounds.center.x))

            rotAngle = -rotAngle;
    }

    private void Update() {
        int rando = Random.Range(-1, 3);
        transform.position += move * Time.deltaTime * direction * speed;
        Quaternion q = Quaternion.AngleAxis(rotAngle * rando, Vector3.forward);
        move = q * move; 
    }
}
