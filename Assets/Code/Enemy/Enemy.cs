using System.Collections;
using System.Linq;
using Code.Enemy;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer), typeof(EntityOrder))]
public class Enemy : MonoBehaviour {
    [SerializeField] private int lifePoints = 1;
    [SerializeField] protected float speed = 1;
    [SerializeField] private int hitScore;
    [SerializeField] private int lastHitScore;
    [SerializeField] private bool blinkable = true;
    [SerializeField] private GameObject? explosion = null;
    [SerializeField] private GameObject? soul = null;
    [SerializeField] private GameObject? deathSound = null;

    private SpriteRenderer spriteRenderer = null!;
    private EntityOrder entityOrder = null!;
    private Weapon? lastHit;
    private bool blink;
    public int order => entityOrder.order;

    private bool inside => Camera.main!.orthographicBounds().Intersects(bounds);

    private Bounds bounds => GetComponent<Collider2D>().bounds;
    protected Bounds spawnBounds => new(bounds.center, bounds.size - Vector3.one * .1f);

    private void Awake() {
        entityOrder = GetComponent<EntityOrder>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void Start() {
        StartCoroutine(lifeTimeRoutine());
        StartCoroutine(lifePointsRoutine());
    }

    public virtual void Update() { }

    private void OnDestroy() {
        StopAllCoroutines();
    }

    public void onHit(Weapon origin) {
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
        Assert.IsNotNull(explosion);
        Assert.IsNotNull(soul);
        Assert.IsNotNull(deathSound);
        var position = transform.position;
        if (lastHit != null) {
            lastHit.addScore(lastHitScore);
            Instantiate(soul, position, Quaternion.identity).GetComponent<Soul>().init(lastHit);
        }
        Instantiate(explosion, position, Quaternion.identity);
        Instantiate(deathSound);
        Destroy(gameObject);
    }
}
