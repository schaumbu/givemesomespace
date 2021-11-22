using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour {
    [SerializeField] private int lifePoints = 1;
    [SerializeField] protected float speed = 1;
    [SerializeField] private int hitScore;
    [SerializeField] private int lastHitScore;
    [SerializeField] private bool blinkable = true;
    [SerializeField] public int collisionOrder = 0;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject soul;
    [SerializeField] private GameObject deathSound;
    protected Bounds spawnBounds => new Bounds(bounds.center, bounds.size - Vector3.one * .1f);

    private bool inside => Camera.main.orthographicBounds().Intersects(bounds);

    private Bounds bounds => GetComponent<Collider2D>().bounds;
    private PlayerCrosshair lastHit;
    private bool blink;
    private SpriteRenderer spriteRenderer;

    public virtual void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(lifeTimeRoutine());
        StartCoroutine(lifePointsRoutine());
    }

    public virtual void Update() {
        spriteRenderer.sortingOrder = (int) (transform.position.y * 100 + collisionOrder * 10000);
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }

    public void onHit(PlayerCrosshair origin) {
        if (!blink) {
            lifePoints--;
            lastHit = origin;
            origin.addScore(hitScore);
        }

        if (blinkable) StartCoroutine(blinkRoutine());
    }

    private IEnumerator blinkRoutine() {
        blink = true;
        foreach (var _ in Enumerable.Range(0, 5)) {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.05f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.05f);
        }

        blink = false;
    }

    private IEnumerator lifeTimeRoutine() {
        yield return new WaitUntil(() => inside);
        yield return new WaitWhile(() => inside);
        Destroy(gameObject);
    }

    private IEnumerator lifePointsRoutine() {
        yield return new WaitWhile(() => lifePoints > 0);
        lastHit.addScore(lastHitScore);
        Instantiate(deathSound);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(soul, transform.position, Quaternion.identity).GetComponent<Soul>().target = lastHit.weapon;
        Destroy(gameObject);
    }
}
