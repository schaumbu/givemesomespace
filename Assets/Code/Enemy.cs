using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour {
    public int lifePoints = 1;
    public float speed = 1;
    public int hitScore;
    public int lastHitScore;
    public GameObject explosion;
    public GameObject soul;
    public GameObject deathSound;
    public Bounds spawnBounds => new Bounds(bounds.center, bounds.size - Vector3.one*.1f);

    private bool inside => Camera.main.orthographicBounds().Intersects(bounds);

    private Bounds bounds => GetComponent<Collider2D>().bounds;
    private PlayerCrosshair lastHit;
    private bool blink;
    
    public virtual void Start() {
        StartCoroutine(lifeTimeRoutine());
        StartCoroutine(lifePointsRoutine());
    }

    public virtual void Update() {
        GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * 1000);
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

        StartCoroutine(blinkRoutine());
    }

    IEnumerator blinkRoutine() {
        var ren = GetComponent<SpriteRenderer>();

        blink = true;
        foreach (var _ in Enumerable.Range(0, 5)) {
            ren.enabled = false;
            yield return new WaitForSeconds(.05f);
            ren.enabled = true;
            yield return new WaitForSeconds(.05f);
        }

        blink = false;
    }

    IEnumerator lifeTimeRoutine() {
        yield return new WaitUntil(() => inside);
        yield return new WaitWhile(() => inside);
        Destroy(gameObject);
    }

    IEnumerator lifePointsRoutine() {
        yield return new WaitWhile(()=> lifePoints > 0);
        lastHit.addScore(lastHitScore);
        Instantiate(deathSound);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(soul, transform.position, Quaternion.identity).GetComponent<Soul>().target = lastHit.weapon;
        Destroy(gameObject);
    }
}
