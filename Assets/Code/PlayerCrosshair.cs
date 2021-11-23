using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerCrosshair : MonoBehaviour {
    [SerializeField] private float speed = 1;
    [FormerlySerializedAs("bullet")] [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float movementActivation = 14;
    public LeftRight side => weapon.originSide;

    private Vector2 move = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    public Weapon weapon { get; private set; }


    private void Awake() {
        weapon = Weapon.grabFree().useBy(this);
    }

    private void Start() {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = weapon.color;
    }

    private void Update() {
        velocity = Vector2.MoveTowards(velocity, move, Time.deltaTime * movementActivation);
        transform.position += Time.deltaTime * speed * (Vector3) velocity;

        var border = Camera.main.orthographicBounds().size / 2 - Vector3.one;
        transform.position = Vector2.Max(Vector2.Min(transform.position, border), -border);
    }

    [UsedImplicitly]
    public void OnShoot() {
        showBullet();
        testBulletCollision();
    }

    private void testBulletCollision() {
        var colliders = Physics2D.OverlapPointAll(transform.position);
        testEnemyCollision(colliders);
        testMenuCollision(colliders);
    }

    private void testEnemyCollision(IEnumerable<Collider2D> colliders) {
        var enemy = colliders
            .Where(x => x.GetComponent<Enemy>() != null)
            .Select(x => x.GetComponent<Enemy>())
            .OrderBy(x => x.order).LastOrDefault();
        if (enemy != null) enemy.onHit(weapon);
    }

    private static void testMenuCollision(IEnumerable<Collider2D> colliders) {
        var buttons = colliders.Where(x => x.GetComponent<MenuButton>() != null)
            .Select(x => x.GetComponent<MenuButton>());
        foreach (var button in buttons) button.onClick();
    }

    private void showBullet() {
        var bullet = Instantiate(bulletPrefab, weapon.origin.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().init(transform.position);
    }

    [UsedImplicitly]
    public void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }
}
