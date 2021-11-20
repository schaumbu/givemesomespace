using UnityEngine;

public class EnemyBehaviourMoorhuhn : Enemy {
    private float direction;

    public override void Start() {
        base.Start();
        var cameraBounds = Camera.main.orthographicBounds();
        direction = Random.Range(0, 2) == 1 ? -1 : 1;
        var x = Mathf.Sign(direction) > 0
            ? cameraBounds.min.x - spawnBounds.size.x / 2
            : cameraBounds.max.x + spawnBounds.size.x / 2;
        var yMin = cameraBounds.min.y + spawnBounds.size.y / 2;
        var yMax = cameraBounds.max.y - spawnBounds.size.y / 2;
        transform.position = new Vector3(x, Random.Range(yMin, yMax)) + transform.position - spawnBounds.center;

        if (direction > 0) {
            transform.Rotate(0,180,0);
        }
    }

    private void Update() {
        transform.position += Vector3.right * Time.deltaTime * direction * speed;
    }
}
