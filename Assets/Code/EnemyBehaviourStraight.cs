using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviourStraight : Enemy {
    private float direction;

    // Start is called before the first frame update
    public override void Start() {
        base.Start();
        var cameraBounds = Camera.main.orthographicBounds();
        var yMin = cameraBounds.min.y + bounds.size.y / 2;
        var yMax = cameraBounds.max.y - bounds.size.y / 2;
        direction = Random.Range(0, 2) == 1 ? -1 : 1;
        var x = Mathf.Sign(direction) > 0
            ? cameraBounds.min.x - bounds.size.x / 2
            : cameraBounds.max.x + bounds.size.x / 2;
        transform.position = new Vector3(x, Random.Range(yMin, yMax)) + transform.position - bounds.center;
    }

    private void Update() {
        transform.position += Vector3.right * Time.deltaTime * direction;
    }
}
