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
    private Vector2 velocity = Vector2.zero;
    public int score { get; private set; }
    public float movementActivation = 14;

    private void Awake() {
         weapon = FindObjectsOfType<Weapon>().OrderBy(x => x.order).First(x => !x.used);
        weapon.useBy(this);
        GetComponent<SpriteRenderer>().color = weapon.color;
    }

    private void Update() {
        velocity = Vector2.MoveTowards(velocity, move, Time.deltaTime * movementActivation);
        transform.position += Time.deltaTime * speed * (Vector3) velocity;

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
            var enemy = collider.gameObject.GetComponent<Enemy>();
            var menuButton = collider.gameObject.GetComponent<MenuButton>();
            if (enemy != null) {
                enemy.onHit(this);
            }

            if (menuButton != null) {
                menuButton.onClick();
            }
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
