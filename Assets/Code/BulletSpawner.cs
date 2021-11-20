using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawner : MonoBehaviour
{

    public GameObject spawnOrigin;
    public GameObject bullet;
    private PlayerCrosshair playerCrosshair;
    
    private void Start() {
        playerCrosshair = gameObject.GetComponent<PlayerCrosshair>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawnBullet();
            var closestPoint = Physics2D.OverlapPoint(transform.position);
            if (closestPoint != null) {
                closestPoint.gameObject.GetComponent<Enemy>().onHit(playerCrosshair);
            }
        }
    }

    void spawnBullet()
    {
        var blt = Instantiate(bullet, spawnOrigin.transform.position, Quaternion.identity);
        blt.GetComponent<Bullet>().target = new Vector2(transform.position.x, transform.position.y);
    }
}
