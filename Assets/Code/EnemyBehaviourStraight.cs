using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourStraight : Enemy {
    // Start is called before the first frame update
    void Start() {
        var cameraBounds = Camera.main.orthographicBounds();
        var yMin = cameraBounds.min.y + bounds.size.y / 2;
        var yMax = cameraBounds.max.y - bounds.size.y / 2;
        var x = Random.Range(0, 2) == 1
            ? cameraBounds.min.x - bounds.size.x / 2
            : cameraBounds.max.x + bounds.size.x / 2;
        transform.position = new Vector3(x, Random.Range(yMin, yMax)) + transform.position - bounds.center;
    }

    // Update is called once per frame
    void Update() {
    }
}
