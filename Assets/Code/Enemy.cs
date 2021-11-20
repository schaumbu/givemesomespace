using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour {
    public int lifePoints = 1;
    public float speed = 1;
    public int hitScore = 0;
    public int lastHitScore = 0;
    public GameObject explosion;
    public GameObject soul;
    private bool inside => Camera.main.orthographicBounds().Intersects(bounds);

    private Bounds bounds => GetComponent<Collider2D>().bounds;
    public Bounds spawnBounds => new Bounds(bounds.center, bounds.size - Vector3.one*.1f);
    private PlayerCrosshair lastHit = null;
    private bool blink = false;
    
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
        yield return new WaitWhile(() => lifePoints > 0);
        lastHit.addScore(lastHitScore);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(soul, transform.position, Quaternion.identity).GetComponent<Soul>().target = lastHit.weapon;
        Destroy(gameObject);
    }
}
