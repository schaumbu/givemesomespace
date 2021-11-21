using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {
    private Vector2 offset = new Vector2(.1f, -.125f);

    void Update() {
        transform.position = transform.parent.position + (Vector3) offset;
        GetComponent<SpriteRenderer>().enabled =
            transform.parent.GetComponent<SpriteRenderer>().enabled;
    }
}
