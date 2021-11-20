using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrosshair : MonoBehaviour {
    public float speed = 1;
    public GameObject bullet;
    private Weapon weapon;
    private Vector2 move = Vector2.zero;
    public int score { get; private set; }

    private void Awake() {
         weapon = FindObjectsOfType<Weapon>().OrderBy(x => x.order).First(x => !x.used);
        weapon.useBy(this);
        GetComponent<SpriteRenderer>().color = weapon.color;
    }

    private void Update() {
        transform.position += Time.deltaTime * speed * (Vector3) move;

        var border = Camera.main.orthographicBounds().size / 2 - Vector3.one;
        transform.position = Vector2.Max(Vector2.Min(transform.position, border), -border);
    }

    [UsedImplicitly]
    public void OnShoot() {
        var blt = Instantiate(bullet, weapon.origin.transform.position, Quaternion.identity);
        var component = blt.GetComponent<Bullet>();
        component.target = new Vector2(transform.position.x, transform.position.y);
        var collider = Physics2D.OverlapPoint(transform.position);
        if (collider != null) {
            collider.gameObject.GetComponent<Enemy>().onHit(this);
            component.hitting = true;
        }
    }

    [UsedImplicitly]
    public void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }

    public void addScore(int addition) {
        score += addition;
    }
}
