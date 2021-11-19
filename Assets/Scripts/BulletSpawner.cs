using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawner : MonoBehaviour
{

    public GameObject spawnOrigin;
    public GameObject bullet;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        var blt = Instantiate(bullet, spawnOrigin.transform.position, Quaternion.identity);
        blt.GetComponent<Bullet>().target = new Vector2(transform.position.x, transform.position.y);
    }
}
