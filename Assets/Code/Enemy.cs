using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour {
    private int lifePoints;
    private bool inside => Camera.main.orthographicBounds().Intersects(GetComponent<Collider2D>().bounds);
        
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(lifeTimeRoutine());
        StartCoroutine(lifePointsRoutine());
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }
    void onHit(object origin) {
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
