using System;
using UnityEngine;

public class Soul : MonoBehaviour {
    [NonSerialized]
    public Weapon target;

    public float speed = 10;
    void Start() {
        GetComponent<SpriteRenderer>().color = target.color;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.soulTarget.position, Time.deltaTime * speed);
        if (transform.position == target.soulTarget.position) {
            Destroy(gameObject);
        }
    }
}
