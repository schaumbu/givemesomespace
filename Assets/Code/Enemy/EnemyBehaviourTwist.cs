using UnityEngine;

public class EnemyBehaviourTwist : Enemy {

    public float minAngle = 45;
    public float maxAngle = 90;
    private Vector3 direction = Vector3.up;
    private float rotAngle;

    public override void Start() {
        base.Start();
        var cameraBounds = Camera.main.orthographicBounds();
        direction = Random.Range(0, 2) == 1 ? Vector3.down : Vector3.up;
        var y = Mathf.Sign(direction.y) > 0
            ? cameraBounds.min.y - spawnBounds.size.y / 2
            : cameraBounds.max.y + spawnBounds.size.y / 2;
        var xMin = cameraBounds.min.y + spawnBounds.size.y / 2;
        var xMax = cameraBounds.max.y - spawnBounds.size.y / 2;
        transform.position = new Vector3(Random.Range(xMin, xMax), y) + transform.position - spawnBounds.center;
        
        rotAngle = Random.Range(minAngle, maxAngle);
        if (Random.Range(0, 2) == 0) {
            rotAngle *= -1;
        }
    }

    public override void Update() {
        base.Update();
        direction = Quaternion.AngleAxis(rotAngle * Time.deltaTime, Vector3.forward) * direction;
        
        transform.position += Time.deltaTime * speed * direction;
    }
}
