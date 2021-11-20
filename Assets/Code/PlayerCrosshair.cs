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
         weapon = FindObjectsOfType<Weapon>().First(x => !x.used);
        weapon.useBy(this);
        GetComponent<SpriteRenderer>().color = weapon.color;
    }

    private void Update() {
        transform.position += Time.deltaTime * speed * (Vector3)move;
    }

    [UsedImplicitly]
    public void OnShoot() {
        spawnBullet();
        var collider = Physics2D.OverlapPoint(transform.position);
        if (collider != null) {
            collider.gameObject.GetComponent<Enemy>().onHit(this);
        }
    }

    void spawnBullet() {
        var blt = Instantiate(bullet, weapon.transform.position, Quaternion.identity);
        blt.GetComponent<Bullet>().target = new Vector2(transform.position.x, transform.position.y);
    }

    [UsedImplicitly]
    public void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }

    public void addScore(int addition) {
        score += addition;
    }
}
