using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour {
    public int lifePoints = 1;
    private bool inside => Camera.main.orthographicBounds().Intersects(bounds);

    public Bounds bounds => GetComponent<Collider2D>().bounds;
    
    public virtual void Start() {
        StartCoroutine(lifeTimeRoutine());
        StartCoroutine(lifePointsRoutine());
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }
    public void onHit(PlayerCrosshair origin) {
        lifePoints--;
    }

    IEnumerator lifeTimeRoutine() {
        yield return new WaitUntil(() => inside);
        yield return new WaitWhile(() => inside);
        Destroy(gameObject);
    }

    IEnumerator lifePointsRoutine() {
        yield return new WaitWhile(() => lifePoints > 0);
        Destroy(gameObject);
    }
}
