using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {
    private readonly Vector2 offset = new(.1f, -.125f);

    private void Update() {
        transform.position = transform.parent.position + (Vector3) offset;
        GetComponent<SpriteRenderer>().enabled =
            transform.parent.GetComponent<SpriteRenderer>().enabled;
    }
}
