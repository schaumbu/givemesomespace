using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour {
    public int lifePoints = 1;
    public float speed = 1;
    public int hitScore = 0;
    public int lastHitScore = 0;
    private bool inside => Camera.main.orthographicBounds().Intersects(bounds);

    private Bounds bounds => GetComponent<Collider2D>().bounds;
    public Bounds spawnBounds => new Bounds(bounds.center, bounds.size - Vector3.one*.1f);
    private PlayerCrosshair lastHit = null;
    
    public virtual void Start() {
        StartCoroutine(lifeTimeRoutine());
        StartCoroutine(lifePointsRoutine());
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }
    public void onHit(PlayerCrosshair origin) {
        lifePoints--;
        lastHit = origin;
        origin.addScore(hitScore);
    }

    IEnumerator lifeTimeRoutine() {
        yield return new WaitUntil(() => inside);
        yield return new WaitWhile(() => inside);
        Destroy(gameObject);
    }

    IEnumerator lifePointsRoutine() {
        yield return new WaitWhile(() => lifePoints > 0);
        lastHit.addScore(lastHitScore);
        Destroy(gameObject);
    }
}
