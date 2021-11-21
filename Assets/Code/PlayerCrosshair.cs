using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrosshair : MonoBehaviour {
    public float speed = 1;
    public GameObject bullet;
    public Weapon weapon { get; private set; }
    private Vector2 move = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    public int score { get; private set; }
    public float movementActivation = 14;
    public enum LeftRight {
        left,
        right
    };
    public LeftRight side;
    
    private void Awake() {
        weapon = FindObjectsOfType<Weapon>().OrderBy(x => x.order).First(x => !x.used);
        weapon.useBy(this);
        GetComponent<SpriteRenderer>().color = weapon.color;
        if (FindObjectsOfType<PlayerCrosshair>().Length == 1) {
            side = LeftRight.left;
        }
        else {
            side = LeftRight.right;
        }
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

        var colliders = Physics2D.OverlapPointAll(transform.position);
        var enemy = colliders
            .Where(x => x.GetComponent<Enemy>() != null)
            .Select(x => x.GetComponent<Enemy>())
            .OrderBy(x => x.collisionOrder).LastOrDefault();
        if (enemy != null) {
            enemy.onHit(this);
        }

        var buttons = colliders.Where(x => x.GetComponent<MenuButton>() != null).Select(x => x.GetComponent<MenuButton>());
        foreach (var button in buttons) {
            button.onClick();
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
