using System;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviourComet : Enemy {
    public float rotationSpeed = 50;
    private Vector2 direction;
    public override void Start() {
        base.Start();
        var cameraBounds = Camera.main.orthographicBounds();
        var horizontal = Random.Range(0, 2) == 1;
        if (horizontal) {
            var x = Random.Range(0, 2) == 1
                ? cameraBounds.min.x - spawnBounds.size.x / 2
                : cameraBounds.max.x + spawnBounds.size.x / 2;
            var yMin = cameraBounds.min.y + spawnBounds.size.y / 2;
            var yMax = cameraBounds.max.y - spawnBounds.size.y / 2;
            transform.position = new Vector3(x, Random.Range(yMin, yMax)) + transform.position - spawnBounds.center;
        }
        else {
            var y = Random.Range(0, 2) == 1
                ? cameraBounds.min.y - spawnBounds.size.y / 2
                : cameraBounds.max.y + spawnBounds.size.y / 2;
            var xMin = cameraBounds.min.x + spawnBounds.size.x / 2;
            var xMax = cameraBounds.max.x - spawnBounds.size.x / 2;
            transform.position = new Vector3(Random.Range(xMin, xMax), y) + transform.position - spawnBounds.center;
        }

        direction = (transform.position - (cameraBounds.center + (Vector3)Random.insideUnitCircle * (cameraBounds.size.magnitude/3))).normalized;
    }

    public override void Update() {
        base.Update();
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        transform.position += (Vector3)direction * Time.deltaTime * -speed;
    }
}
